using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance
    {
        get => instance;
    }

    PlayerController player;
    public PlayerController Player => player;

    /* * * * * * * * * * ���Ӷ��� �� �÷��� �ð� * * * * * * * * * */
    public float playTime = 0f;
    public int gameRound = 1;
    public float FinalScore = 0;

    /* * * * * * * * * * �÷��̾��� �� ���� * * * * * * * * * */
    int score = 0;

    public int Score
    {
        get => score;
        set
        {
            if (score != value)
            {
                score = value;
            }
        }
    }

    

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            Init();
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Init()
    {
        player = FindObjectOfType<PlayerController>();
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(UnityEngine.SceneManagement.Scene arg0, LoadSceneMode arg1)
    {
        AllReset();
    }

    private void AllReset()
    {
        playTime = 0;
        gameRound = 1;
        player.level = 1;
    }


    void Update()
    {
        playTime += Time.deltaTime + Score;
        if(playTime >= gameRound * 10)
        {
            gameRound++;
        }
        FinalScore = playTime;
    }
}
