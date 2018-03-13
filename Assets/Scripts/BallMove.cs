using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {

    public float speed;
    public float angle;

    private Rigidbody2D rBody;
    private Vector2 movement;
    
    void Start () {

        float rand = Random.Range(0, 2);
        if (rand < 1)
            movement = new Vector2(1, -0.2f);
        else
            movement = new Vector2(-1, -0.2f);

        rBody = this.gameObject.GetComponent<Rigidbody2D>();
        rBody.velocity = movement * speed;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "PaddleRight")
        {
            float y = (transform.position.y - other.transform.position.y) * angle;

            movement = new Vector2(-1, y);
            rBody.velocity = movement * speed;
        }
        else if (other.gameObject.name == "PaddleLeft")
        {
            float y = (transform.position.y - other.transform.position.y) * angle;

            movement = new Vector2(1, y);
            rBody.velocity = movement * speed;
        }
        else
        {
            float y = rBody.velocity.y;
            movement = new Vector2(rBody.velocity.x, 0 - y);
            rBody.velocity = movement;
        }
    }
}
