using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    Transform target;
    [SerializeField]
    float distance;
    [SerializeField]
    float height;
    [SerializeField]
    float heightDamping;
    [SerializeField]
    float rotationDamping;
    [SerializeField]
    bool canRotate;

	
	void LateUpdate () {
        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;
        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        if (canRotate)
        {
            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        }
        else {
            currentRotationAngle = 0;
        }
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;
        Vector3 temp = transform.position;
        temp.y = currentHeight;
        transform.position = temp;

        transform.LookAt(target);
    }


}
