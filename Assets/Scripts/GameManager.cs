using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour {

    public KeyCode switchKey = KeyCode.LeftControl;
    public Ball focusedBall;
    public int levelUnlocked=1;
    private SerializationManager IO;

    private List<ExitArea> exits;
    private Queue<Ball> balls;
    private CameraMovement camMove;
    #region` 
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject o = new GameObject("GameManager");
                o.AddComponent<GameManager>();
               
            }
            return _instance;
        }
    }
    #endregion 

    private void Awake()
    {
        _instance = this;
        balls = new Queue<Ball>();
        exits = new List<ExitArea>();
        camMove = Camera.main.GetComponent<CameraMovement>();
        IO = new SerializationManager();
        levelUnlocked = IO.Load();
       
    }
   
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(switchKey))
        {
            ChangeBall();
        }
        
		
	}

    public void AddBall(Ball b)
    {
        if(balls.Count == 0)
        {
            focusedBall = b;
            b.SetActivation(true);

        }
        balls.Enqueue(b);
    }
    public void AddExit(ExitArea a)
    {
        exits.Add(a);
    }
    public void ChangeBall()
    {
        if(balls.Count > 1)
        {
            Ball oldBall = balls.Dequeue();
            if(oldBall != null)
            {
                oldBall.SetActivation(false);
                Ball newBall = balls.Peek();
                focusedBall = newBall;
                camMove.ChangeFocus();
                newBall.SetActivation(true);
                AddBall(oldBall);
            }
            else
            {
                Ball newBall = balls.Peek();
                focusedBall = newBall;
                camMove.ChangeFocus();
                newBall.SetActivation(true);
            }
            
        }
        
        
    }
    public void DeleteBall()
    {
        if (balls.Count > 1)
        {
            Ball oldBall = balls.Dequeue();
            oldBall.SetActivation(false);
            Ball newBall = balls.Peek();
            focusedBall = newBall;
            camMove.ChangeFocus();
            newBall.SetActivation(true);
        }
    }
    
    public void CheckForEndLevel()
    {
        foreach(ExitArea e in exits)
        {
            if (!e.isReady) return;
        }
        StartCoroutine(NextLevel());
    }
    public IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1);
        int index = SceneManager.GetActiveScene().buildIndex;
        if (levelUnlocked <index) IO.Save(index);
        SceneManager.LoadScene(index + 1,LoadSceneMode.Single);
    }
    private IEnumerator Retry()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void RetryLevel()
    {


        StartCoroutine(Retry());
        
    }
   
    
    
}

public class SerializationManager
{
    public void Save(int level)
    {
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream file = new FileStream("SaveFile.data",FileMode.OpenOrCreate))
        {
            bf.Serialize(file, level);
        }
    }
    public int Load()
    {
        int level = 1;
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists("SaveFile.data"))
        {
            using (FileStream file = new FileStream("SaveFile.data", FileMode.Open))
            {
                level = (int)bf.Deserialize(file);

            }
            return level;
        }
        else
        {
            File.Create("SaveFile.data");
            return level;
        }
        
    }
}