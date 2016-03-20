using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

    public float StandingThreshold = 3f;
    private float distanceToRaise = 40f;
    private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public bool IsStanding()
    {
        Vector3 rotation = transform.rotation.eulerAngles;
        float tiltInX = Mathf.Abs(270 - rotation.x);
        float tiltInZ = Mathf.Abs(rotation.z);
        if(tiltInX > StandingThreshold || tiltInZ > StandingThreshold)
        {
            return false;
        }
        return true;
    }

    public void Raise()
    {
        if (IsStanding())
        {
            rigidbody.useGravity = false;
            this.transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
        }
    }

    public void Lower()
    {
        this.transform.Translate(new Vector3(0, -distanceToRaise, 0), Space.World);
        rigidbody.useGravity = true;
    }

    public void Renew()
    {

    }
}
