using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Nocturnal.Settings;
using Nocturnal.Ui;
using VRC.Core;
using System.IO;
using Newtonsoft.Json;

namespace Nocturnal.Apis
{
    internal class AvatarFav
    {
        internal static Dictionary<string, string> _MenuAndAvi = new Dictionary<string,string>(); 
        private GameObject _Pannel { get; set; }
        private GameObject _NewMenu { get; set; }
        public GameObject _Content { get; set; }
        public UnityEngine.UI.ScrollRect _ScrollRect { get; set; }

        private UnityEngine.UI.GridLayoutGroup _GridLayout { get; set; }

        private UnityEngine.UI.LayoutElement _Layout { get; set; } 

        private Il2CppSystem.Collections.Generic.List<VRC.Core.ApiModel> _AvatarsList { get; set; }

        ~AvatarFav()
        {
            this._AvatarsList = null;
            this._Layout = null;
            this._NewMenu = null;
            this._Pannel = null;
            this._GridLayout = null;
            this._Button = null;
            this._ButtonText = null;
            this._ButtonTextComp = null;
            this._Scrollbar = null;
            System.GC.Collect();
        }

        public AvatarFav(string _name)
        {
            _Pannel = GameObject.Instantiate(Objects._Favorite, Objects._Favorite.transform.parent);
            Component.Destroy(_Pannel.GetComponent<UiAvatarList>());
            _Pannel.name = "NF_" + _name;
            _Pannel.AddComponent<UnityEngine.UI.Image>();
            _Pannel.AddComponent<UnityEngine.UI.Mask>().showMaskGraphic = false;
            _Layout = _Pannel.GetComponent<UnityEngine.UI.LayoutElement>();
            _Layout.minHeight = 200;
            GameObject.DestroyImmediate(_Pannel.transform.Find("ViewPort").gameObject);
            _Pannel.transform.SetSiblingIndex(0);
            GameObject.DestroyImmediate(_Pannel.transform.Find("Button/TitleText").gameObject);
            GameObject.DestroyImmediate(_Pannel.transform.Find("Button/ToggleIcon").gameObject);
            _NewMenu = GameObject.Instantiate(_Pannel.transform.Find("Button").gameObject, _Pannel.transform);
            Component.DestroyImmediate(_NewMenu.GetComponent<UnityEngine.UI.Button>());
            Component.DestroyImmediate(_NewMenu.GetComponent<ButtonReaction>());
            _NewMenu.transform.localPosition = new Vector3(-646f, 0, 0f);
            _NewMenu.transform.localScale = new Vector3(1f, 2.23f, 1);
            _NewMenu.transform.Find("Panel").transform.localPosition = new Vector3(450, 7.7f, 0);
            _Content = GameObject.Instantiate(_NewMenu, _NewMenu.transform);
            _Content.name = "Content";
            _Content.transform.localPosition = Vector3.zero;
            GameObject.DestroyImmediate(_Content.transform.Find("Panel").gameObject);
            _Content.transform.localScale = Vector3.one;
            _Content.AddComponent<UnityEngine.UI.ContentSizeFitter>();
            _GridLayout = _Content.AddComponent<UnityEngine.UI.GridLayoutGroup>();
            _GridLayout.constraint = UnityEngine.UI.GridLayoutGroup.Constraint.FixedRowCount;
            _GridLayout.constraintCount = 1;
            _GridLayout.cellSize = new Vector2(150, 50);
            _GridLayout.spacing = new Vector2(2, 0);   
            new Apis.bigui.Toggle(_Pannel.transform.Find("Button").transform, _name, () => {
                _Layout.minHeight = 200;
                _NewMenu.SetActive(true);
            }, () =>
            {
                _Layout.minHeight = 60;
                _NewMenu.SetActive(false);
            }, new Vector3(-131, -3, 0));
            _Layout.minHeight = 60;
            _NewMenu.SetActive(false);
            Component.DestroyImmediate(_Pannel.gameObject.GetComponent<ScrollRectEx>());
            _ScrollRect = _NewMenu.gameObject.AddComponent<UnityEngine.UI.ScrollRect>();

       //     _ScrollRect.movementType = UnityEngine.UI.ScrollRect.MovementType.Unrestricted;
         //   _ScrollRect.vertical = false;
      //      _ScrollRect.horizontal = true;
            //_ScrollRect.scrollSensitivity = 0.3f;
            _Scrollbar = bigui.Custom_ScrollBar.Scroll(_Pannel, 0, 0, 0.7f, 4);
            _Scrollbar.transform.localEulerAngles = new Vector3(0, 0, 90);
            _Scrollbar.transform.localPosition = new Vector3(-268.4155f, - 89, 1);
            _ScrollRect.horizontalScrollbar = _Scrollbar;
            _ScrollRect.content = _Content.GetComponent<RectTransform>();
            _ScrollRect.vertical = false;
            _Content.AddComponent<UnityEngine.UI.ContentSizeFitter>().horizontalFit = UnityEngine.UI.ContentSizeFitter.FitMode.MinSize;
        }

