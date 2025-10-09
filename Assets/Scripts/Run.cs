using UnityEngine;

public class Run : MonoBehaviour
{
    public float speed = 5f;
    public float accelationPerSecond = 1f;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        speed += accelationPerSecond * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(
            speed,
            rb.linearVelocity.y,
            rb.linearVelocity.z
            );
    }
}
