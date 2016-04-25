using UnityEngine;
using System.Collections;

/*
 * This script will follow the target gameobject
 * height and distance variables indicate the height of wich the camera will follow the target
 */

public class Tracker : MonoBehaviour {

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float delay = 0.80f;

    [SerializeField]
    private float height, trackDistance;

    void FixedUpdate()
    {
        Track(target);
    }

    void Track(GameObject trackTarget)
    {
        Vector3 moveCam = trackTarget.transform.position - trackTarget.transform.forward * trackDistance + Vector3.up * height;

        transform.LookAt(trackTarget.transform);
        transform.position = transform.position * delay + moveCam * (1f - delay);
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }
}
