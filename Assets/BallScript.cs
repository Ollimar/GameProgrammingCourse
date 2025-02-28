using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameManager gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = GameObject.Find("GameManagerObject").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Ground")
        {
            gm.LoseLife();
            Destroy(gameObject);
        }
    }
}
