using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
namespace Nocturnal.Settings.wrappers
{
    internal static class photon_extentions
    {
        internal static void OpRaiseEvent(this object customObject, byte code, RaiseEventOptions RaiseEventOptions, SendOptions sendOptions)
        {
            OpRaiseEvent(customObject.FromManagedToIL2CPP<Il2CppSystem.Object>(), code, RaiseEventOptions, sendOptions);
        }

        internal static void OpRaiseEvent(Il2CppSystem.Object customObject, byte code, RaiseEventOptions RaiseEventOptions, SendOptions sendOptions)
           => PhotonNetwork.Method_Public_Static_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0
            (code,
             customObject,
             RaiseEventOptions,
             sendOptions);

        internal static byte[] ToByteArray(Il2CppSystem.Object obj)
        {
            if (obj == null) return null;
            var bf = new Il2CppSystem.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            var ms = new Il2CppSystem.IO.MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        internal static byte[] ToByteArray(this object obj)
        {
            if (obj == null) return null;
            var bf = new BinaryFormatter();
            var ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        internal static T FromByteArray<T>(byte[] data)
        {
            if (data == null) return default;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                return (T)obj;
            }
        }

        internal static T IL2CPPFromByteArray<T>(this byte[] data)
        {
            if (data == null) return default(T);
            var bf = new Il2CppSystem.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            var ms = new Il2CppSystem.IO.MemoryStream(data);
            object obj = bf.Deserialize(ms);
            return (T)obj;
        }

        internal static T FromIL2CPPToManaged<T>(Il2CppSystem.Object obj)
        {
            return FromByteArray<T>(ToByteArray(obj));
        }

        internal static T FromManagedToIL2CPP<T>(this object obj)
        {
            return obj.ToByteArray().IL2CPPFromByteArray<T>();
        }

        internal static string ByteArrayToString(byte[] array)
        {
            string result = string.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                    result += array[i].ToString();
                else result += array[i].ToString() + ", ";
            }
            return result;

        }

        internal static Vector3 GetVector3(this byte[] bytes, int poz) => new Vector3(BitConverter.ToSingle(bytes, poz), BitConverter.ToSingle(bytes, poz + 4), BitConverter.ToSingle(bytes, poz + 8));
        internal static void SetVector3(ref byte[] bytes, int poz,Vector3 vec3)  {

            Buffer.BlockCopy(BitConverter.GetBytes(vec3.x), 0, bytes, poz, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(vec3.y), 0, bytes, poz + 4, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(vec3.z), 0, bytes, poz + 8, 4);

        }

    }
}
