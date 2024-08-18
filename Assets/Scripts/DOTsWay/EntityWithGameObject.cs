
using Unity.Entities;
using UnityEngine;

public class EntityWithGameObject : MonoBehaviour
{
    public GameObject prefab;
    public int objectCount = 10000;
    GameObject[] gameObjectsForVisualize;
    Entity[] entites;

    Unity.Entities.EntityManager entityMgr;
    private void Start()
    {
            entityMgr = World.DefaultGameObjectInjectionWorld.EntityManager;
        var archetype = entityMgr.CreateArchetype(
            typeof(ComponentTranslatoin)
            , typeof(ComponentMoveSpeed));

        gameObjectsForVisualize = new GameObject[objectCount];
        entites = new Entity[objectCount];

        for (int i = 0; i < objectCount; i++)
        {
          Entity entity =  entityMgr.CreateEntity(archetype);
            entites[i] = entity;
            entityMgr.SetComponentData(entity, new ComponentTranslatoin
            {
                value = Random.insideUnitSphere * 10
            }) ;

            entityMgr.SetComponentData(entity, new ComponentMoveSpeed
            {
                value = UnityEngine.Random.Range(1f, 3f)
            });

            gameObjectsForVisualize[i] =
                Instantiate(prefab,
                entityMgr.GetComponentData<ComponentTranslatoin>(entites[i]).value,
                Quaternion.identity);

        }

    }

    private void Update()
    {
        for (int i = 0; i < objectCount; i++)
        {
            var translation = entityMgr.GetComponentData<ComponentTranslatoin>(entites[i]);
            gameObjectsForVisualize[i].transform.position = translation.value;
        }
    }
}
