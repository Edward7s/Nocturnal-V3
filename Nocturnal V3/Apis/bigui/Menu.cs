using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Nocturnal.Ui;
using Nocturnal.Settings.wrappers;
namespace Nocturnal.Apis.bigui
{
    internal class Menu
    {
        private GameObject _menuButon { get; set; }
        private Transform[] _gmjArr { get; set; }
        private VRCUiPageTab _vrcUiPageTab { get; set; }
        private Button _menuButonComp { get; set; }
        private GameObject _mask { get; set; }

        private GameObject _menuGameobject { get; set; }
        public GameObject _menuViewPort { get; set; }
        private ScrollRect _scrollRect { get; set; }
        private GridLayoutGroup _gridLayoutGroup { get; set; }
        private GameObject _text { get; set; }
        private TMPro.TextMeshProUGUI _textComp { get; set; }

        public GameObject Conntent { get; set; }

        public Menu(string menuName,Action action = null)
        {
            _menuGameobject = GameObject.Instantiate(Ui.Objects.s_bigUiTab, Ui.Objects.s_bigUiTab.transform.parent);
            _menuGameobject.name = "NMenu_" + menuName;
            _gmjArr = _menuGameobject.GetComponentsInChildren<Transform>().Where(x => x.gameObject.name != _menuGameobject.name && x.name != "TitlePanel" && x.name != "TitleText").ToArray();
            for (int i = 0; i < _gmjArr.Length; i++)
                GameObject.Destroy(_gmjArr[i].gameObject);

            _menuGameobject.transform.Find("TitlePanel/TitleText").GetComponent<Text>().text = "The " + menuName + " Tab";
            _menuButon = GameObject.Instantiate(Ui.Objects.s_buttonTabBigUi, Ui.Objects.s_buttonTabBigUi.transform.parent);
            _menuButon.transform.SetSiblingIndex(Ui.Objects.s_buttonTabBigUi.transform.GetSiblingIndex() + 1);
            _menuButon.GetComponentInChildren<Text>().text = menuName;
            _menuButon.transform.Find("Button").gameObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(new Action(() => {
                    if (action != null)
                        action.Invoke();

                    _menuGameobject.GetComponent<MonoBehaviour1PublicImTeGaTeObBuObStBuInUnique>().enabled = true;
                }));
            _vrcUiPageTab = _menuButon.GetComponent<VRCUiPageTab>();
            _vrcUiPageTab.field_Public_String_0 = "Nmenu_" + menuName;
            _vrcUiPageTab.field_Public_String_1 = "UserInterface/MenuContent/Screens/NMenu_" + menuName;

        }

        public Menu(Menu menu,string text,Vector3 poz,int constraintCount)
        {
            _menuViewPort = new GameObject("ViewPort");
            _menuViewPort.transform.parent = menu._menuGameobject.transform;
            _menuViewPort.transform.localPosition = poz;
            _menuViewPort.transform.localEulerAngles = Vector3.zero;
            _menuViewPort.transform.localScale = new Vector3(1.1f, 1.1f, 1);
            _scrollRect = _menuViewPort.AddComponent<ScrollRect>();
            _mask = new GameObject("Mask_" + text);
            _mask.transform.parent = _menuViewPort.transform;
            _mask.transform.localScale = new Vector3(4.45f, 7.67f, 1);
            _mask.transform.localPosition = Vector3.zero;
            _mask.transform.localEulerAngles = Vector3.zero;
            _mask.AddComponent<Image>();
            _mask.AddComponent<Mask>().showMaskGraphic = false;
            GameObject mask2 = new GameObject("Holder");
            mask2.transform.parent = _mask.transform;
            mask2.transform.localEulerAngles = Vector3.zero;
            mask2.transform.localPosition = Vector3.zero;
            mask2.transform.localScale = new Vector3(0.16f,0.11f,1);
            Conntent = new GameObject("Content_" + text);
            Conntent.transform.parent = mask2.transform;
            Conntent.transform.localScale = Vector3.one;
            Conntent.transform.localPosition = Vector3.zero;
            Conntent.transform.localEulerAngles = Vector3.zero;
            GameObject Image = GameObject.Instantiate(mask2, mask2.transform.parent);
            Image.AddComponent<Image>().color = new Color(0, 0, 0, 0.8f);
            Image.GetComponent<Image>().raycastTarget = false;
            Image.gameObject.Loadfrombytes(Settings.Download_Files.imagehandler.Backgroundb);
            Image.transform.localScale = new Vector3(1, 1.005f, 1);
            _gridLayoutGroup = Conntent.AddComponent<GridLayoutGroup>();
            _gridLayoutGroup.constraintCount = constraintCount;
            _gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            _gridLayoutGroup.cellSize = new Vector2(250, 100);
            _gridLayoutGroup.spacing = new Vector2(-60, -30);
            _scrollRect.content = Conntent.GetComponent<RectTransform>();
            _text = new GameObject("Text");
            _textComp = _text.AddComponent<TMPro.TextMeshProUGUI>();
            _text.transform.parent = _menuViewPort.transform;
            _text.transform.localPosition = new Vector3(0,388,0 );
            _text.transform.eulerAngles = Vector3.zero;
            _text.transform.localScale = Vector3.one;
            Conntent.AddComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.MinSize;
            Conntent.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.MinSize;
            _textComp.text = text;
            _textComp.fontSize = 20;
            _textComp.enableWordWrapping = false;
            _scrollRect.horizontal = false;

        }
    }
}
