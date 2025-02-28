using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PaddleScript : MonoBehaviour
{
    public float bounceSpeed = 500f;

    public GameManager gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * bounceSpeed);
            gm.AddScore();

            if (gm.newBallScore == 500)
            {
                Time.timeScale += 0.1f;
                gm.SpawnBall();
                gm.newBallScore = 0;
            }
        }
    }
}
