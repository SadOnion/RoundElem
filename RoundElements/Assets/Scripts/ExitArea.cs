using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitArea : MonoBehaviour {

	public string element;

	public bool isReady { get; private set; }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			switch (element)
			{
				case "water":
					if (collision.GetComponent<WaterBall>() != null) isReady = true;
					break;
				case "fire":
					if (collision.GetComponent<FireBall>() != null) isReady = true;
					break;
				case "earth":
					if (collision.GetComponent<EarthBall>() != null) isReady = true;
					break;
				case "wind":
					if (collision.GetComponent<WindBall>() != null) isReady = true;
					break;

			}
            GameManager.Instance.CheckForEndLevel();
		}
	}
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (element)
            {
                case "water":
                    if (collision.GetComponent<WaterBall>() != null) isReady = false;
                    break;
                case "fire":
                    if (collision.GetComponent<FireBall>() != null) isReady = false;
                    break;
                case "earth":
                    if (collision.GetComponent<EarthBall>() != null) isReady = false;
                    break;
                case "wind":
                    if (collision.GetComponent<WindBall>() != null) isReady = false;
                    break;

            }
        }
    }
    // Use this for initialization
    void Start () {
        GameManager.Instance.AddExit(this);
	}
	
	
}
