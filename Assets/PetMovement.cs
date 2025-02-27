using UnityEngine;

public class PetMovement : MonoBehaviour
{
    public float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(moveX, 0, moveZ);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            // Handle eating food
            PetStats stats = GetComponent<PetStats>();
            if (stats != null)
            {
                stats.hunger += 20f; // Increase hunger by 20
                if (stats.hunger > 100f) stats.hunger = 100f; // Cap at 100
                Destroy(other.gameObject); // Destroy the food object
            }
        }
    }
}
