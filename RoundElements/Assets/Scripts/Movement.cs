using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

   

    private Ball ball;
    private Rigidbody2D body;
	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (ball.isActive)
        {
            float xAxis = Input.GetAxis("Horizontal");
            body.velocity = new Vector2(xAxis * ball.speed * Time.deltaTime, body.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && ball.isActive)
            if (ball.CanJump()) ball.Jump(body);
        if(Input.GetButtonDown("Fire1") && ball.isActive)
        {
            ball.SpecialAbility();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.Instance.RetryLevel();
        }

    }
   
}
