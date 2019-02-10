using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShower : MonoBehaviour {

    public GameObject[] prefabs;
    private SpriteRenderer spriteRenderer;
    
    private Sprite currentSprite;
    private Sprite blank;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        blank = spriteRenderer.sprite;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetObjectToDisplay()
    {
        
        currentSprite = prefabs[0].GetComponent<SpriteRenderer>().sprite;
        spriteRenderer.sprite = currentSprite;
    }
    public void PopObject()
    {
        spriteRenderer.sprite = blank;
        Instantiate(prefabs[0], transform.position, Quaternion.identity);
    }
}
