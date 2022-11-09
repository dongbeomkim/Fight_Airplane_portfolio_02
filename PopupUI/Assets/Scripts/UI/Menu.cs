using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour, IPointerDownHandler
{
    GameObject smallMenu;


    void Start()
    {
        smallMenu = GameObject.Find("SmallMenu");
        smallMenu.SetActive(false);
    }

    
    void Update()
    {
        
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if(!smallMenu.activeSelf)
        {
            smallMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
