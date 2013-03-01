package Class;

import android.content.Context;
import android.net.ConnectivityManager;

public class NetKontrol {

	public boolean KontrolET(Context Ctx){
		ConnectivityManager connectivity = null;
		connectivity = (ConnectivityManager) Ctx
				.getSystemService(Context.CONNECTIVITY_SERVICE);
		if (connectivity.getActiveNetworkInfo() != null) {
			if (connectivity.getActiveNetworkInfo().isConnected())
				return true;
		}
		return false;
	}
}
