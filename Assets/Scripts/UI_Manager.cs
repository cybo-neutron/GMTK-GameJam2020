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





}
