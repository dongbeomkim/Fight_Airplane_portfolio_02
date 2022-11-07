using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
   
    PlayerController player;

    Slider hp;
    Slider fuel;
    Text level;
    Text playTime;
    Text gameRound;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        hp = transform.GetChild(0).GetComponent<Slider>();
        fuel = transform.GetChild(1).GetComponent<Slider>();
        level = transform.GetChild(2).GetChild(0).GetComponent<Text>();
        playTime = transform.GetChild(3).GetChild(0).GetComponent<Text>();
        gameRound = transform.GetChild(4).GetChild(0).GetComponent<Text>();
    }

    
    void Update()
    {
        hp.value = player.Hp/player.MaxHp;
        fuel.value = player.Fuel/player.MaxFuel;
        level.text = player.level.ToString();
        playTime.text = GameManager.Instance.playTime.ToString("F0");
        gameRound.text = GameManager.Instance.gameRound.ToString();
    }

}
