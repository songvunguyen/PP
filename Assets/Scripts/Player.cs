using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    Vector2 moveVal;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // rb.position += speed * Time.deltaTime * moveVal;
        rb.velocity = new Vector2(moveVal.x * speed, moveVal.y * speed);
    }

    void OnMove(InputValue value){
        moveVal = value.Get<Vector2>();
    }

    
}
