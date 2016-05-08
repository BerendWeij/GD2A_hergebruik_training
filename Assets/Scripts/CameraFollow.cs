using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    //Camera Target to follow
    [SerializeField] private Transform followingObj;
    //Renderer of the following object
    private Renderer objRenderer;
    //How strong the camera will follow
    [SerializeField] private float tightness;
    //The rate at how fast the camera wil reach its target
    [SerializeField] private float swaySpeed;
    
    void Awake()
    {
        objRenderer = followingObj.GetComponent<Renderer>();
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(new Vector3(followingObj.position.x + 3, followingObj.position.y + 1, -10), transform.position, Mathf.Pow(0.98f, Time.deltaTime * swaySpeed * tightness));
    }

}
