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

    // Update is called once per frame
    void FixedUpdate()
    {
        // rb.position += speed * Time.deltaTime * moveVal;
        rb.velocity = new Vector2(moveVal.x * speed, moveVal.y * speed);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.tag == "Wall"){
            moveVal = Vector2.zero;
        }
    }

    void OnMove(InputValue value){
        moveVal = value.Get<Vector2>();
    }

    
}
