using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    public Ball b;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(b.transform.position.x > 0){
            if((transform.position.y - b.transform.position.y) < 0){
                rb.velocity = new Vector2(0, speed);
            }else if((transform.position.y - b.transform.position.y) > 0){
                rb.velocity = new Vector2(0, -speed);
            }
        }     
    }

}
