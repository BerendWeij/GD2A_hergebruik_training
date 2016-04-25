using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {

	[SerializeField]
	private GameObject objectToFollow;

	[SerializeField]
	private GameObject animateObject;

	[SerializeField]
	private Vector3 offset;

	[SerializeField]
	private float positionSmoothTime;
	
	void Update () 
	{
		Vector3 velocity = Vector3.zero;
		Vector3 cameraDestination = new Vector3 (objectToFollow.transform.position.x+offset.x, objectToFollow.transform.position.y+ offset.y, objectToFollow.transform.position.z + offset.z);
		this.transform.position = Vector3.SmoothDamp (transform.position, cameraDestination, ref velocity, positionSmoothTime);
	}

	public void AnimateTo(GameObject _objectToAnimateTo)
	{
		objectToFollow = _objectToAnimateTo;

	}
}
