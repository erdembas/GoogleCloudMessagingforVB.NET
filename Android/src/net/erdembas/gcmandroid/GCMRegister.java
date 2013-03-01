package net.erdembas.gcmandroid;

import android.os.Bundle;
import android.app.Activity;
import android.view.Menu;

public class GCMRegister extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.gcmregister);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.gcmregister, menu);
		return true;
	}

}
