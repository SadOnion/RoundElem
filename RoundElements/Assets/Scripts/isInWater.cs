using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isInWater : MonoBehaviour {

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
}
