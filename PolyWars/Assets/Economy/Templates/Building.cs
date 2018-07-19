using Unity.Mathematics;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct Building
{   
    public fixed ushort resources[6]; // A pseudo-pointer to the resource in the global resource table, there is no reason for there to be more than 65,536 resources
    public fixed float ioDelta[6];
    public fixed float capacity[6];
    public float2 entrance;
    public ushort uiData;
}