using UnityEngine;

public class FirstTest : MonoBehaviour
{

    public int score = 1;
    public float xPos;
    public float yPos;
    public float speed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(xPos, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            xPos = xPos += speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            xPos = xPos -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            yPos = yPos += speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            yPos = yPos -= speed * Time.deltaTime;
        }

        print(score);
        transform.position = new Vector3(xPos, yPos, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("pickup"))
        {
            score += 1;
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("hazard"))
        {
            Destroy(gameObject);
        }

    }
}
