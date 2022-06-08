using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Nocturnal.Apis;
namespace Nocturnal.Ui
{
    internal class LoadingScreen
    {
        public static void runti()
        {
         
          
          //  var loadingbar = GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/Loading Elements/LOADING_BAR_BG").gameObject.GetComponent<Image>();
        //    MelonLoader.MelonCoroutines.Start(Apis.Change_Image.LoadIMGTSprite(loadingbar, "https://nocturnal-client.xyz/Resources/LoadingBar.png"));
       //     loadingbar.color = Color.white;
        //    loadingbar.transform.localScale = new Vector3(1.3f, 4.6f, 1);
       //     var loadingbarp = GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/Loading Elements/LOADING_BAR").gameObject.GetComponent<Image>();
        //    loadingbarp.sprite = null;
        //    loadingbarp.color = new Color(0.15f,0.15f,0.15f,0.72f);
        //    loadingbarp.transform.localScale = new Vector3(1.25f, 3.66f, 1);
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/Loading Elements/txt_Percent").transform.localPosition = new Vector3(-98.0401f, 115.42f, 0);
          //  GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/Loading Elements/txt_LOADING_Size").transform.localPosition = new Vector3(201.4574f, 115.55f, 1);
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup/3DElements/LoadingInfoPanel").gameObject.SetActive(false);
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup/3DElements/LoadingBackground_TealGradient/SkyCube_Baked").gameObject.SetActive(false);
            var vrclogo = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Authentication/StoreLoginPrompt/VRChat_LOGO (1)").gameObject;
            vrclogo.Loadfrombytes(Settings.Download_Files.imagehandler.logo);
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/RingGlow").GetComponent<Image>().color = Color.black;
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/Rectangle").gameObject.SetActive(false);
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/InnerDashRing").GetComponent<Image>().color =new Color(0,0,0,0.8f);
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/MidRing").GetComponent<Image>().color = Color.red;
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/ProgressLine").GetComponent<Image>().color = Color.red;
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/TitleText").GetComponent<Text>().color = Color.red;
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/TitleText").GetComponent<Outline>().enabled = false;
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/TitleText").GetComponent<Text>().color = Color.red;
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/ArrowRight").gameObject.SetActive(false);
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/ArrowLeft").gameObject.SetActive(false);
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/BodyText").GetComponent<Text>().color = Color.red;
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/HighPercent").GetComponent<Text>().color = Color.red;
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/LowPercent").GetComponent<Text>().color = Color.red;
            var cbt = GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/StandardPopup/ButtonMiddle").GetComponent<Button>();
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
