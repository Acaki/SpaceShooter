using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
