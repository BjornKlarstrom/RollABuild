using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SwipeBallController : MonoBehaviour
{
    Vector3 startDragPos;
    float startDragTime;

    [SerializeField] float force = 1f;
    public Rigidbody rb;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.startDragPos = Input.mousePosition;
            this.startDragTime = Time.time;
        }

        if (Input.GetMouseButtonUp(0))
        {
            var dragTime = Time.time - this.startDragTime;
            var dragDirectionDistance = (Input.mousePosition - this.startDragPos) / Screen.dpi;
            var direction = Vector3.forward * dragDirectionDistance.y  + Vector3.right * dragDirectionDistance.x;
            this.rb.AddForce(direction * this.force / dragTime); 
        }
    }
}