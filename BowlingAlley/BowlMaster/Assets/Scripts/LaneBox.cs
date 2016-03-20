﻿using UnityEngine;
using System.Collections;

public class LaneBox : MonoBehaviour {

    private PinSetter pinSetter;
	// Use this for initialization
	void Start () {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.GetComponent<Ball>() is Ball)
        {
            pinSetter.BallLeftBox = true;
        }
    }
}
