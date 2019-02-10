using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ball : MonoBehaviour {
    public bool isActive;
    public int speed;
    public int jumpForce;

    private bool isGrounded=true;
    private bool isInWater = false;
    protected Rigidbody2D body;
    public virtual void Jump(Rigidbody2D body)
    {
            body.velocity = Vector2.up * jumpForce;
    }
    public virtual bool CanJump()
    {
        if ( isGrounded || isInWater)
        {
            return true;
        }
        else return false;
    }
    private void Awake()
    {
        GameManager.Instance.AddBall(this);
        body = GetComponent<Rigidbody2D>();
    }
      public virtual void Update() {

        RaycastHit2D info = Physics2D.Raycast(transform.position, Vector2.down,GetComponent<CircleCollider2D>().radius+0.25f);
        
        if (info.collider == null)
        {
            isGrounded = false;
        }
        else
        {
            

            if (info.collider != GetComponent<Collider2D>())
            {
                isGrounded = true;

            }
        }
    }
    
    public void SetActivation(bool b)
    {
        isActive = b;
    }
    public abstract void SpecialAbility();
    public virtual void Evaporate()
    {


        SetActivation(false);
        GameManager.Instance.RetryLevel();
        
        if (GameManager.Instance.focusedBall != this)
        {

            gameObject.SetActive(false);
        }
        else
        {
            GameManager.Instance.DeleteBall();
        }
        
        Destroy(gameObject);
    }
    public void SetIsInWater(bool value)
    {
        isInWater = value;
    }
}