        private UnityEngine.UI.Scrollbar _Scrollbar { get; set; }

        private GameObject _Button { get; set; }
        private GameObject _ButtonText { get; set; }
        private TMPro.TextMeshProUGUI _ButtonTextComp { get; set; }


        public AvatarFav(GameObject Menu, string id)
        {
            if (Menu.GetComponentsInChildren<UnityEngine.UI.Button>().Where(mn => mn.name == id).FirstOrDefault() == null) return;
            else GameObject.DestroyImmediate(Menu.GetComponentsInChildren<UnityEngine.UI.Button>().Where(mn => mn.name == id).FirstOrDefault().gameObject);
        }

        public AvatarFav(GameObject Menu,string id, string name, string platform, string img,string asseturl)
        {
            if (Menu.GetComponentsInChildren<UnityEngine.UI.Button>().Where(mn => mn.name == id).FirstOrDefault() != null) return;
            _Button = new GameObject(name);
            _Button.name = id;
            _Button.transform.parent = Menu.transform;
            _Button.transform.localScale = Vector3.one;
            _Button.transform.localEulerAngles = Vector3.zero;
            _Button.transform.localPosition = Vector3.zero;
            _Button.AddComponent<UnityEngine.UI.LayoutElement>().preferredWidth = 100;
            _ButtonText = GameObject.Instantiate(_Button, _Button.transform);
            _ButtonTextComp = _ButtonText.AddComponent<TMPro.TextMeshProUGUI>();
            _ButtonTextComp.text = name;
            _ButtonTextComp.alignment = TMPro.TextAlignmentOptions.Center;
            _ButtonTextComp.enableWordWrapping = false;
            _ButtonTextComp.m_enableWordWrapping = false;
            _ButtonTextComp.fontSize = 27;
            switch (platform)
            {
                case "Q":
                    _ButtonTextComp.color = Color.green;
                break;
                case "P":
                    _ButtonTextComp.color = Color.magenta;
                    break;
                case "A":
                    _ButtonTextComp.color = Color.cyan;
                    break;
            }
            _ButtonText.transform.localScale = new Vector3(0.5f, 0.27f, 1);
            _ButtonText.transform.localPosition = new Vector3(0, 30.6f, 0);
            MelonLoader.MelonCoroutines.Start(Apis.Change_Image.LoadIMGTSprite(_Button.AddComponent<UnityEngine.UI.Image>(), img));
            _Button.AddComponent<UnityEngine.UI.Button>().onClick.AddListener(new Action(() => {
                _MenuAndAvi.Clear();
                _MenuAndAvi.Add(id, Menu.transform.parent.parent.name);

                GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Avatar/AvatarPreviewBase/MainRoot/MainModel").gameObject.GetComponent<VRC.SimpleAvatarPedestal>().Method_Private_Void_ApiAvatar_0(new VRC.Core.ApiAvatar()
                {
                    assetUrl = asseturl,
                    id = id,
                });

            }));
      
              
          
            
        }
        private static List<Settings.jsonmanager.Menu> _List = new List<Settings.jsonmanager.Menu>();

