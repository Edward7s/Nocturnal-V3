using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Nocturnal.Settings.wrappers;
namespace Nocturnal.Ui
{
    internal class PlateManager
    {
        private GameObject _plateGmj { get; set; }
        private GameObject _PlateM { get; set; }
        private UnityEngine.UI.GridLayoutGroup _layout { get; set; }
        private GameObject _holder { get; set; }
        private Transform _prefab { get; set; }
        private GameObject _icon { get; set; }
        private GameObject _cameraManager { get; set; }

        ~PlateManager()
        {
            _plateGmj = null;
            _PlateM = null;
            _layout = null;
            _holder = null;
            _prefab = null;
            _icon = null;
            _cameraManager = null;
            GC.Collect();
        }
        public PlateManager(VRC.Player Player, Color color)
        {

            _plateGmj = Player._vrcplayer.field_Public_PlayerNameplate_0.field_Public_GameObject_0.gameObject;
            _PlateM = new GameObject();
            _PlateM.name = "Platesmanager";
            _layout = _PlateM.AddComponent<UnityEngine.UI.GridLayoutGroup>();
            _PlateM.transform.parent = _plateGmj.transform;
            _PlateM.transform.localPosition = new Vector3(0, 105, 0);
            _PlateM.transform.localScale = Vector3.one;
            _PlateM.transform.localEulerAngles = Vector3.zero;
            _PlateM.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 150);
            _layout.constraint = UnityEngine.UI.GridLayoutGroup.Constraint.FixedColumnCount;
            _layout.constraintCount = 1;
            _layout.childAlignment = TextAnchor.LowerCenter;
            _layout.cellSize = new Vector2(100, 30);
            _holder = new GameObject("Plate Holder");
            _holder.transform.parent = _PlateM.transform;
            _holder.transform.localPosition = Vector3.zero;
            _holder.transform.localScale = Vector3.one;
            _holder.transform.localEulerAngles = Vector3.zero;
            _holder.gameObject.AddComponent<UnityEngine.UI.LayoutElement>();
            _holder.gameObject.SetActive(false);
            _prefab = GameObject.Instantiate(_plateGmj.transform.Find("Quick Stats").gameObject, _holder.transform).transform;
            GameObject.Destroy(_prefab.Find("Performance Icon").gameObject);
            GameObject.Destroy(_prefab.Find("Performance Text").gameObject);
            GameObject.Destroy(_prefab.Find("Friend Anchor Stats").gameObject);
            _icon = _prefab.Find("Trust Icon").gameObject;
            _icon.name = "Icon";
            _icon.gameObject.SetActive(false);
            _prefab.Find("Trust Text").name = "Text";
            _prefab.name = "PrefabPlate";
            _plateGmj.transform.Find("Main/Background").gameObject.GetComponent<ImageThreeSlice>().color = color;
            _plateGmj.transform.Find("Icon/Background").gameObject.GetComponent<UnityEngine.UI.Image>().color = color;
            if (Player != VRC.Player.prop_Player_0)
            {
                Player.transform.Find("SelectRegion").GetComponent<MeshRenderer>().material.color = color;
                Player.gameObject.gameObject.AddComponent<Monobehaviours.Outline>();
                if (Settings.ConfigVars.EveryoneTrail)
                    Player.gameObject.AddComponent<Monobehaviours.Trail>();
                _cameraManager = new GameObject("UserPovCamera");
                _cameraManager.transform.parent = Player.gameObject.transform.Find("AnimationController/HeadAndHandIK/HeadEffector");
                _cameraManager.transform.localPosition = Vector3.zero;
                _cameraManager.transform.localScale = Vector3.one;
                _cameraManager.transform.localEulerAngles = Vector3.zero;
                _cameraManager.AddComponent<UnityEngine.Camera>().farClipPlane = 80;
                _cameraManager.SetActive(false);
            }
        }
     

    }
    }
