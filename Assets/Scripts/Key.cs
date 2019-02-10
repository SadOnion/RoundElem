using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Key : MonoBehaviour {

    public bool deleteGreen = false;
    public bool deleteBlue = false;
    public bool deleteRed = false;
    public bool deleteYellow = false;

    private readonly string green = "lock_green";
    private readonly string red = "lock_red";
    private readonly string blue = "lock_blue";
    private readonly string yellow = "lock_yellow";


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (deleteGreen)
            {
                DeleteObjectsWithTag(green);
            }
            if (deleteBlue)
            {
                DeleteObjectsWithTag(blue);
            }
            if (deleteRed)
            {
                DeleteObjectsWithTag(red);
            }
            if (deleteYellow)
            {
                DeleteObjectsWithTag(yellow);
            }
            Destroy(gameObject);

        }
    }
    private void DeleteObjectsWithTag(string tag)
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject g in objectsToDestroy)
        {
            Destroy(g);
        }
    }
}
