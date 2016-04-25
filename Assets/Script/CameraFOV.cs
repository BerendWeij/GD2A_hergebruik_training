using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFOV : OverallCamera {

	[SerializeField] private float zoomSpeed = 10;		
	[SerializeField] private float targetFOV;			//Target Amount of FOV
	[SerializeField] private float smoothSpeed = 5.0f;	
	[SerializeField] private float minFOV = 1.0f;		
	[SerializeField] private float maxFOV = 60.0f;
	private float scroll;

	public void Start() {
		//Connects With The Main Camera
		targetFOV = Camera.main.orthographicSize;

	}

	void Update()
	{
		scroll = Input.GetAxis ("Mouse ScrollWheel");
		if (scroll != 0.0f) {
			targetFOV -= scroll * zoomSpeed;
			targetFOV = Mathf.Clamp (targetFOV, minFOV, maxFOV);
		}

		Camera.main.orthographicSize = Mathf.MoveTowards (Camera.main.orthographicSize, targetFOV, smoothSpeed * Time.deltaTime);
	}

}
