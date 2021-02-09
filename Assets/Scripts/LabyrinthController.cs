using UnityEngine;

public class LabyrinthController : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var horizontalForce = Input.acceleration.x;
        var verticalForce = Input.acceleration.y;

        rb.AddForce(horizontalForce * speed,0f,verticalForce * speed);
    }
}