using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBlue : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform ballOnPaddle;
    private float speedMag;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        if(gameLord.gameStart && !gameLord.gameOver && !gameLord.gamePause)
        {
            if (!inPlay)
            {
                this.transform.position = ballOnPaddle.transform.position;
            }

            if (Input.GetKeyDown(KeyCode.Space) && !inPlay)
            {
                inPlay = true;
                rb.velocity = new Vector2(2f, 10f);
                speedMag = (rb.velocity.x) * (rb.velocity.x) + (rb.velocity.y) * (rb.velocity.y);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "loseCollider")
        {
            inPlay = false;
            rb.velocity = Vector2.zero;
        }
    }
}
