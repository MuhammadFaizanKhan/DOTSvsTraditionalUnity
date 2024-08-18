using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Rendering;

public class MeshRendererSystem : MonoBehaviour
{
    public Mesh mesh;
    public Material material;

    void Start()
    {
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        // Create a new entity
        var entityArchetype = entityManager.CreateArchetype(
            typeof(LocalTransform),
            typeof(RenderMesh),
            typeof(LocalToWorld)
        );

        var entity = entityManager.CreateEntity(entityArchetype);

        // Set the mesh and material
        var renderMesh = new RenderMesh
        {
            mesh = mesh,
            material = material
        };

        entityManager.SetComponentData(entity, new LocalTransform { Position = new Unity.Mathematics.float3(0, 0, 0) });
        //entityManager.SetSharedComponentData<Entity>(renderMesh);

        entityManager.SetSharedComponentManaged(entity, renderMesh);
        //new RenderMesh
        //{
        //    mesh = prefab.GetComponent<MeshFilter>().sharedMesh,
        //    material = entityMaterial
        //});
        var renderMeshArray = new RenderMeshArray(new Material[] { material }, new Mesh[] { mesh });
        var desc = new RenderMeshDescription(
            shadowCastingMode: ShadowCastingMode.Off,
            receiveShadows: false);
        RenderMeshUtility.AddComponents(entity, entityManager, desc, renderMeshArray, MaterialMeshInfo.FromRenderMeshArrayIndices(0, 0));
    }
}
