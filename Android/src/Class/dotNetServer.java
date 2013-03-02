package Class;

import java.util.Calendar;
import java.util.Date;

import net.erdembas.gcmandroid.MainActivity;

import org.json.JSONException;
import org.json.JSONObject;

import android.content.Context;
import android.content.Intent;
import android.sax.StartElementListener;
import android.text.method.DateTimeKeyListener;
import android.util.Log;
import android.widget.Toast;

public final class dotNetServer {
	static final String SERVER_URL = "gcm.erdembas.net/api/value";
	public static final String SENDER_ID = "608017495537";

	public static void ServerKayit(final Context CTX, String EMail,
			String REGID) {
		ThreadPost PostAt = new ThreadPost();

		
		Calendar currentDate = Calendar.getInstance();
		
		final JSONObject OBJ = new JSONObject();
		try {
			OBJ.put("GCM_Reg_ID", REGID);
			OBJ.put("EMail", Base.SistemMailAdres(CTX));
			OBJ.put("Tarih", currentDate.getTime().toLocaleString());
		} catch (JSONException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		

		PostAt.execute("http://gcm.erdembas.net/api/value", OBJ.toString());
		PostAt.setDataDownloadListener(new ThreadPost.DataDownloadListener() {
			public void dataDownloadedSuccessfully(String data) {
				Toast.makeText(CTX, OBJ.toString(), Toast.LENGTH_SHORT).show();
				if (data == "True") {
					
				} else {
				}
			}
		});

	}

}
