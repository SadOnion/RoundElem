using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    public Sprite pressed;
    public Sprite notPressed;

    private bool isPressed = false;
    private SpriteRenderer spriteRenderer;



    public bool deleteGreen = false;
    public bool deleteBlue = false;
    public bool deleteRed = false;
    public bool deleteYellow = false;

    private readonly string green = "lock_green";
    private readonly string red = "lock_red";
    private readonly string blue = "lock_blue";
    private readonly string yellow = "lock_yellow";

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            spriteRenderer.sprite = pressed;
            isPressed = true;
            if (deleteGreen)
            {
                DisableObjectsWithTag(green, true);
            }
            if (deleteBlue)
            {
                DisableObjectsWithTag(blue, true);
            }
            if (deleteRed)
            {
                DisableObjectsWithTag(red, true);
            }
            if (deleteYellow)
            {
                DisableObjectsWithTag(yellow, true);
            }
        }
    }
    private void DisableObjectsWithTag(string tag,bool disable)
    {
        
        if (disable)
        {
            GameObject[] objectsToDisable = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject g in objectsToDisable)
            {
                g.GetComponent<BoxCollider2D>().enabled = false;
                g.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        else
        {
            GameObject[] objectsToDisable = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject g in objectsToDisable)
            {
                g.GetComponent<BoxCollider2D>().enabled = true;
                g.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            spriteRenderer.sprite = notPressed;
            isPressed = false;

            if (deleteGreen)
            {
                DisableObjectsWithTag(green, false);
            }
            if (deleteBlue)
            {
                DisableObjectsWithTag(blue, false);
            }
            if (deleteRed)
            {
                DisableObjectsWithTag(red, false);
            }
            if (deleteYellow)
            {
                DisableObjectsWithTag(yellow, false);
            }
        }
    }

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
	

}
