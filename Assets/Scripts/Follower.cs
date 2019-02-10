using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {

    public Vector3 offset;

    private Transform objectToFollow;
    private SpriteRenderer sr;
    private BoxCollider2D box;

    private void Start()
    {
        
        sr = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
        ChangeState();
    }
    // Update is called once per frame
    void Update () {
        if(objectToFollow != null)
        transform.position = objectToFollow.position + offset;
	}
    public void SetFollower(Ball b)
    {
        objectToFollow = b.transform;
    }
    public void ChangeState()
    {
        sr.enabled = !sr.enabled;
        box.enabled = !box.enabled;
    }
}
