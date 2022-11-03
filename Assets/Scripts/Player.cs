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
        // rb.velocity = new Vector2(moveVal.x * speed, moveVal.y * speed);
        
        if(this.name == "Player"){
            if(Input.GetKey(KeyCode.W)){
                rb.velocity = new Vector2(0, speed);
            }else if(Input.GetKey(KeyCode.S)){
                rb.velocity = new Vector2(0, -speed);
            }else{
                rb.velocity = Vector2.zero;
            }
        }else if(this.name == "Player2"){
            if(Input.GetKey(KeyCode.UpArrow)){
                rb.velocity = new Vector2(0, speed);
            }else if(Input.GetKey(KeyCode.DownArrow)){
                rb.velocity = new Vector2(0, -speed);
            }else{
                rb.velocity = Vector2.zero;
            }
        }
    }

    // void OnMove(InputValue value){
    //     moveVal = value.Get<Vector2>();
    // }

    
}
