using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;



public class Movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Text scoreDisplay;

    [SerializeField]
    private Text HighscoreDisplay;

    [SerializeField]
    private float iFrames;

    public Animator animator; 

    private bool top;
    private int score;/// Figure out how to code the score based on time (ex. 1 second = 1 point)
                      /// and then figure out how to display the score onto the game itself
    private int highscore;
    private bool hasShield;
    private float endOfIFrames;
    private int scoreMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highscore = PlayerPrefs.GetInt("HighScore", 0);
        scoreDisplay.text = score + "";
        HighscoreDisplay.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        hasShield = false;
        scoreMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.gravityScale *= -1;
            animator.SetBool("isFlying", true);
            animator.SetBool("isCeil", false);
        }
        if (endOfIFrames > 0.0f)
        {
            endOfIFrames -= Time.deltaTime;
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
            if (hasShield == true)
            {
                endOfIFrames = iFrames;
                hasShield = false;
            }
            if (endOfIFrames <= 0.0f)
            {
                GameStateManager.GameOver();
            }
        }
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Ceiling")
        {
            animator.SetBool("isFlying", false);
        }
        if (collision.gameObject.tag == "Ceiling")
        {
            animator.SetBool("isCeil", true);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Score")
        {
            score += scoreMultiplier;
            scoreDisplay.text = score + "";
            if (score > PlayerPrefs.GetInt("Highscore", highscore))
            {
                highscore = score;
                PlayerPrefs.SetInt("HighScore", highscore);
                HighscoreDisplay.text = highscore + "";
            }
        }

        if (collision.gameObject.tag == "Shield")
        {
            hasShield = true;
        }

        if (collision.gameObject.tag == "PlusOne")
        {
            scoreMultiplier += 1;
        }
    }
}
