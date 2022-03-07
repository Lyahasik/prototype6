using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float DelaySpawn = 10.0f;
    public GameObject PrefabMobe;

    private float _timeSpawn;

    private void Start()
    {
        _timeSpawn = Time.time + Random.Range(0.0f, 7.0f);
    }

    void Update()
    {
        if (_timeSpawn < Time.time)
        {
            _timeSpawn = Time.time + DelaySpawn;
            Instantiate(PrefabMobe, transform.position, transform.rotation);
        }
    }
}
