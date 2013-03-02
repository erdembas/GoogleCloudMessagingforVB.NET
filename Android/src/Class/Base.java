package Class;

import android.accounts.Account;
import android.accounts.AccountManager;
import android.content.Context;

public class Base {
	public static String SistemMailAdres(Context CTX) {
		try {
		AccountManager	accountManager = AccountManager.get(CTX.getApplicationContext());
			Account[] accounts = accountManager.getAccountsByType("com.google");
			return accounts[0].name;
		} catch (Exception e) {
			// TODO: handle exception
		}
		return null;
	}
}
