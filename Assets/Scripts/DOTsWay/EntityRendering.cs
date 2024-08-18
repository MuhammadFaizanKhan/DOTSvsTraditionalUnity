using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Rendering;

public class EntityRendering : MonoBehaviour
{


    public GameObject prefab; // Reference to the traditional prefab
    public Material entityMaterial; // Material to be used for entities
    public int objectCount = 10000;

    private EntityManager entityManager;
    private EntityArchetype entityArchetype;

    void Start()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        // Define the components that entities will have
        entityArchetype = entityManager.CreateArchetype(
            typeof(RenderMesh),
            typeof(LocalToWorld),
            typeof(ComponentTranslatoin),
            typeof(ComponentRotation),
            typeof(ComponentScale),
            typeof(ComponentMoveSpeed)
        );

        // Create entities
        for (int i = 0; i < objectCount; i++)
        {
            Entity entity = entityManager.CreateEntity(entityArchetype);

            // Assign a mesh and material to the entity
            entityManager.SetSharedComponentManaged(entity, new RenderMesh
            {
                mesh = prefab.GetComponent<MeshFilter>().sharedMesh,
                material = entityMaterial
            });

            // Set initial position, rotation, and scale
            entityManager.SetComponentData(entity, new ComponentTranslatoin
            {
                value = UnityEngine.Random.insideUnitSphere * 10
            });

            entityManager.SetComponentData(entity, new ComponentRotation
            {
                value = quaternion.identity
            });

            entityManager.SetComponentData(entity, new ComponentScale
            {
                value = new float3(1f, 1f, 1f)
            });

            entityManager.SetComponentData(entity, new ComponentMoveSpeed
            {
                value = UnityEngine.Random.Range(1f, 3f)
            });

            var renderMeshArray = new RenderMeshArray(new Material[] { entityMaterial }, new Mesh[] { prefab.GetComponent<MeshFilter>().mesh });
            var desc = new RenderMeshDescription(
                shadowCastingMode: ShadowCastingMode.Off,
                receiveShadows: false);
            RenderMeshUtility.AddComponents(entity, entityManager, desc, renderMeshArray, 
                MaterialMeshInfo.FromRenderMeshArrayIndices(0, 0));

        }
    }

    void Start2()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        // Define the components that entities will have
        entityArchetype = entityManager.CreateArchetype(
            typeof(RenderMesh),
            typeof(LocalToWorld),
            typeof(ComponentTranslatoin),
            typeof(ComponentRotation),
            typeof(ComponentScale),
            typeof(ComponentMoveSpeed)
        );

        // Create entities
        for (int i = 0; i < objectCount; i++)
        {
            Entity entity = entityManager.CreateEntity(entityArchetype);

            // Assign a mesh and material to the entity
            entityManager.SetSharedComponentManaged(entity, new RenderMesh
            {
                mesh = prefab.GetComponent<MeshFilter>().sharedMesh,
                material = entityMaterial
            });

            // Set initial position, rotation, and scale
            entityManager.SetComponentData(entity, new ComponentTranslatoin
            {
                value = UnityEngine.Random.insideUnitSphere * 10
            });

            entityManager.SetComponentData(entity, new ComponentRotation
            {
                value = Quaternion.identity
            });

            entityManager.SetComponentData(entity, new ComponentScale
            {
                value = Vector3.one
            });

            entityManager.SetComponentData(entity, new ComponentMoveSpeed
            {
                value = UnityEngine.Random.Range(1f, 3f)
            });
        }


    }
}
