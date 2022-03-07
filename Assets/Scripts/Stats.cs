using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Stats : MonoBehaviour
{
    public int Health = 100;
    
    private Animator _animator;
    private bool _isDeath = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void UpHealth(int value)
    {
        Health += value;
    }

    public void TakeDamage(int value)
    {
        Health -= value;

        if (!CompareTag("Player")
            && Health <= 0)
        {
            _isDeath = true;
            _animator.SetBool("Death", true);

            if (CompareTag("Enemy"))
            {
                GetComponent<NavMeshAgent>().isStopped = true;
            }
            
            StartCoroutine(StartDeath());
        }
    }

    public bool IsDeath()
    {
        return _isDeath;
    }

    IEnumerator StartDeath()
    {
        yield return new WaitForSeconds(3.0f);

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!CompareTag("Player")
            && other.gameObject.CompareTag("Shot"))
        {
            TakeDamage(other.gameObject.GetComponent<Shot>().Damage / 2);
            GetComponent<MobeController>().CheckShot(other.gameObject.GetComponent<Shot>().Spawn);
        }
    }
}
