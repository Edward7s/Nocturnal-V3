using System.Linq;
using UnityEngine;

namespace Nocturnal.Ui
{
	internal class Bundles
	{
		internal static Shader outlineShader = null;
		internal static GameObject clientMessage = null;
		internal static GameObject joinNotification = null;

		internal static void LoadNotifications()
		{
			var myLoadedAssetBundle = AssetBundle.LoadFromMemory(Settings.DownloadFiles.uiNotifications);
			if (myLoadedAssetBundle == null)
			{
				NocturnalConsole.Log("Failed to load AssetBundle!");
				return;
			}
			var uim = myLoadedAssetBundle.LoadAsset<GameObject>("ui");
			myLoadedAssetBundle.Unload(false);

			var gmj = GameObject.Instantiate(uim, GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old").transform);

			gmj.transform.localScale = Vector3.one;
			gmj.transform.localPosition = Vector3.zero;
			gmj.transform.localEulerAngles = Vector3.zero;
			var canvas = gmj.transform.Find("Canvas").transform;
			canvas.localScale = new Vector3(1.1f, 1.1f, 1);
			canvas.transform.Find("message").transform.localScale = new Vector3(2, 2, 1);
			canvas.transform.Find("message").transform.localPosition = new Vector3(0, 280, 0);
			canvas.transform.Find("Join").transform.localScale = new Vector3(1.2f, 1.2f, 1);
			canvas.transform.Find("Join").transform.localPosition = new Vector3(0, -420, 0);
			Component.DestroyImmediate(canvas.GetComponent<UnityEngine.Canvas>());
			clientMessage = canvas.transform.Find("message").gameObject;
			joinNotification = canvas.transform.Find("Join").gameObject;
			clientMessage.SetActive(false);
			joinNotification.SetActive(false);
		}

		internal static void LoadingScreen()
		{

			var myLoadedAssetBundle = AssetBundle.LoadFromMemory(Settings.DownloadFiles.loadingScreen);
			if (myLoadedAssetBundle == null)
			{
				NocturnalConsole.Log("Failed to load AssetBundle!");
				return;
			}
			var loadinscreen = myLoadedAssetBundle.LoadAsset<GameObject>("loadingscreen");
			myLoadedAssetBundle.Unload(false);
			GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup/3DElements/LoadingBackground_TealGradient").gameObject.SetActive(false);
			var gmj = GameObject.Instantiate(loadinscreen, GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup").transform);
			gmj.transform.localPosition = new Vector3(0, 0, 30000);
			gmj.transform.Find("GameObjectanim").transform.localPosition = new Vector3(0, 7000, 0);
			gmj.transform.Find("finished (1)").transform.localPosition = new Vector3(0, -2800, 0);
			gmj.transform.Find("wings").transform.localPosition = new Vector3(0, 1500, 0);
			gmj.transform.Find("Particle System (2)").transform.localPosition = new Vector3(0, -8000, -9000);
			gmj.transform.Find("Particle System (1)").transform.localPosition = new Vector3(0, -0, 9000);
			gmj.transform.Find("Particle System").transform.localPosition = new Vector3(0, -1500f, -30000);
			GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup/3DElements").transform.localScale = new Vector3(1, 1, 1);


			var particles = gmj.GetComponentsInChildren<ParticleSystem>(true);
			for (int i = 0; i < particles.Length; i++)
			{
				particles[i].startColor = new Color(Settings.ConfigVars.HuDColor[0], Settings.ConfigVars.HuDColor[1], Settings.ConfigVars.HuDColor[2]);
			}
			var aud = GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/LoadingPopup/LoadingSound").gameObject.GetComponent<UnityEngine.AudioSource>(); ;

			MelonLoader.MelonCoroutines.Start(Settings.Wrappers.Extensions.LoadAudio(aud, Settings.DownloadFiles.loadingScreenMusicPath));
		}

		internal static void LoadShader()
		{

			var myLoadedAssetBundle = AssetBundle.LoadFromMemory(Settings.DownloadFiles.shaderESP);
			if (myLoadedAssetBundle == null)
			{
				NocturnalConsole.Log("Failed to load AssetBundle!");
				return;
			}
			var shadergmj = myLoadedAssetBundle.LoadAsset<GameObject>("shdaers");
			myLoadedAssetBundle.Unload(false);
			var gmj = GameObject.Instantiate(shadergmj, GameObject.Find("/UserInterface").transform);
			outlineShader = gmj.transform.Find("Capsule").gameObject.GetComponent<MeshRenderer>().materials.FirstOrDefault<Material>().shader;
			gmj.SetActive(false);

		}
		internal static void LoadRain()
		{
			var myLoadedAssetBundle = AssetBundle.LoadFromMemory(Settings.DownloadFiles.rain);
			if (myLoadedAssetBundle == null)
			{
				NocturnalConsole.Log("Failed to load AssetBundle!");
				return;
			}
			var rain = myLoadedAssetBundle.LoadAsset<GameObject>("Rain");
			myLoadedAssetBundle.Unload(false);

			var gmj = GameObject.Instantiate(rain, GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop").transform);
			var path = GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop").gameObject;
			path.transform.Find("Background").gameObject.GetComponent<UnityEngine.UI.Image>().material.renderQueue = 2000;
			var maskgmj = new GameObject("Rain");
			maskgmj.transform.parent = path.transform;

			maskgmj.transform.localPosition = new Vector3(0, -0.5f, 0);
			maskgmj.transform.localRotation = new Quaternion(0, 0, 0, 0);
			maskgmj.transform.localScale = new Vector3(20, 11.5f, 1f);
			path.transform.Find("Background").gameObject.SetActive(false);
			var imgm = maskgmj.gameObject.AddComponent<UnityEngine.UI.Image>();
			imgm.raycastTarget = false;
			var msdk = maskgmj.AddComponent<UnityEngine.UI.Mask>();
			msdk.showMaskGraphic = false;
			MelonLoader.MelonCoroutines.Start(Apis.ChangeImage.LoadIMGTSprite(imgm, "https://nocturnal-client.xyz/Resources/Mask.png"));
			var bg = GameObject.Instantiate(imgm, imgm.transform);
			Component.DestroyImmediate(bg.GetComponent<UnityEngine.UI.Mask>());
			MelonLoader.MelonCoroutines.Start(Apis.ChangeImage.LoadIMGTSprite(bg.GetComponent<UnityEngine.UI.Image>(), Settings.ConfigVars.BiguiImg));
			bg.GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, Settings.ConfigVars.BigImgOpacity);
			bg.transform.localPosition = Vector3.zero;
			bg.transform.localScale = Vector3.one;
			var rains = gmj.transform.Find("Image").transform;
			rains.transform.parent = bg.transform.parent;
			rains.transform.localScale = Vector3.one;
			rains.transform.localPosition = Vector3.zero;
			var matts = rains.GetComponent<UnityEngine.UI.Image>().material;
			matts.EnableKeyword("_y");
			matts.EnableKeyword("_x");
			matts.SetFloat("_y", 4f);
			matts.SetFloat("_x", 5f);
			float screenthunder = Settings.ConfigVars.thunderbigui ? 1 : 0;
			matts.EnableKeyword("postpr");
			matts.SetFloat("postpr", screenthunder);
			rains.gameObject.SetActive(Settings.ConfigVars.rainbackground);
		}
	}
}
