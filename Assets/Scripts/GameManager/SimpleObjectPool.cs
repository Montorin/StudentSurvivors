using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SimpleObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize;
    [SerializeField] private bool expandable;

    List<GameObject> freeList;
    List<GameObject> usedList;
    private void Awake()
    {
        freeList = new List<GameObject>();
        usedList = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GenerateNewObject();
        }
    }
    public GameObject GetObject()
    {
        int totalFree = freeList.Count;
        if (freeList.Count == 0 && !expandable)
        { return null; }
        else if (totalFree == 0)
        {
            GenerateNewObject();
        }
        GameObject g = freeList[totalFree - 1];
        freeList.RemoveAt(totalFree - 1);
        usedList.Add(g);
        return g;
    }
    public void ReturnObject(GameObject obj)
    {
        Debug.Assert(usedList.Contains(obj));
        obj.SetActive(false);
        usedList.Remove(obj);
        freeList.Add(obj);
    }
    private void GenerateNewObject()
    {
        GameObject g = Instantiate(objectPrefab);
        g.transform.parent = transform;
        g.SetActive(false);
        freeList.Add(g);
    }
}
