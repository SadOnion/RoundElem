using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    Rigidbody2D b;
    public float torque;
	// Use this for initialization
	void Start () {
        b = GetComponent<Rigidbody2D>();
        
    }
	
	// Update is called once per frame
	void Update () {
        b.rotation += Time.deltaTime*torque;
    }
}
