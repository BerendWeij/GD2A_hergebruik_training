using UnityEngine;
using System.Collections;

public class CameraCutscene : MonoBehaviour {

	[SerializeField]
	private GameObject animateObject;

	[SerializeField]
	private CameraFollower cameraFollower;

	[SerializeField]
	private CameraShake cameraShake;

	[SerializeField]
	private GameObject animateObject2;


	void Update()
	{
		if (Input.GetKey (KeyCode.Space)) 
		{
			StartCoroutine(Cutscene());
		}
	}

	IEnumerator Cutscene()
	{
		cameraFollower.AnimateTo (animateObject);
		yield return new WaitForSeconds (2);
		cameraShake.StartShake ();
		yield return new WaitForSeconds (2);
		cameraShake.StartShake ();
		yield return new WaitForSeconds (2);
		cameraFollower.AnimateTo (animateObject2);

	}
}
