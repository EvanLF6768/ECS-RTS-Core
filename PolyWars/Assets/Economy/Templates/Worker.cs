using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct Worker
{
    public float loadSpeed;
    public float unloadSpeed;
    public float capacity;
    public ushort uiData;
}