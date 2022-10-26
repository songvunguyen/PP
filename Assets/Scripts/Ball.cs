using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10f;
    public UIController ui;
    Vector2 lastV; //keep track of the velocity that ball hit the wall
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * speed;
    }

    // Update is called once per frame
    void Update()
    {
        lastV = rb.velocity;
    }

    //Adding reflect directions to the ball
    // Using math code from https://noobtuts.com/unity/2d-pong-game

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight) {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider

        // Hit the left Racket?
        if (other.gameObject.tag == "RacketLeft") {
            // Calculate hit Factor
            float y = hitFactor(transform.position, other.transform.position, other.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            rb.velocity = dir * speed;
        }

        // Hit the right Racket?
        if (other.gameObject.tag == "RacketRight") {
            // Calculate hit Factor
            float y = hitFactor(transform.position, other.transform.position, other.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            rb.velocity = dir * speed;
        }

        // Hit wall, formula from https://www.youtube.com/watch?v=RoZG5RARGF0 to calculate the ball reflection
         if (other.gameObject.tag == "Wall") {
            float s = lastV.magnitude;

            Vector2 dir = Vector2.Reflect(lastV.normalized, other.contacts[0].normal );

            rb.velocity = dir * Mathf.Max(s, 0f);
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        resetBall(other.name);
        ui.updateScore(other.name);
    }

    //Reset ball position everytime someone score
    void resetBall(string side){
        this.transform.position = new Vector2(0,0);
        rb.velocity = Vector2.zero;
        StartCoroutine(BallTimer(side));
    }

    IEnumerator BallTimer(string s)
    {
        
        yield return new WaitForSeconds(1);

        //Determine who get the ball next based on who just scored
        if(s == "Right"){
            rb.velocity = Vector2.left * speed;
        }else if(s == "Left"){
            rb.velocity = Vector2.right * speed;
        }
         
    }

}
