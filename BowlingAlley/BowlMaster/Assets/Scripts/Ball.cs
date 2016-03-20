using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public float LaunchSpeed;
    public bool InPlay;

    private Rigidbody RigidBody;
    private Vector3 defaultPosition;

    private AudioSource ballSound;

	// Use this for initialization
	void Start () {
        RigidBody = GetComponent<Rigidbody>();
        RigidBody.useGravity = false;
        ballSound = GetComponent<AudioSource>();
        defaultPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}

    public void Launch(Vector3 velocity)
    {
        RigidBody.useGravity = true;
        RigidBody.velocity = velocity;
        InPlay = true;
        ballSound.Play();
    }

    public void Reset()
    {
        InPlay = false;
        RigidBody.velocity = Vector3.zero;
        RigidBody.angularVelocity = Vector3.zero;
        this.transform.position = defaultPosition;
        RigidBody.useGravity = false;
        ballSound.Stop();

    }
	
}
