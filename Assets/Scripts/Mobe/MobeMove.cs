using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobeMove : MonoBehaviour
{
    private GameObject CenterPoint;
    private Animator _animator;
    private NavMeshAgent _navMeshAgent;
    private Stats _stats;

    private GameObject _target;
    
    void Start()
    {
        CenterPoint = GameObject.Find("CenterPoint");
        _stats = GetComponent<Stats>();
        _target = CenterPoint;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (!_stats.IsDeath())
        {
            if (_target
                && Vector3.Distance(_target.transform.position, transform.position) <= 0.2f)
            {
                OffMove();
            }
        }
    }

    void Walk()
    {
        _animator.SetBool("Run", false);
        _animator.SetBool("Walk", true);
        _navMeshAgent.destination = _target.transform.position;
    }
    
    public void Move(GameObject target)
    {
        _target = target;
        
        if (Vector3.Distance(_target.transform.position, transform.position) > 0.2f)
        {
            if (_target == CenterPoint)
            {
                _navMeshAgent.speed = 3.5f;
                Walk();
            }
            else
            {
                _navMeshAgent.speed = 7.0f;
                OnRun();
            }
            _navMeshAgent.destination = _target.transform.position;
        }
    }

    void OnRun()
    {
        _animator.SetBool("Walk", false);
        _animator.SetBool("Run", true);
        _navMeshAgent.isStopped = false;
    }

    public void OffMove()
    {
        _animator.SetBool("Walk", false);
        _animator.SetBool("Run", false);
        _navMeshAgent.isStopped = true;
    }
}
