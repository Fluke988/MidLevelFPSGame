using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    float time = 0f;
    public TMP_Text timeText;

    void Start()
    {
        //timeText = GetComponent<Text>();
    }

    void Update()
    {
        time = (time + Time.deltaTime);
        print("Time: " + time);
        timeText.text = "Time: " + time.ToString("F2");

        if (time > 60f)
        {
            Initiate.Fade("GameOverScene", Color.white, 1.0f);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
