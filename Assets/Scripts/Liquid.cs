using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : MonoBehaviour {

    public bool water;
    public bool lava;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Ball>().SetIsInWater(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Ball>().SetIsInWater(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            Ball b = collision.GetComponent<Ball>();
            if (b is FireBall && water)
            {
                b.Evaporate();
            }
            if((b is WaterBall || b is WindBall) && lava)
            {
                b.Evaporate();
            }
        }
    }

   
}
