using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private float speed;
    public float Speed { get { return speed; }  set { speed = value; } }    // ENCAPSULATION
    protected Rigidbody rigidbody;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform.Rotate(Vector3.up * Random.Range(0, 360));
        Speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()  // ABSTRACTION
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fence") || collision.gameObject.CompareTag("Animal"))
        {
            // turn to other direction when hit fence
            Turn(collision);
        }
    }

    protected virtual void Turn(Collision collision)    // ABSTRACTION
    {
        if (collision.contactCount > 0)
        {
            Debug.DrawRay(collision.contacts[0].point, collision.contacts[0].normal * 2, Color.red, 5f);
            // turn to other direction
            float normalAngle = Vector3.Angle(collision.contacts[0].point, collision.contacts[0].normal * 1);
            float minAngle = normalAngle - 80;
            float maxAngle = normalAngle + 80;
            float angle = Random.Range(minAngle, maxAngle);
            transform.Rotate(0, angle, 0);
        }
    }
}
