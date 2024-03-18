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

    // collider radius
    public float circleRadius;


    // Start is called before the first frame update
    void Start()
    {
        // attach rb2d to rigidbody
        rb2d = GetComponent<Rigidbody2D>();
        circleRadius = GetComponent<CircleCollider2D>().radius;
        ScreenClamp.Initialize();
    }


    // called once per frame -- synchronizes physics
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb2d.AddForce(thrustDirection * ThrustForce, ForceMode2D.Force);
        }
    }


    // when ship is no longer visible to camera
    private void OnBecameInvisible()
    {
        //wrap ship around screen
        
        if (transform.position.x - circleRadius < ScreenClamp.ScreenLeft)
        {
            Debug.Log(ScreenClamp.ScreenLeft);
            Debug.Log(transform.position.x - circleRadius);
            transform.position = new Vector3(ScreenClamp.ScreenRight + circleRadius, transform.position.y, transform.position.z);

        }
        if (transform.position.x + circleRadius > ScreenClamp.ScreenRight)
        {
            transform.position = new Vector3(ScreenClamp.ScreenLeft, transform.position.y, transform.position.z);
        }
        if (transform.position.y - circleRadius < ScreenClamp.ScreenBottom)
        {
            transform.position = new Vector3(transform.position.x, ScreenClamp.ScreenTop + circleRadius, transform.position.z);
        }
        if (transform.position.y + circleRadius > ScreenClamp.ScreenTop)
        {
            transform.position = new Vector3(transform.position.x, ScreenClamp.ScreenBottom - circleRadius, transform.position.z);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
