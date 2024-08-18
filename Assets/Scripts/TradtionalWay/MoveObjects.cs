using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    public GameObject prefab;
    public int objectCount = 10000;
    private GameObject[] objects;

    void Start()
    {
        objects = new GameObject[objectCount];
        for (int i = 0; i < objectCount; i++)
        {
            objects[i] = Instantiate(prefab, Random.insideUnitSphere * 10, Quaternion.identity);
        }
    }

    void Update()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }
}

