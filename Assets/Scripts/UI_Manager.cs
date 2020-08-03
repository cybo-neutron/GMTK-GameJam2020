using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class UI_Manager : MonoBehaviour
{

    #region Singleton
    private static UI_Manager _instance;
    public static UI_Manager Instance
    {
        get
        {
            if(_instance==null)
            {
                GameObject go = new GameObject("UI_Manager");
                go.AddComponent<UI_Manager>();

            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    #endregion

    TMP_Text scoreText;
    Transform gameOverPanel;

    private void Start()
    {
        scoreText = GameObject.Find("Canvas").transform.Find("ScorePanel").transform.Find("ScoreText").GetComponent<TMP_Text>();
        gameOverPanel = GameObject.Find("Canvas").transform.Find("GameOver");
        gameOverPanel.gameObject.SetActive(false);
    }

   

    public  void updateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void showGameOverPanel()
    {
        gameOverPanel.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        Debug.Log("Game Paused");
    }

    public void ResumeGame()
    {
        Debug.Log("Game Resumed");

    }

    public void Restart()
    {

    }


}
