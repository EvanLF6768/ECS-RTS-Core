using UnityEngine;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections;

public class ContentLoader : MonoBehaviour
{
    void Awake()
    {

    }

    public T ReadStruct<T>(FileStream fs)
    {
        byte[] buffer = new byte[Marshal.SizeOf(typeof(T))];
        fs.Read(buffer, 0, Marshal.SizeOf(typeof(T)));
        GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        T temp = (T)
        Marshal.PtrToStructure(handle.AddrOfPinnedObject(),typeof(T));
        handle.Free();
        return temp;
    }
}