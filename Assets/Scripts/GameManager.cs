using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance=null;
    public static GameManager Instance
    {
        get
        {
            if(_instance==null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    #endregion

    static int score;
    int playerLives;
    bool gameOver;
    public bool isGamePaused;

    public static int Score
    {
        get { return score; }
    }

    private void Start()
    {
        score = 0;
        gameOver = false;
        isGamePaused = false;
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !gameOver)
        {
            if(isGamePaused)
            {
                isGamePaused = false;
                UI_Manager.Instance.ResumeGame();
            }
            else
            {
                isGamePaused = true;
                UI_Manager.Instance.PauseGame();
            }

        }
    }


    public void playerDead()
    {
        gameOver = true;
        UI_Manager.Instance.showGameOverPanel();

    }


    
    public  void updateScore(int Score)
    {
        score += Score;
        UI_Manager.Instance.updateScore(score);

    }




}
