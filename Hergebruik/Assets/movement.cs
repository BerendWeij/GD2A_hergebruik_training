using UnityEngine;
using System.Collections;

/*
 * this scripts sucks
 */

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(KeyboardInput))]
public class movement : MonoBehaviour {

    private Rigidbody rb;
    private KeyboardInput input;
    private CameraShake camShake;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        input = GetComponent<KeyboardInput>();
        camShake = GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (input.up == true)
        {
            rb.AddForce(Vector3.forward * 5);
        }
        if (input.down == true)
        {
            rb.AddForce(-Vector3.forward * 5);
        }
        if (input.left == true)
        {
            rb.AddForce(Vector3.left * 5);
        }
        if (input.right == true)
        {
            rb.AddForce(Vector3.right * 5);
        }

        if(input.arrowLeft == true)
        {
            transform.Rotate(new Vector3(0, -20, 0) * Time.deltaTime);
        }
        if(input.arrowRight == true)
        {
            transform.Rotate(new Vector3(0, 20, 0) * Time.deltaTime);
        }

        if(input.shift == true)
        {
            camShake.HeavyShake(1f);
        }
    }
}
