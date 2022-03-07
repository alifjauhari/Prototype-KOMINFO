using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class linkig : MonoBehaviour
{
    public void ig_A1_SOCTRAVO()
	{
		#if !UNITY_EDITOR
		openWindow("https://www.instagram.com/soc.trav/");
		#endif
	}

	public void ig_A2_BLOKKAYU()
	{
		#if !UNITY_EDITOR
		openWindow("https://www.instagram.com/arsitekturkayumodular/");
		#endif
	}

	public void ig_A3_IROASTERBIK()
	{
		#if !UNITY_EDITOR
		openWindow("https://www.instagram.com/iroasterbik/");
		#endif
	}

	public void ig_A4_NIUVA()
	{
		#if !UNITY_EDITOR
		openWindow("https://www.instagram.com/niuva.id/");
		#endif
	}

	public void ig_A5_LINGGIS()
	{
		#if !UNITY_EDITOR
		openWindow("https://www.instagram.com/linggis.co/");
		#endif
	}

	public void ig_A6_SIHEDAF()
	{
		#if !UNITY_EDITOR
		openWindow("https://wa.me/62811200412");
		#endif
	}

	public void ig_A7_TRAINO()
	{
		#if !UNITY_EDITOR
		openWindow("https://www.instagram.com/traino.id/");
		#endif
	}

	public void ig_A8_DJAVASTRAAT()
	{
		#if !UNITY_EDITOR
		openWindow("https://www.instagram.com/djavastraat.id/");
		#endif
	}

	public void ig_A9_CUBESTUDIO()
	{
		#if !UNITY_EDITOR
		openWindow("https://www.instagram.com/cubestudio.id/");
		#endif
	}

	public void ig_A10_NIAGANAESIA()
	{
		#if !UNITY_EDITOR
		openWindow("https://www.instagram.com/niaganesia.official/");
		#endif
	}

	public void ig_A11_BYTANI()
	{
		#if !UNITY_EDITOR
		openWindow("https://www.instagram.com/bytani.id/");
		#endif
	}


	[DllImport("__Internal")]
	private static extern void openWindow(string url);
}