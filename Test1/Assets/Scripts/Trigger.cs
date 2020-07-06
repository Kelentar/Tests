using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Rigidbody2D rb;
    
    void Start()
    {
        rb.GetComponent<Rigidbody2D>().gravityScale = 0f;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.CompareTag("Player"))
        {
            rb.GetComponent<Rigidbody2D>().gravityScale = 3f;
        }
    }
}
