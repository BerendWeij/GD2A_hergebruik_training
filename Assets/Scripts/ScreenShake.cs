using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour
{
    //Attach here the Camera that you want to shake
    [SerializeField] private Camera camera;
    //The position of the Camera
    private Transform cameraPos;
    //The length of the shake
    [SerializeField] private float shakeDuration;
    //How intense the Camera will shake
    [SerializeField] private float shakeAmount = 0.25f;
    //How quickly the effect will fade away
    [SerializeField] private float shakeDecrease = 1;
    //The random x and y that we will give the Camera
    private Vector2 shakePos;

    void Start()
    {
        //Taking the Transform from the Camera
        cameraPos = camera.GetComponent<Transform>();
    }

	void Update ()
    {
        //Testing Shake
        StartShake();

        if (shakeDuration > 0)
        {
            shakePos = Random.insideUnitSphere * shakeAmount;
            camera.transform.position = new Vector3(shakePos.x + cameraPos.position.x, shakePos.y + cameraPos.position.y, camera.transform.position.z);
            shakeDuration -= Time.deltaTime * shakeDecrease;
        }
        else
            shakeDuration = 0;
	}

    //To test the shake press SPACEBAR
    private void StartShake()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            shakeDuration++;
    }
}
