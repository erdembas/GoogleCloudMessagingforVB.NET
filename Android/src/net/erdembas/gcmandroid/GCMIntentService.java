package net.erdembas.gcmandroid;

import static Class.dotNetServer.SENDER_ID;
import Class.Base;
import Class.dotNetServer;
import android.content.Context;
import android.content.Intent;
import android.content.res.Resources;
import android.widget.Toast;

import com.google.android.gcm.GCMBaseIntentService;
import com.google.android.gcm.GCMBroadcastReceiver;
import com.google.android.gcm.GCMRegistrar;

public class GCMIntentService extends GCMBaseIntentService {

	public GCMIntentService() {
		super(SENDER_ID);
	}

	protected void onRegistered(Context context, String registrationId) {
		dotNetServer.ServerKayit(context,
				Base.SistemMailAdres(getApplicationContext()), registrationId);
		Toast.makeText(context.getApplicationContext(), getString(R.string.gcm_basarili), Toast.LENGTH_SHORT)
				.show();
	}

	protected void onUnregistered(Context context, String registrationId) {

	}

	protected void onMessage(Context context, Intent intent) {
		 String message = intent.getStringExtra("content");
		  dotNetServer.mesajGoster(context, message);
	      
	}

	protected void onDeletedMessages(Context context, int total) {
	}

	public void onError(Context context, String errorId) {

	}

}
