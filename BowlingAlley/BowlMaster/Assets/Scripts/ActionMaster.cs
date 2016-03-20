using UnityEngine;
using System.Collections;

public class ActionMaster  {

    public enum BowlResult { Tidy, EndTurn, EndGame, Error}
    public int bowl = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public BowlResult Bowl(int pinsDown)
    {
        if(pinsDown == 10)
        {
            if(bowl %2 != 0)
            {
                bowl = bowl + 2;
            }
            else
            {
                bowl = bowl + 1;
            }

            return BowlResult.EndTurn;
        }
        //if first bowl of frame and less than 10, then tidy
        if(bowl % 2 != 0 && pinsDown <10 && pinsDown >=0)
        {
            bowl = bowl + 1;
            return BowlResult.Tidy;
        }
        else if(bowl % 2 == 0)
        {
            bowl = bowl + 1;
            return BowlResult.EndTurn;
        }

        return BowlResult.Error;
    }
}
