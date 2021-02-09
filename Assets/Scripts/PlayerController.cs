using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0f;
    Rigidbody rb;
    Touch firstTouch;
    Vector3 targetPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Input.gyro.enabled = true;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            firstTouch = Input.GetTouch(0);
            SetTargetPosition();
            MoveToTarget();
        }
    }

    void SetTargetPosition()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo))
        {
            targetPosition = hitInfo.point;
        }
    }
    void MoveToTarget()
    {
        this.transform.position = Vector3.MoveTowards(
            transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
