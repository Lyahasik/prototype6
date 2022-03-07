using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobeController : MonoBehaviour
{
    public float AttackDistance = 2.2f;
    public float RangeVision = 30.0f;

    private GameObject CenterPoint;
    private GameObject _currentPoint;
    
    private Stats _stats;
    private MobeMove _mobeMove;
    private MobeAttack _mobeAttack;
    
    private GameObject _player;
    private Stats _statsPlayer;
    private bool _isVisible = false;

    void Start()
    {
        CenterPoint = GameObject.Find("CenterPoint");
        _currentPoint = CenterPoint;
        
        _player = GameObject.FindGameObjectWithTag("Player");
        _statsPlayer = _player.GetComponent<Stats>();
        
        _stats = GetComponent<Stats>();
        _mobeMove = GetComponent<MobeMove>();
        _mobeAttack = GetComponent<MobeAttack>();
    }
    
    void Update()
    {
        if (_stats.IsDeath())
        {
            _mobeAttack.OffAttack();
        }
        
        CheckMove();
        CheckDistance();
    }

    void CheckDistance()
    {
        if (!_statsPlayer.IsDeath())
        {
            if (_isVisible
                && !_stats.IsDeath()
                && !_mobeAttack.IsAttack()
                && Vector3.Distance(transform.position, _player.transform.position) <= AttackDistance)
            {
                StartAttack();
            }
        }
    }

    void CheckMove()
    {
        if (!_stats.IsDeath()
            && !_statsPlayer.IsDeath())
        {
            if (!_isVisible)
            {
                if (Vector3.Distance(transform.position, _player.transform.position) < RangeVision)
                {
                    _isVisible = true;
                }
                
                _mobeMove.Move(_currentPoint);
            }
            else
            {
                if (Vector3.Distance(transform.position, _player.transform.position) >= RangeVision)
                {
                    _isVisible = false;
                }
                else if (Vector3.Distance(transform.position, _player.transform.position) > AttackDistance)
                {
                    _mobeAttack.OffAttack();
                    _mobeMove.Move(_player);
                }
            }
        }
    }

    void StartAttack()
    {
        _mobeMove.OffMove();

        _mobeAttack.StartAttack(_player);
    }

    public void CheckShot(GameObject point)
    {
        _currentPoint = new GameObject();
        
        _currentPoint.transform.position = point.transform.position;
    }
}
