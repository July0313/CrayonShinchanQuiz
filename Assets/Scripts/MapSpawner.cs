using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public List<GameObject> spawnableMapList;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject childObj = transform.GetChild(i).gameObject;
            childObj.SetActive(false);
            spawnableMapList.Add(childObj);
        }

        SpawnMap();
    }

    public void SpawnMap()
    {
        int idx = Random.Range(0, spawnableMapList.Count);
        spawnableMapList[idx].SetActive(true);
        spawnableMapList.RemoveAt(idx);
    }
}
