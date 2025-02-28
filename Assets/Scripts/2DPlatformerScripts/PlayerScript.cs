using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float playerSpeed = 5f;
    public float jumpPower = 1000f;

    public int jumpCount;
    public int jumpLimit = 1;

    public Rigidbody2D myRB;

    public Transform spawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * hor * playerSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && jumpCount <= jumpLimit)
        {
            myRB.linearVelocity = Vector2.zero;
            myRB.AddForce(Vector2.up * jumpPower);
            jumpCount++;
        }

        if(transform.position.y < -5f)
        {
            transform.position = spawnPoint.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        jumpCount = 0;
    }
}
