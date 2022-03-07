using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float Speed = 20.0f;
    public int Damage = 10;

    public GameObject PrefabHit;

    public bool Mass = false;

    public GameObject Spawn;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _rb.MovePosition(_rb.position + gameObject.transform.forward * Speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!Mass)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Stats>().TakeDamage(Damage);
                other.gameObject.GetComponent<MobeController>().CheckShot(Spawn);
            }
        }
        
        Instantiate(PrefabHit, other.GetContact(0).point, Quaternion.identity);
        Destroy(gameObject);
    }
}
