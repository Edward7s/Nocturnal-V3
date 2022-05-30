﻿using Nocturnal.Apis;
using UnityEngine;
using UnityEngine.UI;
namespace Nocturnal.Ui
{
	internal class LoadingScreen
	{
		public static void Run()
		{
			//  var loadingbar = GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/Loading Elements/LOADING_BAR_BG").gameObject.GetComponent<UnityEngine.UI.Image>();
			//    MelonLoader.MelonCoroutines.Start(Apis.Change_Image.LoadIMGTSprite(loadingbar, "https://nocturnal-client.xyz/Resources/LoadingBar.png"));
			//     loadingbar.color = Color.white;
			//    loadingbar.transform.localScale = new Vector3(1.3f, 4.6f, 1);
			//     var loadingbarp = GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/Loading Elements/LOADING_BAR").gameObject.GetComponent<UnityEngine.UI.Image>();
			//    loadingbarp.sprite = null;
			//    loadingbarp.color = new Color(0.15f,0.15f,0.15f,0.72f);
			//    loadingbarp.transform.localScale = new Vector3(1.25f, 3.66f, 1);
			GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/Loading Elements/txt_Percent").transform.localPosition = new Vector3(-98.0401f, 115.42f, 0);
			//  GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/Loading Elements/txt_LOADING_Size").transform.localPosition = new Vector3(201.4574f, 115.55f, 1);
			GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup/3DElements/LoadingInfoPanel").gameObject.SetActive(false);
			GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup/3DElements/LoadingBackground_TealGradient/SkyCube_Baked").gameObject.SetActive(false);
			var vrclogo = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Authentication/StoreLoginPrompt/VRChat_LOGO (1)").gameObject;
			vrclogo.Loadfrombytes(Settings.DownloadFiles.logo);
			GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/RingGlow").GetComponent<UnityEngine.UI.Image>().color = Color.black;
			GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/Rectangle").gameObject.SetActive(false);
			GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/InnerDashRing").GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, 0.8f);
			GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/MidRing").GetComponent<UnityEngine.UI.Image>().color = new Color(0.68f, 071, 1, 0.8f);
			GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/ProgressLine").GetComponent<UnityEngine.UI.Image>().color = new Color(0.68f, 071, 1, 0.8f);
			GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/TitleText").GetComponent<UnityEngine.UI.Text>().color = new Color(0.68f, 071, 1, 0.8f);
			GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/TitleText").GetComponent<UnityEngine.UI.Outline>().enabled = false;
			GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/TitleText").GetComponent<UnityEngine.UI.Text>().color = new Color(0.68f, 071, 1, 0.8f);
			GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/ArrowRight").gameObject.SetActive(false);
			GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/ArrowLeft").gameObject.SetActive(false);
			GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/BodyText").GetComponent<UnityEngine.UI.Text>().color = new Color(0.68f, 071, 1, 0.8f);
			GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/HighPercent").GetComponent<UnityEngine.UI.Text>().color = new Color(0.68f, 071, 1, 0.8f);
			GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/LowPercent").GetComponent<UnityEngine.UI.Text>().color = new Color(0.68f, 071, 1, 0.8f);
			var cbt = GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/ButtonMiddle").GetComponent<UnityEngine.UI.Button>();
			ColorBlock cb = cbt.colors;
			cb.normalColor = new Color((float)0, 0, 0, 1 - 0.4f);
			cb.highlightedColor = new Color((float)0, 0, 0, 1 - 0.1f);
			cb.pressedColor = new Color((float)0, 0, 0, 1);
			cb.disabledColor = new Color((float)0, 0, 0, 1 - 0.7f);
			cb.selectedColor = new Color((float)0, 0, 0, 1 - 0.2f);
			cbt.colors = cb;

			GameObject.Find("/UserInterface").transform.Find("LoadingBackground_TealGradient_Music/SkyCube_Baked").gameObject.SetActive(false);
			GameObject.Find("/UserInterface").transform.Find("LoadingBackground_TealGradient_Music/LoadingSound").gameObject.SetActive(false);
		}
	}
}
