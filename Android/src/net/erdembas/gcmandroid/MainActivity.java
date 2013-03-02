package net.erdembas.gcmandroid;

import org.json.JSONException;
import org.json.JSONObject;

import com.google.android.gcm.GCMRegistrar;

import Class.BilgiDialog;
import Class.NetKontrol;
import Class.ThreadPost;
import android.os.Bundle;
import android.app.Activity;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.res.Resources;
import android.telephony.gsm.GsmCellLocation;
import android.util.Log;
import android.view.Menu;
import android.widget.Toast;
import com.google.android.gcm.GCMRegistrar;
import static Class.dotNetServer.SENDER_ID;
import static Class.dotNetServer.EXTRA_MESSAGE;
import static Class.dotNetServer.DISPLAY_MESSAGE_ACTION;

public class MainActivity extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		GCMRegistrar.checkDevice(this);
		GCMRegistrar.checkManifest(this);
		String regId = GCMRegistrar.getRegistrationId(this);
		if (regId.equals("")) {
			GCMRegistrar.register(this, SENDER_ID);
			GCMRegistrar.setRegisteredOnServer(this,true);
		}
		
		registerReceiver(mHandleMessageReceiver, new IntentFilter(
				DISPLAY_MESSAGE_ACTION));
	}
	
	
	private final BroadcastReceiver mHandleMessageReceiver = new BroadcastReceiver() {
		@Override
		public void onReceive(Context context, Intent intent) {
			String newMessage = intent.getExtras().getString(EXTRA_MESSAGE);
			Toast.makeText(getApplicationContext(), "Gelen mesaj: " + newMessage, Toast.LENGTH_LONG).show();
		}
	};

}
