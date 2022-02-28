using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField] float speed;
    float maxSpeed;

    private void Start() 
    {
        maxSpeed = speed;
        body = GetComponent<Rigidbody2D>();
    }
    private void Update() 
    {
        Vector2 movementVector = Vector2.zero;
        if(Input.GetKey(KeyCode.W))
        {
            movementVector += new Vector2(0,1);
        }
        if(Input.GetKey(KeyCode.A))
        {
            movementVector += new Vector2(-1,0);
        }
        if(Input.GetKey(KeyCode.S))
        {
            movementVector += new Vector2(0,-1);
        }
        if(Input.GetKey(KeyCode.D))
        {
            movementVector += new Vector2(1,0);
        }
        movementVector.Normalize();
        body.MovePosition((Vector2)transform.position + movementVector * speed);

        Camera.main.transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        if(transform.position.y >= Camera.main.transform.position.y)
        {
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        }

        Quaternion target = Quaternion.FromToRotation(transform.up, movementVector) * transform.rotation;
        float turnSpeed = 0.2f;
        target = new Quaternion(0,
                                0,
                                Mathf.Lerp(transform.rotation.z, target.z, turnSpeed),
                                Mathf.Lerp(transform.rotation.w, target.w, turnSpeed));
        /*target = new Quaternion(Mathf.Lerp(transform.rotation.x, target.x, turnSpeed),
                                Mathf.Lerp(transform.rotation.y, target.y, turnSpeed),
                                Mathf.Lerp(transform.rotation.z, target.z, turnSpeed),
                                Mathf.Lerp(transform.rotation.w, target.w, turnSpeed));*/

        transform.rotation = target;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Puddle"))
        {
            speed *= 0.5f;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Puddle"))
        {
            speed = maxSpeed;
        }
    }
}
