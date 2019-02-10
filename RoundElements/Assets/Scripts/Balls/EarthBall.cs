using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBall : Ball {


    float direction;

    private CircleCollider2D circle;
    public override void SpecialAbility()
    {
        Vector3 desirePosition = transform.position;
        desirePosition += new Vector3(2*direction, 0, 0);

        if(CanTeleport(desirePosition))
        {
            Teleport(desirePosition);
        }

        
    }

    // Use this for initialization
    void Start () {
        circle = GetComponent<CircleCollider2D>();
	}

    public override void Update()
    {
        base.Update();
        direction = Input.GetAxisRaw("Horizontal");
    }

    private void Teleport(Vector3 vec)
    {
        transform.position = vec;
    }
    private bool CanTeleport(Vector3 desirePosition)
    {
        RaycastHit2D infoUp = Physics2D.Raycast(desirePosition, Vector2.up, circle.radius + .5f);
        RaycastHit2D infoRight = Physics2D.Raycast(desirePosition, Vector2.right, circle.radius + .1f);
        RaycastHit2D infoDown = Physics2D.Raycast(desirePosition, Vector2.down, circle.radius);
        RaycastHit2D infoLeft = Physics2D.Raycast(desirePosition, Vector2.left, circle.radius+.1f);
        Debug.DrawRay(desirePosition, Vector2.up, Color.red,.5f);
        
        
            List<RaycastHit2D> lista = new List<RaycastHit2D>();
            lista.Add(infoDown);
            lista.Add(infoLeft);
            lista.Add(infoRight);
            lista.Add(infoUp);
            foreach (RaycastHit2D info in lista)
            {
                Debug.Log(info.collider);
                if (info.collider != null && !info.collider.isTrigger)
                {
                    Debug.Log("dd");
                    return false;
                }
            }
            return true;
        

    }

}
