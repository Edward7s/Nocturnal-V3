using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Nocturnal.Apis
{
    internal static class Change_Image
    {
   

        internal static IEnumerator LoadIMGTSprite(Image Instance, string url)
        {
            var www = UnityWebRequestTexture.GetTexture(url);
            _ = www.downloadHandler;
            var asyncOperation = www.SendWebRequest();
            Func<bool> func = () => asyncOperation.isDone;
            yield return new WaitUntil(func);
            if (www.isHttpError || www.isNetworkError)
            {
               NocturnalC.Log("Error2 : " + www.error);
                yield break;
            }
            var content = DownloadHandlerTexture.GetContent(www);
           Instance.sprite = Instance.sprite = Sprite.CreateSprite(content,
                new Rect(0f, 0f, content.width, content.height), new Vector2(0f, 0f), 100000f, 1000u,
                SpriteMeshType.FullRect, Vector4.zero, false);
            www.Dispose();
            yield break;
        }



  
        internal static void Loadfrombytes(this GameObject gmj, string img, bool isimage = true, Color? color = null) => Loadfrombytes(gmj, System.Convert.FromBase64String(img), isimage,color);
        internal static void Loadfrombytes(this GameObject gmj, byte[] img, bool isimage = true, Color? color = null) => new ImageHandler(gmj, img, isimage,color);

        internal class ImageHandler : IDisposable
        {
            private  Image _ImageComponent { get; set; }
            private  Texture2D _Texture2d { get; set; }
            private  ImageThreeSlice _ImageThreeSliceCompnent { get; set; }
            ~ImageHandler() =>this.Dispose();
            public void Dispose() {
               this._ImageComponent = null;
               this._Texture2d = null;
               this._ImageThreeSliceCompnent = null;
            }

            public ImageHandler(GameObject gmj, byte[] img, bool isimage = true, Color? color = null)
            {
                if (isimage)
                {
                    _ImageComponent = gmj.GetComponent<Image>();
                    _Texture2d = new Texture2D(256, 256);
                    ImageConversion.LoadImage(_Texture2d, img);
                    _Texture2d.Apply();
                    _ImageComponent.sprite = Sprite.CreateSprite(_Texture2d,
                    new Rect(0f, 0f, _Texture2d.width, _Texture2d.height), new Vector2(0f, 0f), 100000f, 1000u,
                    SpriteMeshType.FullRect, Vector4.zero, false);
                    if (color != null)
                        _ImageComponent.color = Color.white;
                    return;
                }
                _ImageThreeSliceCompnent = gmj.GetComponent<ImageThreeSlice>();
                _Texture2d = new Texture2D(256, 256);
                ImageConversion.LoadImage(_Texture2d, img);
                _Texture2d.Apply();
                _ImageThreeSliceCompnent.prop_Sprite_0 = Sprite.CreateSprite(_Texture2d,
                new Rect(0f, 0f, _Texture2d.width, _Texture2d.height), new Vector2(0f, 0f), 100000f, 1000u,
                SpriteMeshType.FullRect, new Vector4(255, 0, 255, 0), false);
                if (color != null)
                    _ImageThreeSliceCompnent.color = Color.white;
            }
        }
    }



    }
