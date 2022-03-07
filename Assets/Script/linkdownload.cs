using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class linkdownload : MonoBehaviour
{
	public void dw_Blockwood()
	{
		#if !UNITY_EDITOR
		openWindow("https://drive.google.com/uc?export=download&id=1QNWZmXPLSV4k7NVcW10qJKib0CDx4V4q");
		#endif
	}

	public void dw_ByTani()
	{
		#if !UNITY_EDITOR
		openWindow("https://drive.google.com/uc?export=download&id=1sWmTzYWpo4_aULAAkk6zR-pbkFYK7lyW");
		#endif
	}

	public void dw_CubeStudio()
	{
		#if !UNITY_EDITOR
		openWindow("https://drive.google.com/uc?export=download&id=1pSnQONNpjqzXBEj8_0pFZPF9zhiZ2hSq");
		#endif
	}

	public void dw_Djavastraat ()
	{
		#if !UNITY_EDITOR
		openWindow("https://drive.google.com/uc?export=download&id=1Iu2d5xQTe1kHr35ODB-cIdNzb5eYT3hs");
		#endif
	}

	public void dw_IRoasterbik()
	{
		#if !UNITY_EDITOR
		openWindow("https://drive.google.com/uc?export=download&id=1tGYGR_PelH6OFGdN2SE9qPQDY6o47FdP");
		#endif
	}

	public void dw_Linggis ()
	{
		#if !UNITY_EDITOR
		openWindow("https://drive.google.com/uc?export=download&id=1vTL5q3ZDw3nKQmxo3Jf0AuC6CU3c-4hT");
		#endif
	}

	public void dw_Niaganesia ()
	{
		#if !UNITY_EDITOR
		openWindow("https://drive.google.com/uc?export=download&id=1xqgEGHv1VA5OdmzTy93xNHEca0BE6znd");
		#endif
	}

	public void dw_Niuva ()
	{
		#if !UNITY_EDITOR
		openWindow("https://drive.google.com/uc?export=download&id=13fRKozvsAZ38yuHv4FZlxE4hhnG_vtlc");
		#endif
	}

	public void dw_Sihedaf ()
	{
		#if !UNITY_EDITOR
		openWindow("https://drive.google.com/uc?export=download&id=1gNr0H76J_Yf6V79rYPWd2fe5avu4uEgn");
		#endif
	}

	public void dw_Soctravo ()
	{
		#if !UNITY_EDITOR
		openWindow("https://drive.google.com/uc?export=download&id=1oAe2lq4fE75UBcMD6GlQq0ac4p-LhpoB");
		#endif
	}

	public void dw_Traino ()
	{
		#if !UNITY_EDITOR
		openWindow("https://drive.google.com/uc?export=download&id=1pnLJwgf7-cL4OCqGj-e-MOEWIpDZZB0g");
		#endif
	}

	[DllImport("__Internal")]
	private static extern void openWindow(string url);
}