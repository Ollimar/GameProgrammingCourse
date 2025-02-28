using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicPlayer : MonoBehaviour
{

    public Rigidbody2D myRB;
    public float power = 200f;
    public float movementSpeed = 5f;
    public float hor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-8f,11.5f),Mathf.Clamp(transform.position.y,1f,10f),0);

        hor = Input.GetAxis("Horizontal");

        // Moves the player according to keyboard inputs
        transform.Translate(Vector3.right * hor * movementSpeed * Time.deltaTime);

        // Jumps the player
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myRB.linearVelocity = Vector2.zero;
            myRB.AddForce(Vector2.up * power);
        }       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy")) 
        {
            SceneManager.LoadScene(0);
        }
    }
}
