using System;
using UnityEngine;
namespace Nocturnal.Monobehaviours
{
    internal class TagAnimation : MonoBehaviour
    {
        private string _color { get; set; }
        public string Text { get; set; }
        private string _curentText { get; set; }
        private int _textPoz { get; set; }
        private bool _deacreasing { get; set; }


        public TMPro.TextMeshProUGUI _TextMeshPro;

        public TagAnimation(IntPtr ptr) : base(ptr)
        {

        }

        void Start()
        {
            _deacreasing = false;
            _textPoz = 0;
            _color = "";
            if (Text.StartsWith("<color="))
            {
                _color = Text.Substring(0,15) + " ";
                Text = Text.Substring(15);
            }
            _TextMeshPro = this.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            InvokeRepeating(nameof(updatehud), -1, 1.5f);
        }
        void updatehud()
        {
            if (_textPoz >= Text.Length)
                _deacreasing = true;
            else if (!_deacreasing)
            {
                _curentText = _curentText + Text[_textPoz];
                _textPoz += 1;
            }
            if (_deacreasing)
            {
                _curentText = _curentText.Substring(0, _curentText.Length -1);
                _textPoz -= 1;

                if (_textPoz == 0)
                    _deacreasing = false;
            }

            if (_curentText.Length == 0)
            {
                _TextMeshPro.text = "";
                return;
            }

            _TextMeshPro.text = _color + _curentText;
        }
    }
}
