using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {

    private Ball ball;
    private Vector3 startDragPosition;
    private Vector3 endDragPosition;
    private float startTime, endTime;
	// Use this for initialization
	void Start () {

        ball = this.GetComponent<Ball>();
	}
	
    public void DragStart()
    {
        startDragPosition = Input.mousePosition;
        startTime = Time.time;
    }

    public void MoveStart(float amount)
    {
        if (ball.InPlay) return;
        ball.transform.Translate(new Vector3(amount, 0));
    }

    public void DragEnd()
    {
        endDragPosition = Input.mousePosition;
        endTime = Time.time;

        float duration = endTime - startTime;
        float launchSpeedx = (endDragPosition.x - startDragPosition.x) / duration;
        float launchSpeedz = (endDragPosition.y - startDragPosition.y) / duration;
        Vector3 launchVelocity = new Vector3(launchSpeedx, 0, launchSpeedz);

        ball.Launch(launchVelocity);
    }
}
