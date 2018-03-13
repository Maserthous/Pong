using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject ball;
    public Transform ballSpawn;

    public static GameController game;

    private bool ready;

	void Start () {
        game = this;
        ready = true;
	}
	
    private void CreateBall()
    {
        Instantiate(ball, ballSpawn.position, ballSpawn.rotation);
        Debug.Log("Ball created");
        ready = false;
    }

    private void Reset()
    {
        Destroy(GameObject.Find("Ball(Clone)"));
        ScoreController.score.Reset(); // Resets the scoreboard
        ready = true;
    }

    public void Score(int side) // 0 is left wall, 1 is right wall
    {
        if (side == 1)
            ScoreController.score.LeftPoint(); // Adds a point to left player
        else
            ScoreController.score.RightPoint(); // Adds a point to right player
        ready = true;
    }

    public void End()
    {
        ready = false; // Stops ball from launching after a player has won
    }

    void Update () {
		if (Input.GetButton("Launch") && ready)
        {
            CreateBall(); // Creates a ball
        }

        if (Input.GetButton("Reset"))
        {
            Reset(); // Resets the game
        }
    }
}
