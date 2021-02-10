using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToShoot : MonoBehaviour
{
    [SerializeField] float force;
    float ballForce;
    Rigidbody rb;
    LineRenderer lr;

    [SerializeField] Vector3 minForce;
    [SerializeField] Vector3 maxForce;

    Vector3 startPoint;
    Vector3 endPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            var currentPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //DrawLine(startPoint, currentPoint);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    /*void DrawLine(Vector3 startPoint, Vector3 endPoint)
    {
        throw new NotImplementedException();
    }*/
}
