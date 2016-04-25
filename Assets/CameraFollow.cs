using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    private float Distance;
    private float setDistance = 75f;
    private float SpeedX = 10f;
    private float SpeedY = 10f;
    private float MinLimitY = 10f;
    private float MaxLimitY = 110f;
    private float X = 0f;
    private float Y = 0f;
    private float distanceMin = 0.5f;
    private float distanceMax = 150f;

    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        X = angles.y;
        Y = angles.x;

        if (gameObject.GetComponent<Rigidbody>())
        {
            gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Raycast3.distance3;
        if (Distance > setDistance)
        {
            Distance = setDistance;
        }
        if (target)
        {
            X += Input.GetAxisRaw("Mouse X") * SpeedX;
            Y -= Input.GetAxisRaw("Mouse Y") * SpeedY;

            Y = ClampAngle(Y, MinLimitY, MaxLimitY);

            Quaternion rotation = Quaternion.Euler(Y, X, 0);

            Vector3 position = rotation * new Vector3(0, 0, -Distance) + target.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1.0f * Time.deltaTime);

            Raycast3.distance3 = Mathf.Clamp(Raycast3.distance3 - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

            RaycastHit hit;
            if (Physics.Linecast(target.position, this.transform.position, out hit))
            {
                Distance -= hit.distance;
            }

            transform.rotation = rotation;
            transform.position = position;
        }
    }
    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
