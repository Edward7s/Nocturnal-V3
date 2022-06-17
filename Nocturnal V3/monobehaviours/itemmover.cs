using System;
using VRC.SDKBase;
using UnityEngine;
namespace Nocturnal.Monobehaviours
{
    internal class ItemMover : MonoBehaviour
    {
        private GameObject _FlyngCamera { get; set; }
        private GameObject _Camera { get; set; }
        private float _MouseX { get; set; }
        private float _MouseY{ get; set; }
        private float _Speed = 0.5f;
        public ItemMover(IntPtr ptr) : base(ptr) { }       
        public void OnEnable()
        {
            VRC.Player.prop_Player_0.gameObject.GetComponent<CharacterController>().enabled = false;
            Settings.Hooks.cameraeye.enabled = false;
            _FlyngCamera = new GameObject("Item Camera Holder");
            _Camera =  new GameObject("Camera").AddComponent<Camera>().gameObject;
            _Camera.transform.parent = _FlyngCamera.transform;
            _Camera.transform.localEulerAngles = Vector3.zero;
            _Camera.transform.localPosition = Vector3.zero;
            _Camera.transform.localScale = Vector3.one;
            _FlyngCamera.transform.position = VRC.Player.prop_Player_0._vrcplayer.field_Internal_Animator_0.GetBoneTransform(HumanBodyBones.Head).position;
            _Camera.GetComponent<Camera>().nearClipPlane = 0.05f;
        }
        public void OnDisable()
        {
            VRC.Player.prop_Player_0.gameObject.GetComponent<CharacterController>().enabled = true;
            Settings.Hooks.cameraeye.enabled = true;
            GameObject.DestroyImmediate(_FlyngCamera);
            _FlyngCamera = null;
            _Camera = null;
            Settings.Hooks._Pickup = null;
            Ui.Inject_monos._UpdateManager.SetActive(true);
        }
        void LateUpdate()
        {
            if (_FlyngCamera == null) return;

            try { if (VRC.Player.prop_Player_0.transform == null) return; } catch { return; }

            if (Networking.GetOwner(Settings.Hooks._Pickup) != VRC.Player.prop_Player_0.field_Private_VRCPlayerApi_0)
                Networking.SetOwner(VRC.Player.prop_Player_0.field_Private_VRCPlayerApi_0,Settings.Hooks._Pickup);

            Settings.Hooks._Pickup.transform.localEulerAngles = _Camera.transform.localEulerAngles;
            Settings.Hooks._Pickup.transform.position = new Vector3(_FlyngCamera.transform.position.x, _FlyngCamera.transform.position.y - 0.2f, _FlyngCamera.transform.position.z);

            _Speed = Input.GetKey(KeyCode.LeftShift) ? 0.2f : 0.1f;

            if (Input.GetKey(KeyCode.W))
                _FlyngCamera.transform.position += _Camera.transform.forward * _Speed * 0.2f;

            if (Input.GetKey(KeyCode.S))
                _FlyngCamera.transform.position -= _Camera.transform.forward * _Speed * 0.2f;

            if (Input.GetKey(KeyCode.D))
                _FlyngCamera.transform.position += _Camera.transform.right * _Speed * 0.2f;

            if (Input.GetKey(KeyCode.A))
                _FlyngCamera.transform.position -= _Camera.transform.right * _Speed * 0.2f;

            if (Input.GetKey(KeyCode.Space))
                _FlyngCamera.transform.position += _Camera.transform.up * _Speed /2;

            if (Input.GetKey(KeyCode.LeftControl))
                _FlyngCamera.transform.position -= _Camera.transform.up * _Speed /2;

            _MouseX += 2 * Input.GetAxis("Mouse X");
            _MouseY -= 2 * Input.GetAxis("Mouse Y");

            _Camera.transform.eulerAngles = new Vector3(_MouseY, _MouseX, 0);

            if (Input.GetKeyDown(KeyCode.Escape)) this.gameObject.SetActive(false);

        }

    }
}
