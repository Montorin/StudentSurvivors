using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SimpleObjectPool : MonoBehaviour
{
    [SerializeField] GameObject objectPrefab;

    List<GameObject> poolObjects = new List<GameObject>();

    int objectIndex;
    private void Awake()
    {
        for (int i = 0; i < 500; i++)
        {
            poolObjects.Add(Instantiate(objectPrefab));
        }
    }
    public GameObject Get()
    {
        if (objectIndex >= poolObjects.Count)
        {
            objectIndex = 0;
        }
        objectIndex %= poolObjects.Count;
        return poolObjects[objectIndex++];
    }
}