        internal static void FavoriteAvatar(VRC.Player user)
        {
            if (user.prop_ApiAvatar_0.releaseStatus != "public")
            {
                Settings.XRefedMethods.PopOutWarrningMessage("U can not favorite a private avatar");
                return;
            }
            Qm_basic._Content.transform.parent.gameObject.SetActive(true);

            Settings.XRefedMethods.PopOutToggle("Select A Favorite List And Press Ok", "", () => {

                var text = JsonConvert.DeserializeObject<List<Settings.jsonmanager.Menu>>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AvatarFav.json"));
                for (int i = 0; i < Favorites._MenuList.Count; i++)
                {
                    _List.Clear();
                    for (int i3 = 0; i3 < text.Count; i3++)
                    {
                        if (text[i3].AviMenu != Favorites._MenuList[i])
                        {
                            _List.Add(text[i3]);
                            continue;
                        }
                        _Id = user.prop_ApiAvatar_0.id;
                        _Name = user.prop_ApiAvatar_0.name;
                        _Img = user.prop_ApiAvatar_0.imageUrl;
                        _AssetBundle = user.prop_ApiAvatar_0.assetUrl;
                        switch (true)
                        {
                            case true when user.prop_ApiAvatar_0.supportedPlatforms == VRC.Core.ApiModel.SupportedPlatforms.Android:
                                _Letter = "Q";
                                break;
                            case true when user.prop_ApiAvatar_0.supportedPlatforms == VRC.Core.ApiModel.SupportedPlatforms.All:
                                _Letter = "A";
                                break;
                            case true when user.prop_ApiAvatar_0.supportedPlatforms == VRC.Core.ApiModel.SupportedPlatforms.StandaloneWindows:
                                _Letter = "P";
                                break;
                        }
                        new Apis.AvatarFav(Objects._Favorite.transform.parent.transform.Find("NF_" + Favorites._MenuList[i] + "/Button(Clone)/Content").gameObject, _Id, _Name, _Letter, _Img, _AssetBundle);
                        var avatar = new Settings.jsonmanager.AvatarFav()
                        {
                            id = _Id,
                            img = _Img,
                            name = _Name,
                            platform = _Letter,
                            url = _AssetBundle,
                        };

                        if (text[i3].Avatars == null)
                        {
                            text[i3].Avatars = new List<Settings.jsonmanager.AvatarFav>();
                            text[i3].Avatars.Add(avatar);
                            _List.Add(text[i3]);
                            continue;
                        }
                        text[i3].Avatars.Add(avatar);
                        _List.Add(text[i3]);
                    }

                }
                if (_List.Count != 0)
                {
                    var cbt = Qm_basic._Content.GetComponentsInChildren<UnityEngine.UI.Toggle>();
                    for (int i = 0; i < cbt.Length; i++)
                    {
                        if (cbt[i].isOn)
                            cbt[i].isOn = false;
                    }
                    File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AvatarFav.json", JsonConvert.SerializeObject(_List));

                }

            },
            () => {
                var cbt = Qm_basic._Content.GetComponentsInChildren<UnityEngine.UI.Toggle>();
                for (int i = 0; i < cbt.Length; i++)
                {
                    if (cbt[i].isOn)
                        cbt[i].isOn = false;
                }
            });
        }

        private static string _Letter { get; set; }

        private static string _AssetBundle { get; set; }

        private static string _Img { get; set; }

        private static string _Name { get; set; }

        private static string _Id { get; set; }
    }
    }
