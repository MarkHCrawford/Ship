using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // fields
    private Rigidbody2D rb2d;
    public Vector2 thrustDirection = new Vector2(1, 0);
    public const float ThrustForce = 4.0f;
    public const float RotateDegreesPerSecond = 90;
    private float rotationInput;

    // collider radius
    public float circleRadius;


    // Start is called before the first frame update
    void Start()
    {
        ScreenClamp.Initialize();
        // attach rb2d to rigidbody
        rb2d = GetComponent<Rigidbody2D>();
        circleRadius = GetComponent<CircleCollider2D>().radius;
    }


    // called once per frame -- synchronizes physics
    private void FixedUpdate()
    {
        // get rotation input
        rotationInput = Input.GetAxis("Rotate");

        //rotate ship to propel direction of rotation
        if (rotationInput != 0)
        {
            float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
            if (rotationInput < 0)
            {
                rotationAmount *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmount);
        }

        // update thrust direction
        thrustDirection = new Vector2(Mathf.Cos
            (transform.eulerAngles.z * Mathf.Deg2Rad),
            Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad));

        // apply thrust
        if (Input.GetKey(KeyCode.Space))
        {
            rb2d.AddForce(thrustDirection * ThrustForce, ForceMode2D.Force);
        }
    }


    // when ship is no longer visible to camera
    private void OnBecameInvisible()
    {
        //wrap ship around screen
        
        if (transform.position.x < ScreenClamp.ScreenLeft)
        {
            
            transform.position = new Vector3(ScreenClamp.ScreenRight, transform.position.y, transform.position.z);

        }
        if (transform.position.x  > ScreenClamp.ScreenRight)
        {
            transform.position = new Vector3(ScreenClamp.ScreenLeft, transform.position.y, transform.position.z);
        }
        if (transform.position.y < ScreenClamp.ScreenBottom)
        {
            transform.position = new Vector3(transform.position.x, -ScreenClamp.ScreenBottom, transform.position.z);
        }
        if (transform.position.y > ScreenClamp.ScreenTop)
        {
            transform.position = new Vector3(transform.position.x, ScreenClamp.ScreenBottom, transform.position.z);
        }
    }



}
