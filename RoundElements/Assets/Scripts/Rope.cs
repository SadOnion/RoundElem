using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {

    [SerializeField]
    private float health;


    private void OnTriggerStay2D(Collider2D collision)
    {
        health -= Time.deltaTime;
    }



    // Update is called once per frame
    void Update () {
     
        if (health <= 0) Destroy(gameObject);
	}
}
