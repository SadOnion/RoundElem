using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaChase : MonoBehaviour {
    public float speed;
    public int yMax;
    float x=0;
    Rigidbody2D body;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.y < yMax)
        {
            x += Time.deltaTime;

            body.velocity = Vector2.up * Mathf.Log10(x) * speed;
        }
        else
        {
            body.velocity = Vector2.zero;
        }
        
	}
}
