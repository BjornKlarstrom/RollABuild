using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMoveController : MonoBehaviour
{
    public float speed;
    public Joystick joystick;
    public Rigidbody rb;
    void FixedUpdate()
    {
        var direction = Vector3.forward * this.joystick.Vertical + Vector3.right * this.joystick.Horizontal;
        this.rb.AddForce(direction * (speed * Time.fixedDeltaTime), ForceMode.VelocityChange);
    }
}