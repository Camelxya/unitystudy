using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 1.5f;
    public float speedBoostMultiplier = 2f;
    public bool isGrounded = false;
    public float speedY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement *= speed * speedBoostMultiplier;
        }
        else
        {
            movement *= speed;
        }

        this.transform.position += movement*Time.deltaTime;
    }

    void Jump()
    {
        float movementY = 0;
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            speedY = jumpForce;
            isGrounded = false;
        }
        if (!isGrounded) 
        {
            speedY += Physics.gravity.y * Time.deltaTime;
        }
        if (isGrounded) 
        {
            speedY = 0;
        }
        movementY = speedY * Time.deltaTime;
        this.transform.position += new Vector3(0, movementY, 0);
    }
}
