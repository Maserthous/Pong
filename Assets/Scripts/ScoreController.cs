using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public Text scoreLeft;
    public Text scoreRight;
    public Text winner;

    public static ScoreController score;

    public int leftPoints;
    public int rightPoints;

    void Start () {
        score = this;
        leftPoints = 0;
        rightPoints = 0;
	}
	
	void Update () {
		if (leftPoints >= 10)
        {
            winner.text = "Left Player Wins";
            GameController.game.End();
        }
        if (rightPoints >= 10)
        {
            winner.text = "Right Player Wins";
            GameController.game.End();
        }
	}

    public void LeftPoint()
    {
        leftPoints++;
        scoreLeft.text = "" + leftPoints;
    }

    public void RightPoint()
    {
        rightPoints++;
        scoreRight.text = "" + rightPoints;
    }

    public void Reset()
    {
        leftPoints = 0;
        scoreLeft.text = "" + leftPoints;
        rightPoints = 0;
        scoreRight.text = "" + rightPoints;
        winner.text = "";
    }
}
