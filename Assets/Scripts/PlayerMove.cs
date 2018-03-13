using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public string controlType; //Vertical or Vertical2
    public float speed;

    private Rigidbody2D rBody;


	void Start () {
		
	}
	
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float moveVertical = Input.GetAxis(controlType);

        Vector2 movement = new Vector2(0, moveVertical);

        rBody = this.gameObject.GetComponent<Rigidbody2D>();
        rBody.velocity = movement * speed;
    }
}
