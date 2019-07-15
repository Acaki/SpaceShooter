using System;
using UnityEngine;

[Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public Boundary boundary;
    public Sprite player, playerRight, playerLeft;
    
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.velocity = movement * speed;
        if (body.velocity.magnitude > speed)
        {
            body.velocity = body.velocity.normalized * speed;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            body.velocity *= 0.5f;
        }
        body.position = new Vector2(
            Mathf.Clamp(body.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(body.position.y, boundary.yMin, boundary.yMax)
        );
    }

    private void Update()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (Input.GetKey(KeyCode.RightArrow))
        {
            spriteRenderer.sprite = playerRight;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            spriteRenderer.sprite = player;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.sprite = playerLeft;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            spriteRenderer.sprite = player;
        }
    }
}

