using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Nocturnal.Settings;
using Nocturnal.Ui;
using VRC.Core;

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

    }
    }
