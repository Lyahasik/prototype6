using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float TimeLife = 0.5f;
    
    void Start()
    {
        Invoke("DestroyObject", TimeLife);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
