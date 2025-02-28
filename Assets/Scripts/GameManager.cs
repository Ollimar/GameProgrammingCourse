using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int score;
    public int hiScore;
    public int lives = 3;

    // UI Variablaes
    public GameObject scoreUI;
    public GameObject hiScoreUI;
    public GameObject livesUI;
    public GameObject retryButton;
    public GameObject gameOverText;

    public GameObject ball;
    public GameObject[] ballsInGame;
    public int newBallScore;

    public AudioSource myAudio;
    public AudioClip music;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballsInGame = GameObject.FindGameObjectsWithTag("Ball");
        scoreUI.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
        hiScoreUI.GetComponent<TextMeshProUGUI>().text = "HiScore: " + hiScore.ToString();
        livesUI.GetComponent<TextMeshProUGUI>().text = "Lives: " + lives.ToString();
        retryButton.SetActive(false);
        gameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        myAudio.pitch = Time.timeScale;
    }

    public void AddScore()
    {
        score += 100;
        newBallScore += 100;
        scoreUI.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
    }

    public void SpawnBall()
    {
        ballsInGame = GameObject.FindGameObjectsWithTag("Ball");
        int ballsLeft = ballsInGame.Length;

        if(ballsLeft <3)
        {
            Instantiate(ball, transform.position, transform.rotation);
            ballsInGame = GameObject.FindGameObjectsWithTag("Ball");
        }
    }

    public void LoseLife()
    {
        lives -= 1;
        livesUI.GetComponent<TextMeshProUGUI>().text = "Lives: " + lives.ToString();
        Time.timeScale = 1f;

        if (lives <= 0)
        {
            GameOver();
        }

        ballsInGame = GameObject.FindGameObjectsWithTag("Ball");
        int ballsLeft = ballsInGame.Length;
        print(ballsLeft);

        if(ballsLeft <= 1 && lives >= 1)
        {
            SpawnBall();
        }
    }

    public void Retry()
    {
        lives = 3;
        score = 0;
        scoreUI.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
        hiScoreUI.GetComponent<TextMeshProUGUI>().text = "HiScore: " + hiScore.ToString();
        livesUI.GetComponent<TextMeshProUGUI>().text = "Lives: " + lives.ToString();
        gameOverText.SetActive(false);
        SpawnBall() ;
        retryButton.SetActive(false);
    }

    public void GameOver()
    {

        // Find remaining balls and destroy them
        ballsInGame = GameObject.FindGameObjectsWithTag("Ball"); 

        for(int i=0; i<ballsInGame.Length; i++)
        {
            Destroy(ballsInGame[i]);
        }

        if (score > hiScore)
        {
            hiScore = score;
            hiScoreUI.GetComponent<TextMeshProUGUI>().text = "HiScore: " + hiScore.ToString();
        }

        gameOverText.SetActive(true);
        retryButton.SetActive(true);

        print("Game Over");
    }
}
