using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // fields
    private Rigidbody2D rb2d;
    public Vector2 thrustDirection = new Vector2(1, 0);
    public const float ThrustForce = 4.0f;


    // Start is called before the first frame update
    void Start()
    {
        // attach rb2d to rigidbody
        rb2d = GetComponent<Rigidbody2D>();
    }


    // called once per frame -- synchronizes physics
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb2d.AddForce(thrustDirection * ThrustForce, ForceMode2D.Force);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
