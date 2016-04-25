using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

    private float counter = 1;
    private Vector3 originalPosition;

    void Start () {
        originalPosition = transform.position;
	}
	
	void Update () {
        counter -= Time.deltaTime;
        if (counter > 0)
        {
            MakeShake();
        }
        else {
            counter = 0;
            transform.position = originalPosition;
        }
	}

    public void MakeShake()
    {
        float randomXValue = Random.Range(-5, 5);
        float randomYValue = Random.Range(-5, 5);
        transform.position = new Vector3(transform.position.x+(randomXValue/100),transform.position.y+(randomYValue/100),transform.position.z);
    }
}
