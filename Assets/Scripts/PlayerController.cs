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
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            firstTouch = Input.GetTouch(0);
        }
    }

    Vector3 SetTargetPosition()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo))
        {
            this.transform.position = hitInfo.point;
        }
    }
}
