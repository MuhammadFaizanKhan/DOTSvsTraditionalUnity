
using Unity.Entities;
using Unity.Mathematics;

public struct ComponentMoveSpeed : IComponentData
{
    public float value;
}

public struct ComponentTranslatoin : IComponentData
{
    public float3 value;
}

public struct ComponentScale : IComponentData
{
    public float3 value;
}

public struct ComponentRotation : IComponentData
{
    public quaternion value;
}