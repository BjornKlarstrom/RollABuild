using UnityEngine;
public class MoveToTouchController : MonoBehaviour
{
    [SerializeField] float force = 10f;
    Rigidbody rb;
    Vector3 targetPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPosition = rb.position;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveTowardsTarget(SetTargetPosition());
        }
    }
    void MoveTowardsTarget(Vector3 target)
    {
        var directionDistance = (this.targetPosition - rb.position) / Screen.dpi;
        var direction = Vector3.forward * directionDistance.z  + Vector3.right * directionDistance.x;
        this.rb.AddForce(direction * this.force, ForceMode.Impulse);
    }
    Vector3 SetTargetPosition()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out var hitInfo))
        {
            this.targetPosition = hitInfo.point;
            return hitInfo.point;
        }
        return rb.position;
    }
}
