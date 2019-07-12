using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public Boundary boundary;
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.velocity = movement * speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            body.velocity *= 0.5f;
        }
        body.position = new Vector2(
            Mathf.Clamp(body.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(body.position.y, boundary.yMin, boundary.yMax)
        );
        
    }
}
