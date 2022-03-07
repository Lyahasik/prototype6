using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Camera;
    public GameObject[] Weapons;

    private int _currentWeapon = 0;
    private WeaponAttack _weaponAttack;
    
    void Start()
    {
        _weaponAttack = Weapons[_currentWeapon].GetComponent<WeaponAttack>();
    }

    void Update()
    {
        InputKey();
    }

    void InputKey()
    {
        if (Input.GetMouseButtonDown(0))
        {Attack();
        }

        if (Input.GetKeyDown("1"))
        {
            Weapons[0].SetActive(true);
            Weapons[1].SetActive(false);
            _currentWeapon = 0;
            _weaponAttack = Weapons[_currentWeapon].GetComponent<WeaponAttack>();
        }

        if (Input.GetKeyDown("2"))
        {
            Weapons[0].SetActive(false);
            Weapons[1].SetActive(true);
            _currentWeapon = 1;
            _weaponAttack = Weapons[_currentWeapon].GetComponent<WeaponAttack>();
        }
    }

    void Attack()
    {
        _weaponAttack.Attack();
    }
}
