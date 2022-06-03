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
               NocturnalC.log("Error2 : " + www.error);
                yield break;
            }
            var content = DownloadHandlerTexture.GetContent(www);
            var sprite2 = Instance.sprite = Sprite.CreateSprite(content,
                new Rect(0f, 0f, content.width, content.height), new Vector2(0f, 0f), 100000f, 1000u,
                SpriteMeshType.FullRect, Vector4.zero, false);
           // Instance.color = Color.white;
            if (sprite2 != null) Instance.sprite = sprite2;
            www.Dispose();
        }

        internal static void Loadfrombytes(this GameObject gmj, byte[] img, bool isimage = true)
        {
            if (isimage)
            {
                var image = gmj.GetComponent<Image>();
                var texture = new Texture2D(256, 256);
                ImageConversion.LoadImage(texture, img);
                texture.Apply();

                image.sprite = Sprite.CreateSprite(texture,
                new Rect(0f, 0f, texture.width, texture.height), new Vector2(0f, 0f), 100000f, 1000u,
                SpriteMeshType.FullRect, Vector4.zero, false);
                return;
            }
            var image2 = gmj.GetComponent<ImageThreeSlice>();
            var texture2 = new Texture2D(256, 256);
            ImageConversion.LoadImage(texture2, img);
            texture2.Apply();

            image2.prop_Sprite_0 = Sprite.CreateSprite(texture2,
            new Rect(0f, 0f, texture2.width, texture2.height), new Vector2(0f, 0f), 100000f, 1000u,
            SpriteMeshType.FullRect, new Vector4(255,0,255,0), false);

        }

    }
}
