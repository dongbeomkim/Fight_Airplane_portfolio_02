using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    Text score;
    int scoreindex;


    void Start()
    {
        score = GetComponent<Text>();
        scoreindex = (int)GameManager.Instance.playTime;
    }

    
    void Update()
    {
        score.text = scoreindex.ToString();
    }
}
