using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class linkemail : MonoBehaviour 
{
	public void email_A1_SOCTRAVO()
	{
		#if !UNITY_EDITOR
		openWindow("https://mail.google.com/mail/u/0/?fs=1&tf=cm&source=mailto&to=socialtraveling.pemudapeduli@gmail.com");
		#endif
	}

	public void email_A2_BLOKKAYU()
	{
		#if !UNITY_EDITOR
		openWindow("https://mail.google.com/mail/u/0/?fs=1&tf=cm&source=mailto&to=driveblokkayumodular@gmail.com");
		#endif
	}

	public void email_A3_IROASTERBIK()
	{
		#if !UNITY_EDITOR
		openWindow("https://mail.google.com/mail/u/0/?fs=1&tf=cm&source=mailto&to=admin@i-roasterbik.com");
		#endif
	}

	public void email_A4_NIUVA()
	{
		#if !UNITY_EDITOR
		openWindow("https://mail.google.com/mail/u/0/?fs=1&tf=cm&source=mailto&to=andrya@telkomuniversity.ac.id");
		#endif
	}

	public void email_A5_LINGGIS()
	{
		#if !UNITY_EDITOR
		openWindow("https://mail.google.com/mail/u/0/?fs=1&tf=cm&source=mailto&to=linggis.co@gmail.com");
		#endif
	}

	public void email_A6_SIHEDAF()
	{
		#if !UNITY_EDITOR
		openWindow("https://mail.google.com/mail/u/0/?fs=1&tf=cm&source=mailto&to=Sihedaf001@gmail.com");
		#endif
	}

	public void email_A7_TRAINO()
	{
		#if !UNITY_EDITOR
		openWindow("https://mail.google.com/mail/u/0/?fs=1&tf=cm&source=mailto&to=info@btp.or.id");
		#endif
	}

	public void email_A8_DJAVASTRAAT()
	{
		#if !UNITY_EDITOR
		openWindow("https://mail.google.com/mail/u/0/?fs=1&tf=cm&source=mailto&to=kahwateknologiberdikari@gmail.com");
		#endif
	}

	public void email_A9_CUBESTUDIO()
	{
		#if !UNITY_EDITOR
		openWindow("https://mail.google.com/mail/u/0/?fs=1&tf=cm&source=mailto&to=info.me@cubestudio.id");
		#endif
	}

	public void email_A10_NIAGANESIA()
	{
		#if !UNITY_EDITOR
		openWindow("https://mail.google.com/mail/u/0/?fs=1&tf=cm&source=mailto&to=info@niaganesia.com");
		#endif
	}

	public void email_A11_BYTANI()
	{
		#if !UNITY_EDITOR
		openWindow("https://mail.google.com/mail/u/0/?fs=1&tf=cm&source=mailto&to=bytani.id@gmail.com");
		#endif
	}

	[DllImport("__Internal")]
	private static extern void openWindow(string url);
}