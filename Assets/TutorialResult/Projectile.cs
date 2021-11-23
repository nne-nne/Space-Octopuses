using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 1;

    public float timeToDisappear = 3;

    private Rigidbody rb;
    
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void Shoot(Vector3 direction)
    {
        rb.AddForce(direction * speed);
    }
    
    void Update()
    {
        timeToDisappear -= Time.deltaTime;

        if (timeToDisappear <= 0)
        {
            Destroy(gameObject);
        }
    }
}
