using UnityEngine;
using System.Collections;

public class CameraBehaviourScript : MonoBehaviour {

    //Made by Danny Kruiswijk

    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    bool rotate;
    [SerializeField]
    private float rotationSpeed;

    void Start () {
        transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, target.position.z + offset.z);
    }
	
	void Update () {
        if (rotate)
        {
            float playerAngle = AngleOnXZPlane(target);
            float cameraAngle = AngleOnXZPlane(transform);
            float rotationDiff = Mathf.DeltaAngle(cameraAngle, playerAngle);
            transform.RotateAround(target.position, Vector3.up, rotationDiff * Time.deltaTime*rotationSpeed);
        }
        else
        {
            transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, target.position.z + offset.z);
            transform.LookAt(target);
        }
    }

    private float AngleOnXZPlane(Transform item)
    {
        Vector3 direction = item.rotation * item.forward;
        return Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
    }
}