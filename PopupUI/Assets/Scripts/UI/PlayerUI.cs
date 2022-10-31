using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
   
    PlayerController player;

    Slider hp;
    Slider fuel;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        hp = transform.GetChild(0).GetComponent<Slider>();
        fuel = transform.GetChild(1).GetComponent<Slider>();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        hp.value = player.Hp;
        fuel.value = player.Fuel;
    }
}
