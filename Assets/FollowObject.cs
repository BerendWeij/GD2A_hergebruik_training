using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {

	[SerializeField]
	private GameObject followObject;

	[SerializeField]
	private float followDistance;

	[SerializeField]
	private float followSpeed;

	[SerializeField]
	private bool followRotation;

	private Vector3 targetPos;
	private Vector3 finalPos;
	private float targetRot;

	private Vector3 followAndRotateDistance;
	private Vector3 followAndRotateTargetPos;
	
	// Update is called once per frame
	void Update () {
		Follow ();
	}

	void Follow () {

		// Check if it should rotate

		if (followRotation == false) {

			/* First, get the position of the target.
			 * Secondly, calculate the distance from the target, with an offset
			 * Third and finally, lerp (smooth motion) the camera to the calculated position
			*/

			targetPos = followObject.transform.localPosition;
			finalPos = new Vector3 (targetPos.x, targetPos.y, targetPos.z - followDistance);

			transform.position = Vector3.Lerp (transform.position, finalPos, followSpeed * Time.deltaTime);

		} else {
			//Take the forward position of the object it's following, and goes followDistance in that direction
			followAndRotateDistance = followObject.transform.forward * followDistance;

			//Take the position of the object it's following, minus the distance in the right direction
			followAndRotateTargetPos = followObject.transform.position - followAndRotateDistance;

			//Move to the calculated position, and look at the object
			transform.position = Vector3.Lerp (transform.position, followAndRotateTargetPos, followSpeed * Time.deltaTime);
			transform.rotation = followObject.transform.rotation;
		}
	}
}
