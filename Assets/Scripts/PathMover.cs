using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PathMover : MonoBehaviour
{
    [SerializeField] float acceleration;
    Rigidbody rb;
    Queue<Vector3> pathPositions = new Queue<Vector3>();
    bool isMoving;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hitInfo, 200, LayerMask.GetMask("Ground")))
            {
                pathPositions.Enqueue(hitInfo.point);

                if (!isMoving)
                {
                    StartCoroutine(MoveAlongPath());
                    Debug.Log(hitInfo.point);
                }
            }
        }
    }
    IEnumerator MoveAlongPath()
    {
        isMoving = true;
        while (pathPositions.Count > 0)
        {
            var nextPosition = pathPositions.Dequeue();

            while (Mathf.Abs((this.transform.position - nextPosition).magnitude) >= 1f)
            {
                rb.velocity += (nextPosition - this.transform.position).normalized * (acceleration * Time.deltaTime);
                yield return null;
            }
        }
        
        isMoving = false;
    }
}
