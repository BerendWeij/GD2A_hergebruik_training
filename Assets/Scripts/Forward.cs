using UnityEngine;
using System.Collections;

public class Forward : MonoBehaviour
{
    private Rigidbody rb;
    private bool canPush;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            canPush = true;
        else
            canPush = false;
    }

	void FixedUpdate ()
    {
        if (canPush)
            rb.velocity = new Vector2(6, rb.velocity.y);
	}
}
