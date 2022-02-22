using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField] float speed;

    private void Start() 
    {
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
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }
}
