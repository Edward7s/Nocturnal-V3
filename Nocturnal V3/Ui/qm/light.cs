using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Nocturnal.Ui.qm
{
    internal class light
    {
        private static GameObject s_headLightGameObj { get; set; }
        private static Light s_headLightComponent { get; set; }

        private static GameObject s_LightGameObj { get; set; }
        private static Light s_LightComponent { get; set; }

        internal static void start()
        {
            var Light = submenu.Create("Light", Main.s_mainpage);
            new Submenubutton(Main.s_menuBase.Getmenu(), "Light", Light);

            new NToggle("Head Light", Light.Getmenu(), () =>
             {
                 s_headLightGameObj = new GameObject("Light");
                 s_headLightComponent = s_headLightGameObj.AddComponent<Light>();
                 s_headLightComponent.type = LightType.Spot;
                 s_headLightComponent.range = Settings.ConfigVars.HeadLightRange * 30;
                 s_headLightComponent.spotAngle = Settings.ConfigVars.HeadLightAngle * 120;
                 s_headLightComponent.intensity = Settings.ConfigVars.HeadLightIntensity * 12;
                 s_headLightComponent.color = new Color(Settings.ConfigVars.HeadLightColor[0], Settings.ConfigVars.HeadLightColor[1], Settings.ConfigVars.HeadLightColor[2]);
                 s_headLightGameObj.transform.parent = VRC.Player.prop_Player_0.transform.Find("AnimationController/HeadAndHandIK/HeadEffector").transform;
                 s_headLightGameObj.transform.localPosition = Vector3.zero;
                 s_headLightGameObj.transform.localEulerAngles = Vector3.zero;
                 s_headLightGameObj.transform.localScale = Vector3.one;
             }, () =>
             {
                 try
                 {
                     if (s_headLightGameObj != null)
                         GameObject.Destroy(s_headLightGameObj);
                 }
                 catch { }
             });
            new NToggle("Light", Light.Getmenu(), () =>
            {
                s_LightGameObj =  GameObject.CreatePrimitive(PrimitiveType.Sphere);
                s_LightGameObj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                s_LightGameObj.AddComponent<Rigidbody>().isKinematic = true;
                s_LightGameObj.AddComponent<VRC.SDK3.Components.VRCPickup>();
                s_LightComponent = s_LightGameObj.AddComponent<Light>();
                s_LightComponent.type = LightType.Point;
                s_LightComponent.intensity = Settings.ConfigVars.LightIntensity * 12;
                s_LightComponent.range = Settings.ConfigVars.LightRange * 30;
                s_LightComponent.color = new Color(Settings.ConfigVars.LightColor[0], Settings.ConfigVars.LightColor[1], Settings.ConfigVars.LightColor[2]);
                s_LightGameObj.transform.position = VRC.Player.prop_Player_0.transform.Find("AnimationController/HeadAndHandIK/RightEffector/PickupJointRightHand").transform.position;
            }, () =>
            {
                try
                {
                    if (s_LightGameObj != null)
                        GameObject.Destroy(s_LightGameObj);
                }
                catch { }
            });

              new Apis.Slider(Light.Getmenu(), x => Settings.ConfigVars.HeadLightColor[0] = x, Settings.ConfigVars.HeadLightColor[0], () =>
              {
                  try
                  {
                      if (s_headLightComponent != null)
                          s_headLightComponent.color = new Color(Settings.ConfigVars.HeadLightColor[0], Settings.ConfigVars.HeadLightColor[1], Settings.ConfigVars.HeadLightColor[2]);
                  }
                  catch { }      
              },true,"Head Light Color R");
            new Apis.Slider(Light.Getmenu(), x => Settings.ConfigVars.HeadLightColor[1] = x, Settings.ConfigVars.HeadLightColor[1], () =>
            {
                try
                {
                    if (s_headLightComponent != null)
                        s_headLightComponent.color = new Color(Settings.ConfigVars.HeadLightColor[0], Settings.ConfigVars.HeadLightColor[1], Settings.ConfigVars.HeadLightColor[2]);
                }
                catch { }
            }, true, "Head Light Color G");
            new Apis.Slider(Light.Getmenu(), x => Settings.ConfigVars.HeadLightColor[2] = x, Settings.ConfigVars.HeadLightColor[2], () =>
            {
                try
                {
                    if (s_headLightComponent != null)
                        s_headLightComponent.color = new Color(Settings.ConfigVars.HeadLightColor[0], Settings.ConfigVars.HeadLightColor[1], Settings.ConfigVars.HeadLightColor[2]);
                }
                catch { }
            }, true, "Head Light Color B");

            new Apis.Slider(Light.Getmenu(), x => Settings.ConfigVars.HeadLightRange = x, Settings.ConfigVars.HeadLightRange, () =>
            {
                try
                {
                    if (s_headLightComponent != null)
                        s_headLightComponent.range = Settings.ConfigVars.HeadLightRange  * 30;
                }
                catch { }
            }, true, "Head Light Range");

            new Apis.Slider(Light.Getmenu(), x => Settings.ConfigVars.HeadLightIntensity = x, Settings.ConfigVars.HeadLightIntensity, () =>
            {
                try
                {
                    if (s_headLightComponent != null)
                        s_headLightComponent.intensity = Settings.ConfigVars.HeadLightIntensity * 12;
                }
                catch { }
            }, true, "Head Light Intensity");

            new Apis.Slider(Light.Getmenu(), x => Settings.ConfigVars.HeadLightAngle = x, Settings.ConfigVars.HeadLightAngle, () =>
            {
                try
                {
                    if (s_headLightComponent != null)
                        s_headLightComponent.intensity = Settings.ConfigVars.HeadLightAngle * 120;
                }
                catch { }
            }, true, "Head Light Angle");


            new Apis.Slider(Light.Getmenu(), x => Settings.ConfigVars.LightColor[0] = x, Settings.ConfigVars.LightColor[0], () =>
            {
                try
                {
                    if (s_LightComponent != null)
                        s_LightComponent.color = new Color(Settings.ConfigVars.LightColor[0], Settings.ConfigVars.LightColor[1], Settings.ConfigVars.LightColor[2]);
                }
                catch { }
            }, true, "Light Color R");

            new Apis.Slider(Light.Getmenu(), x => Settings.ConfigVars.LightColor[1] = x, Settings.ConfigVars.LightColor[1], () =>
            {
                try
                {
                    if (s_LightComponent != null)
                        s_LightComponent.color = new Color(Settings.ConfigVars.LightColor[0], Settings.ConfigVars.LightColor[1], Settings.ConfigVars.LightColor[2]);
                }
                catch { }
            }, true, "Light Color G");

            new Apis.Slider(Light.Getmenu(), x => Settings.ConfigVars.LightColor[2] = x, Settings.ConfigVars.LightColor[2], () =>
            {
                try
                {
                    if (s_LightComponent != null)
                        s_LightComponent.color = new Color(Settings.ConfigVars.LightColor[0], Settings.ConfigVars.LightColor[1], Settings.ConfigVars.LightColor[2]);
                }
                catch { }
            }, true, "Light Color B");

            new Apis.Slider(Light.Getmenu(), x => Settings.ConfigVars.LightIntensity = x, Settings.ConfigVars.LightIntensity, () =>
            {
                try
                {
                    if (s_LightComponent != null)
                        s_LightComponent.intensity = Settings.ConfigVars.LightIntensity * 12;
                }
                catch { }
            }, true, "Light Intensity");

            new Apis.Slider(Light.Getmenu(), x => Settings.ConfigVars.LightRange = x, Settings.ConfigVars.LightRange, () =>
            {
                try
                {
                    if (s_LightComponent != null)
                        s_LightComponent.range = Settings.ConfigVars.LightRange * 30;
                }
                catch { }
            }, true, "Light Range");

        }
    }
}
