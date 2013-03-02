package net.erdembas.gcmandroid;

import org.json.JSONException;
import org.json.JSONObject;

import com.google.android.gcm.GCMRegistrar;

import Class.BilgiDialog;
import Class.NetKontrol;
import Class.ThreadPost;
import android.os.Bundle;
import android.app.Activity;
import android.content.res.Resources;
import android.telephony.gsm.GsmCellLocation;
import android.util.Log;
import android.view.Menu;
import android.widget.Toast;
import com.google.android.gcm.GCMRegistrar;
import static Class.dotNetServer.SENDER_ID;

public class MainActivity extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		GCMRegistrar.checkDevice(this);
		GCMRegistrar.checkManifest(this);
		String regId = GCMRegistrar.getRegistrationId(this);
		GCMRegistrar.setRegisteredOnServer(this, false);
		if (regId.equals("")) {
			GCMRegistrar.register(this, SENDER_ID);
		}
	}

}
