using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class linkwa : MonoBehaviour 
{
	public void wa_A1_Soctravo()
	{
		#if !UNITY_EDITOR
		openWindow("https://wa.me/62895708740706");
		#endif
	}

	public void wa_A2_BlokKayuModular()
	{
		#if !UNITY_EDITOR
		openWindow("https://wa.me/6285725648628");
		#endif
	}

	public void wa_A3_IROASTERBIK()
	{
		#if !UNITY_EDITOR
		openWindow("https://wa.me/6285659858644");
		#endif
	}

	public void wa_A4_NIUVA()
	{
		#if !UNITY_EDITOR
		openWindow("https://wa.me/6285216096961");
		#endif
	}

	public void wa_A5_LIGGIS()
	{
		#if !UNITY_EDITOR
		openWindow("https://wa.me/6281386244550");
		#endif
	}

	public void wa_A6_SIHEDAF()
	{
		#if !UNITY_EDITOR
		openWindow("https://wa.me/6282120481404");
		#endif
	}

	public void wa_A7_TRAINO()
	{
		#if !UNITY_EDITOR
		openWindow("https://wa.me/6281122339963");
		#endif
	}

	public void wa_A8_DJAVASTRAAT()
	{
		#if !UNITY_EDITOR
		openWindow("https://wa.me/6282120184516");
		#endif
	}

	public void wa_A9_CUBESTUDIO()
	{
		#if !UNITY_EDITOR
		openWindow("https://wa.me/6281221531239");
		#endif
	}

	public void wa_A10_NIAGANESIA()
	{
		#if !UNITY_EDITOR
		openWindow("https://wa.me/6282319513020");
		#endif
	}

	public void wa_A11_BYTANI()
	{
		#if !UNITY_EDITOR
		openWindow("https://wa.me/6282117194909");
		#endif
	}


	[DllImport("__Internal")]
	private static extern void openWindow(string url);
}