using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

    public int LastStandingCount = -1;
    public int CurrentStandingCount = 10;
    public Text TextCount;
    public bool BallLeftBox = false;
    public GameObject Pinset;

    private float LastChangeTime;
    private Ball ball;
    private int lastSettledCount = 10;
    private ActionMaster actionMaster;
    private Animator animator;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
        actionMaster = new ActionMaster();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(BallLeftBox)
        {
            CurrentStandingCount = CountStanding();
            TextCount.text = CurrentStandingCount.ToString();
            TextCount.color = Color.red;
            CheckStanding();
        }
	}

    void CheckStanding()
    {
        if (CurrentStandingCount != LastStandingCount)
        {
            LastChangeTime = Time.time;
            LastStandingCount = CurrentStandingCount;
            return;
        }
        if (Time.time > LastChangeTime + 3f)
        {
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled()
    {
        int countStanding = CountStanding();
        int pinFall = lastSettledCount - countStanding;
        lastSettledCount = countStanding;
        var action = actionMaster.Bowl(pinFall);
        if(action == ActionMaster.BowlResult.Tidy)
        {
            animator.SetTrigger("TidyTrigger");

        } else if (action == ActionMaster.BowlResult.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        }

        ball.Reset();
        LastStandingCount = -1;
        BallLeftBox = false;
        TextCount.color = Color.green;
    }

    public void RaisePins()
    {
        Pin[] pins = GameObject.FindObjectsOfType<Pin>();
        foreach (var pin in pins)
        {
            pin.Raise();
        }
    }

    public void LowerPins()
    {
        Pin[] pins = GameObject.FindObjectsOfType<Pin>();
        foreach (var pin in pins)
        {
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        Instantiate(Pinset, new Vector3(0, 20, 1829), Quaternion.identity);
    }

    public int CountStanding()
    {
        int standingPins = 0;
        Pin[] pins = GameObject.FindObjectsOfType<Pin>();
        foreach(var pin in pins)
        {
            if(pin.IsStanding())
            {
                standingPins++;
            }
        }
        return standingPins;
    }


    void OnTriggerExit(Collider collider)
    {
        GameObject thingLeft = collider.gameObject;
        if(thingLeft.GetComponent<Pin>())
        {
            Destroy(thingLeft);
        }
    }


}
