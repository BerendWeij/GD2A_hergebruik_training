using UnityEngine;

public class Navigator : NavigatorInterface
{
    Vector3 destination;
    GameObject obj;

    public void SetDest(Vector3 newDest, GameObject _obj)
    {
        destination = newDest;
        obj = _obj;
    }

	public void UpdatePosition ()
    {

        if (Vector3.Distance(obj.transform.position, destination) < 1)
        {
            destination = new Vector3(Random.Range(0, 50), Random.Range(0, 50));
        }

        obj.transform.LookAt(destination);
        obj.transform.Translate(obj.transform.forward * 0.5f);
    }
}
