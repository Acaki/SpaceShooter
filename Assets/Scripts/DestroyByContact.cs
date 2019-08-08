using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boundary"))
        {
            return;
        }

        Instantiate(explosion, transform);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
