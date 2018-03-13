using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour {

    public float speed;

    float targetY, thisY, moveY;

    private Rigidbody2D rBody;
    int timer;

    void Start () {
        timer = 0;
	}

	void FixedUpdate () {
        GameObject ball = GameObject.Find("Ball(Clone)");
        targetY = ball.transform.position.y;
        thisY = transform.position.y;
        if (targetY - thisY > 0.5) 
            moveY = 1;
        if (targetY - thisY < -0.5)
            moveY = -1;

        timer++;
        if (timer >= 30)
        {
            speed = Random.Range(3, 8);
            timer = 0;
        }

        Vector2 movement = new Vector2(0, moveY);
        rBody = this.gameObject.GetComponent<Rigidbody2D>();
        rBody.velocity = movement * speed;

    }
}
