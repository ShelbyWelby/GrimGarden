using UnityEngine;
using Mirror;

public class PetMovement : NetworkBehaviour
{
    public float speed = 5f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isOwned) return; // Only the client with authority moves this pet
        float moveX = Input.GetAxis("Horizontal") * speed;
        float moveZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    void OnTriggerEnter(Collider other)
    {
        PetStats stats = GetComponent<PetStats>();
        if (stats != null)
        {
            if (other.CompareTag("Food"))
            {
                stats.hunger = Mathf.Min(stats.hunger + 20f, 100f);
                if (isServer) Destroy(other.gameObject); // Server handles destruction
            }
            else if (other.CompareTag("Toy"))
            {
                stats.happiness = Mathf.Min(stats.happiness + 20f, 100f);
                if (isServer) Destroy(other.gameObject);
            }
        }
    }
}
