using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    public float Delay = 0.1f;

    [Space] public GameObject Empty;
    public GameObject PrefabShot;

    private Animator _animator;
    private AudioSource _audioSource;
    private float _timeAttack;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void Attack()
    {
        if (_timeAttack < Time.time)
        {
            _timeAttack = Time.time + Delay;
            
            _animator.SetBool("Attack", true);
            _audioSource.Play();
            GameObject shot = Instantiate(PrefabShot, Empty.transform.position, Empty.transform.rotation);
            shot.GetComponent<Shot>().Spawn = gameObject;
            
            Invoke("StopAttack", 0.1f);
        }
    }

    void StopAttack()
    {
        _animator.SetBool("Attack", false);
    }
}
