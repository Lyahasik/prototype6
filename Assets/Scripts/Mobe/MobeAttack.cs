using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobeAttack : MonoBehaviour
{
    public int Damage = 1;
    public float SpeedAttack = 1.3f;
    
    private Animator _animator;
    
    private GameObject _target;
    private Stats _statsTarget;
    private bool _isAttack = false;

    private float _timeAttack;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Attack();
    }
    
    void Attack()
    {
        if (_isAttack
            && _timeAttack < Time.time)
        {
            _timeAttack = Time.time + SpeedAttack;
            _statsTarget.TakeDamage(Damage);

            if (_statsTarget.IsDeath())
            {
                OffAttack();
            }
        }
    }

    public void StartAttack(GameObject target)
    {
        if (!_target)
        {
            _target = target;
            _statsTarget = _target.GetComponent<Stats>();
        
            _isAttack = true;
            _timeAttack = Time.time + SpeedAttack;
            _animator.SetBool("Attack", true);

            transform.LookAt(target.transform.position, Vector3.up);
        }
    }

    public bool IsAttack()
    {
        return _isAttack;
    }

    public void OffAttack()
    {
        _target = null;
        _isAttack = false;
        _animator.SetBool("Attack", false);
    }
}
