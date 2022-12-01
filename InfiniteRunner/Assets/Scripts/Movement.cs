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
    private Text multiplierDisplay;

    [SerializeField]
    private float iFrames;

    [SerializeField]
    private GameObject shieldIcon;

    [SerializeField]
    private AudioSource jumpSound;

    [SerializeField]
    private AudioSource plusOneSound;

    [SerializeField]
    private AudioSource shieldSound;

    [SerializeField]
    private AudioSource coinSound;

    [SerializeField]
    private AudioSource deathSound;

    [SerializeField]
    private AudioSource newHighScoreSound;

    public Animator animator; 

    private bool top;
    private int score;

    private int highscore;
    private bool hasShield;
    private float endOfIFrames;
    private int scoreMultiplier;
    private bool newHighScore;
  

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highscore = PlayerPrefs.GetInt("HighScore", 0);
        scoreDisplay.text = score + "";
        HighscoreDisplay.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        multiplierDisplay.text = "x" + scoreMultiplier;
        hasShield = false;
        shieldIcon.SetActive(false);
        scoreMultiplier = 1;
        newHighScore = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpSound.Play();
            rb.gravityScale *= -1;
            animator.SetBool("isFlying", true);
            animator.SetBool("isCeil", false);
        }
        if (endOfIFrames > 0.0f)
        {
            endOfIFrames -= Time.deltaTime;
        }
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
                shieldIcon.SetActive(false);
            }
            if (endOfIFrames <= 0.0f)
            {
                deathSound.Play();
                GameStateManager.gameOver();
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
            coinSound.Play();
            score += scoreMultiplier;
            scoreDisplay.text = score + "";
            if (score > PlayerPrefs.GetInt("Highscore", highscore))
            {
                if (newHighScore == false)
                {
                    newHighScore = true;
                    newHighScoreSound.Play();
                }
                highscore = score;
                PlayerPrefs.SetInt("HighScore", highscore);
                HighscoreDisplay.text = highscore + "";
            }
        }

        if (collision.gameObject.tag == "Shield")
        {
            hasShield = true;
            shieldIcon.SetActive(true);
            shieldSound.Play();
        }

        if (collision.gameObject.tag == "PlusOne")
        {
            scoreMultiplier += 1;
            multiplierDisplay.text = "x" + scoreMultiplier;
            plusOneSound.Play();
        }
    }
}
