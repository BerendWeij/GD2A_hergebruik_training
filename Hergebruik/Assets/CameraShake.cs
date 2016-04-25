using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

    private float lightShakePower = 0.05f;
    private float heavyShakePower = 0.2f;
    //private float duration = 0.5f;
    private bool isLightShaking = false;
    private bool isHeavyShaking = false;
	
	void Update () 
    {
        //shake camera
        if(isLightShaking)
        {
            transform.localPosition = transform.localPosition + Random.insideUnitSphere * lightShakePower;
        }else if(isHeavyShaking)
        {
            transform.localPosition = transform.localPosition + Random.insideUnitSphere * heavyShakePower;
        }
	}

    //allow camera shaking  fill in duration as paramater to determine how long screen shake will be active
    public void LightShake(float duration)
    {
        isLightShaking = true;
        CancelInvoke();
        Invoke("StopShaking", duration);
    }

    public void HeavyShake(float duration)
    {
        isHeavyShaking = true;
        CancelInvoke();
        Invoke("StopShaking", duration);
    }

    //disallow camera shaking
    public void StopShaking()
    {
        isLightShaking = false;
        isHeavyShaking = false;
    }
}
