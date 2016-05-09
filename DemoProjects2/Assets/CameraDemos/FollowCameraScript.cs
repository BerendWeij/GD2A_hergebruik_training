using UnityEngine;
using System.Collections;

public class FollowCameraScript : MonoBehaviour
{

    //in order to make a follow function that is reusable i must get the position from an object, this must be done continuaslly.
    //how is the question.

    public GameObject Target;


	void Start ()
    {
	    
	}
	
	
	void Update ()
    {
	    
	}

    void TurnOnBrain()
    {
        if (BrainOn == true)
        {
            Debug.Log("starting up");
        }
    }
}
