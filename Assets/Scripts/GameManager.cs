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
    static int playerLives;
    static bool gameOver;

    public static int Score
    {
        get { return score; }
    }

    private void Start()
    {
        score = 0;
        gameOver = false;
    }


    public static void playerDead()
    {

    }


    public static void updateScore(int Score)
    {
        score += Score;

    }




}
