using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Continue : MonoBehaviour, IPointerDownHandler
{

    GameObject gobackgame;

    void Start()
    {
        gobackgame = transform.parent.gameObject;
    }

    
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(gobackgame.activeSelf)
        {
            gobackgame.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
