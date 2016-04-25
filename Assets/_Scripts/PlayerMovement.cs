using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    GameObject go_player;
    [SerializeField]
    float f_movementSpeed;
    Vector3 Rotation;

    void Start()
    {
        Rotation = new Vector3(0, 1, 0);
    }
	
	void Update () {
        MovementControls();
	}

    void MovementControls() {
        if (Input.GetKey(KeyCode.W))
        {
            go_player.GetComponent<Rigidbody>().AddForce(Vector3.forward * f_movementSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            go_player.GetComponent<Rigidbody>().AddForce(Vector3.back * f_movementSpeed);
        }

        else {
            go_player.GetComponent<Rigidbody>().AddForce(Vector3.zero);
        }


        if (Input.GetKey(KeyCode.A))
        {
            go_player.GetComponent<Rigidbody>().AddTorque(-Rotation);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            go_player.GetComponent<Rigidbody>().AddTorque(Rotation);
        }
        else {
            go_player.GetComponent<Rigidbody>().AddTorque(Vector3.zero);
        }
    }
}
