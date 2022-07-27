using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Nocturnal.Settings.wrappers;
namespace Nocturnal.Monobehaviours
{
    internal class NocturnalPlayerManager : MonoBehaviour
    {
        public NocturnalPlayerManager(IntPtr ptr) : base(ptr)
        {

        }

        private TMPro.TextMeshProUGUI _text { get; set; }
        public string _platform { get; set; }
        public string _vr { get; set; }
        public string _friend { get; set; }
        private string _clientuser { get; set; }
        public string _rank { get; set; }
        private string _fps { get; set; }
        private int _counting { get; set; }
        private string _status { get; set; }
        private int i32 { get; set; }
        private float s4 { get; set; }
        private float _y { get; set; }
        private Transform _transform { get; set; }
        public string IsNocturnal { get; set; } = "";
        private GameObject _forwordDirection { get; set; }

        private VRC.Networking.FlatBufferNetworkSerializer _flatBufferNetworkSerializer { get; set; }

        public VRC.Player Player { get; set; }

        private int _fpsv { get; set; }

        void Start()
        {
            _text = this.GetComponent<VRCPlayer>().field_Public_PlayerNameplate_0.field_Public_GameObject_0.transform.Find("Platesmanager/_Plate:Loading").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            _rank = _rank;
            _counting = 0;
            _fps = "";
            _status = "";
            _flatBufferNetworkSerializer = Player.gameObject.GetComponent<VRC.Networking.FlatBufferNetworkSerializer>();
            i32 = 0;
            s4 = 0;
            _clientuser = "";
            _y = 0;
            _transform = Player.transform;
            _forwordDirection = Player._vrcplayer.field_Private_VRCAvatarManager_0.gameObject;
            InvokeRepeating(nameof(PlateHandler), -1, 3);
        }

        void PlateHandler()
        {
            HandlePlate();
           HandlePlayer();
        }

        void HandlePlayer()
        {
            if (!Settings.ConfigVars.HidePlayerOverDistance) return;

            if (Vector3.Distance(VRC.Player.prop_Player_0.transform.position, _transform.position) > 7)
                _forwordDirection.SetActive(false);
            else if (!_forwordDirection.activeSelf)
                _forwordDirection.SetActive(true);
        }

        void HandlePlate()
        {
            _fpsv = Player.prop_PlayerNet_0.prop_Byte_0 == 0 ? 0 : 1000 / Player.prop_PlayerNet_0.prop_Byte_0;
            if (i32 == Player.prop_PlayerNet_0.field_Private_Int32_0 && s4 == _flatBufferNetworkSerializer.field_Internal_Single_4)
            {
                _counting++;
                if (_counting > 1)
                    _status = "<color=#ff264a>Crashed</color>";
                else
                    _status = "<color=#ffe32b>Lagging</color>";
            }
            else
            {
                _status = "<color=#b8ffbe>Stable</color>";
                _counting = 0;
                if (_clientuser.Length == 0 && _fpsv != 0)
                    GetClientUser();
            }
            if (_counting == 0 && _fpsv < 25) _status = "<color=#ffe32b>Lagging</color>";
            i32 = Player.prop_PlayerNet_0.field_Private_Int32_0;
            s4 = _flatBufferNetworkSerializer.field_Internal_Single_4;
            _fps = _fpsv == 0 ? "0(Invalid)" : _fpsv.ToString();
            _text.text = $"{IsNocturnal}{_friend}{_platform} {_vr} {_rank} <color=#a742f5>F:{_fps}</color> <color=#caa1ff>P:{Player.prop_PlayerNet_0.field_Private_Int16_0}</color> {_status} {_clientuser}";

        }


        void GetClientUser()
        {
            if (!Player.field_Private_VRCPlayerApi_0.IsPlayerGrounded() && _y == _transform.localPosition.y)
            {
                _clientuser = $"<color=#450000>Client";
                return;
            }
            if (1000 / Player.prop_PlayerNet_0.prop_Byte_0 > 250)
            {
                _clientuser = $"<color=#450000>Client";
                return;
            }
            if (1000 / Player.prop_PlayerNet_0.prop_Byte_0 < 0)
            {
                _clientuser = $"<color=#450000>Client";
                return;
            }
            if (Player.prop_PlayerNet_0.field_Private_Int16_0 > 250)
            {
                _clientuser = $"<color=red>Client";
                return;
            }
            if (Player.prop_PlayerNet_0.field_Private_Int16_0 < 0)
            {
                _clientuser = $"<color=#450000>Client";
                return;
            }

            _y = _transform.localPosition.y;
        }
    }
}
