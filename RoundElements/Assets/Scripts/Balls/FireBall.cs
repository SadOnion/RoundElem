using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Ball {
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public Follower fire;

    
    public override void SpecialAbility()
    {
        fire.ChangeState();
        
    }

    private void FixedUpdate()
    {
        if (body.velocity.y < 0)
        {

            body.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (body.velocity.y > 0 && !Input.GetButton("Jump"))
        {

            body.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    // Use this for initialization
    void Start () {
        fire.SetFollower(this);
	}
	
	
}
