using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private Camera camera;

    public float rotationspeed = 1f;
    public float speed = 0.1f;

    private Vector3 initialPosition;
	// Use this for initialization
	void Start () {
        initialPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        camera.transform.LookAt(target.transform);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(target.transform.position, Vector3.down, rotationspeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(target.transform.position, Vector3.up, rotationspeed);
        }
	}
}
