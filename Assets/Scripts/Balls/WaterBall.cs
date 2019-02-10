using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBall : Ball {
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public Follower bubble;

    private ItemShower itemShower;
    private bool isHoldingItem = false;
    List<Collider2D> list;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            list.Add(collision);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            list.Remove(collision);
        }
    }

    public override void SpecialAbility()
    {
        if (isHoldingItem)
        {
            bubble.ChangeState();
            isHoldingItem = false;
            Pop();
        }
        else
        {
            if (list.Count > 0)
            {
                PickUp();
                bubble.ChangeState();
                isHoldingItem = true;
            }
        }
        
       
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
        bubble.SetFollower(this);
        list = new List<Collider2D>();
        itemShower = FindObjectOfType<ItemShower>().GetComponent<ItemShower>();
    }
    public void PickUp()
    {
        GameObject g = list[0].gameObject;
        
        itemShower.SetObjectToDisplay();
        Destroy(g);

    }
    public void Pop()
    {
        itemShower.PopObject();
    }

    


}
