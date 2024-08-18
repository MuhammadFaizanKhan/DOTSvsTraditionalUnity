using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class EntityCreator : MonoBehaviour
{
    public Mesh mesh;
    public Material material;

    void Start()
    {
        // Create an entity
        //Entity entity = EntityManager.CreateEntity(World.DefaultGameObjectInjectionWorld);

        //// Add rendering components using RenderMeshUtility
        //RenderMeshUtility.AddComponents(entity, mesh, material);

        //// Add other components as needed (e.g., LocalToWorld, Translation)
        //EntityManager.SetComponentData(entity, new LocalToWorld { Value = Matrix4x4.identity });
        //EntityManager.SetComponentData(entity, new Translation { Value = new float3(0, 0, 0) });
    }
}

