using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBall : Ball {

	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;
    public Follower cloud;
	private bool doubleJump=true;
    private bool isFrezed=false;
	public override void Jump(Rigidbody2D rb)
	{
		base.Jump(rb);
		
	   
	}
    private void Start()
    {
        cloud.SetFollower(this);
    }
    public override void Update()
	{
            base.Update();
        
            if (body.velocity.y < 0)
            {

                body.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (body.velocity.y > 0 && !Input.GetButton("Jump"))
            {

                body.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        
		
	}
	public override bool CanJump()
	{
		if (base.CanJump())
		{
			doubleJump = true;
			return true;
		}
		else
		{
		    
            if (doubleJump)
            {
                doubleJump = false;
                return true;
            }
            else
            {

                return false;
            }

        }
	}
	public override void SpecialAbility()
	{
        
        if (isFrezed)
        {
            isFrezed = false;
            
            body.constraints = RigidbodyConstraints2D.None;
        }
        else
        {
            isFrezed = true;
           

            body.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        cloud.ChangeState();

    }
    
    



	
	
}
