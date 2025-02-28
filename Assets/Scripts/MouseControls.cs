using UnityEngine;

public class MouseControls : MonoBehaviour
{
    public Transform target;
    public float transitionSpeed = 5f;


    // Determines the range of movement for player
    public float minX = -5f;
    public float maxX = 5f;

    public float minY = -1f;
    public float maxY = 4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Mouse function
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(transform.position, ray.direction * 100f, Color.red, 1f);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {

            // Define and clamp the desired target position
            Vector3 targetPos = new Vector3(Mathf.Clamp(hit.point.x, minX, maxX), Mathf.Clamp(hit.point.y, minY, maxY), hit.point.z);

            // Lerp. Move Between two points at given time
            target.position = Vector3.Lerp(target.position, targetPos, transitionSpeed * Time.deltaTime);

            // If clicked over an enemy object
            if (hit.transform.CompareTag("Enemy") && Input.GetButtonDown("Fire1"))
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
