using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    MapSpawner mapSpawner;

    private void Awake()
    {
        mapSpawner = GetComponentInParent<MapSpawner>();
    }

    private void OnEnable()
    {
        transform.position = Vector3.zero;
    }

    private void Update()
    {
        transform.position -= Vector3.forward * speed * Time.deltaTime;

        if(transform.position.z <= -80f)
        {
            mapSpawner.SpawnMap();

            if (transform.position.z <= -100f)
            {
                mapSpawner.spawnableMapList.Add(gameObject);
                gameObject.SetActive(false);
            }
        }
    }
}
