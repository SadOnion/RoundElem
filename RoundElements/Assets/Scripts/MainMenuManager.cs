using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour {

    public GameObject[] panels;
    public Button[] buttons;

    private int level;
	// Use this for initialization
	void Start () {

        level = GameManager.Instance.levelUnlocked;
        for (int i = 1; i < buttons.Length+1; i++)
        {
            if( level >= i)
            {
                buttons[i - 1].GetComponent<Button>().enabled = true;
            }
            else
            {
                buttons[i - 1].GetComponent<Button>().enabled = false;

            }
            
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeToMainMenu();
        }
	}

    public void ChangeToLevelSelect()
    {
        panels[1].SetActive(true);
        panels[0].SetActive(false);
    }
    public void ChangeToMainMenu()
    {
        panels[1].SetActive(false);
        panels[0].SetActive(true);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
