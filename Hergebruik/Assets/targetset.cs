using UnityEngine;
using System.Collections;

/*
 * this script sucks
 */

public class targetset : MonoBehaviour {

    private Tracker tracker;

    void Start()
    {
        tracker = GameObject.FindWithTag("MainCamera").GetComponent<Tracker>();
    }

	void OnMouseDown()
    {
        tracker.SetTarget(gameObject);
    }
}
