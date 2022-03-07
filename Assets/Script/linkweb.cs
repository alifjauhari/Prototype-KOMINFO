using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;


public class linkweb : MonoBehaviour
{
	public void Web_A1_SOCTRAVO()
	{
		#if !UNITY_EDITOR
		openWindow("https://www.soctrav.com");
		#endif
	}

	public void Web_A2_BLOKKAYU()
	{
		#if !UNITY_EDITOR
		openWindow("https://blokkayumodular.com/");
		#endif
	}

	public void Web_A3_IROASTERBIK()
	{
		#if !UNITY_EDITOR
		openWindow("https://i-roasterbik.com/");
		#endif
	}

	public void Web_A4_NIUVA()
	{
		#if !UNITY_EDITOR
		openWindow("https://wa.me/62811200412");
		#endif
	}

	public void Web_A5_LINGGIS()
	{
		#if !UNITY_EDITOR
		openWindow("https://linggis.com");
		#endif
	}

	public void Web_A6_SIHEDAF()
	{
		#if !UNITY_EDITOR
		openWindow("http://telemedicine.co.id");
		#endif
	}

	public void Web_A7_TRAINO()
	{
		#if !UNITY_EDITOR
		openWindow("https://www.traino.id/en");
		#endif
	}

	public void Web_A8_DJAVASTRAAT()
	{
		#if !UNITY_EDITOR
		openWindow("https://www.instagram.com/djavastraat.id/?hl=en");
		#endif
	}

	public void Web_A9_CUBESTUDIO()
	{
		#if !UNITY_EDITOR
		openWindow("https://cubestudio.id/");
		#endif
	}

	public void Web_A10_NIAGANESIA()
	{
		#if !UNITY_EDITOR
		openWindow("www.niaganesia.com");
		#endif
	}

	public void Web_A11_BYTANI()
	{
		#if !UNITY_EDITOR
		openWindow("https://bytani.id/");
		#endif
	}


	[DllImport("__Internal")]
	private static extern void openWindow(string url);
}
