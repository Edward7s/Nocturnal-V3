using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Nocturnal.Apis.bigui;
using System.Windows.Forms;
namespace Nocturnal.Ui
{
    internal class Biguiscrollbar
    {
        internal static void setscrollbars()
        {
            var socialv = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social/Vertical Scroll View");
            var scrollbarsocial = Custom_ScrollBar.Scroll(socialv.gameObject, -78, 0.4f, 1.1f, 0.95f);
            socialv.GetComponent<ScrollRect>().verticalScrollbar = scrollbarsocial;


            var pannelvolumes = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Settings/VolumePanel").gameObject;
            var volm = pannelvolumes.transform.Find("VolumeMaster").transform;
            volm.localScale = new Vector3(0.8f, 1, 1);
            volm.localPosition = new Vector3(-49.97f, -110.62f, 0);
            pannelvolumes.transform.Find("VolumeMaster/Label").transform.localScale = new Vector3(1.2f, 1, 1);
            pannelvolumes.transform.Find("VolumeUi").transform.localPosition = new Vector3(-49.97f, - 155.1192f, 1);
            pannelvolumes.transform.Find("VolumeGameWorld").transform.localPosition = new Vector3(-49.97f, -200.165f ,1);
            pannelvolumes.transform.Find("VolumeGameVoice").transform.localPosition = new Vector3(-49.97f,-244.2013f, 1);
            pannelvolumes.transform.Find("VolumeGameAvatars").transform.localPosition = new Vector3(-49.97f, -289.0635f, 1);
            pannelvolumes.transform.Find("VolumeMaster/SliderLabel").transform.localScale = new Vector3(1.2f,1,1);
            pannelvolumes.transform.Find("VolumeMaster/SliderLabel").transform.localPosition = new Vector3(136.0805f, 20, -1);
            pannelvolumes.transform.Find("Panel_Header Side").transform.localScale = new Vector3(1,1.5f,  1);
            pannelvolumes.transform.Find("Panel_Header Side").transform.localPosition = new Vector3(-186.8599f, -75f, 1);
            var sld =  Apis.Slider.slider(pannelvolumes.gameObject, value => Settings.ConfigVars.clientvolume = value, Settings.ConfigVars.clientvolume,()=> 
            {
                var qmaudio = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").gameObject.GetComponent<AudioSource>();
                qmaudio.volume = Settings.ConfigVars.clientvolume;
                Ui.Qm_basic._audiosourcenotification.volume = Settings.ConfigVars.clientvolume / 6;
            });
            sld.transform.localPosition = new Vector3(-50.7518f, -333.4202f, 1);
            var sldtitle = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Settings/VolumePanel/VolumeGameAvatars/Label").gameObject;
            var titleinst = GameObject.Instantiate(sldtitle, sldtitle.transform);
            titleinst.GetComponent<Text>().text = "Client";
            titleinst.transform.localPosition = new Vector3(36.5451f, -40.2389f, 0);

            //inputextfield
           var btn = GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/InputPopup").gameObject;
          var buttonclipboard =  Apis.bigui.BButton.NormalButton("ClipBoard", btn, () =>
              {
                  var inpf = GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/InputPopup/InputField").gameObject.GetComponent<InputField>();
                  var text = Clipboard.GetText();
                  for (int i = 0; i < text.Length; i++)
                  {
                      inpf.Insert(text[i]);
                  }

              });
            buttonclipboard.transform.localPosition = new Vector3(-439.7326f, -280.46f, 0);
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social/Vertical Scroll View/Viewport").transform.localScale = new Vector3(1,1.05f,1);
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content").transform.localScale = new Vector3(1, 0.95f, 1);

        }


    }
}
