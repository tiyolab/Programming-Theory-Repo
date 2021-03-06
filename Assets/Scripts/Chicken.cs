using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Animal   // INHERITANCE
{
    private float jumpPower = 8;
    private bool isOnTheGround = true;
    protected override void Turn(Collision collision)   // POLYMORPHISM
    {
        base.Turn(collision);
        if (collision.contactCount > 0 && isOnTheGround)
        {
            // also do jump
            rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isOnTheGround = false;
        }
    }

    protected override void OnCollisionEnter(Collision collision)   // POLYMORPHISM
    {
        base.OnCollisionEnter(collision);
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
        }
    }
}
