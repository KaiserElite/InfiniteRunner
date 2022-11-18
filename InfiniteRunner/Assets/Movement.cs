using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Movement : MonoBehaviour
{
    [SerializeField]
    private Text scoreDisplay;

    Rigidbody2D rb;

    private bool top;
    private int score;/// Figure out how to code the score based on time (ex. 1 second = 1 point)
                      /// and then figure out how to display the score onto the game itself

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;
        scoreDisplay.text = score + "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.gravityScale *= -1;
        }
        //scoreDisplay.text = score.ToString();
    }

    void Rotation()
    {
        if (top == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
        top = !top;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GameOver")
        {
            GameStateManager.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GameOver")
        {
            GameStateManager.GameOver();
        }
        if (collision.gameObject.tag == "Score")
        {
            score = score + 2;
            scoreDisplay.text = score + "";
        }
    }
}
