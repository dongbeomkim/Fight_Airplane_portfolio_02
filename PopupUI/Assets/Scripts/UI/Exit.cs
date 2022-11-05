using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Exit : MonoBehaviour, IPointerDownHandler
{
    

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Application.Quit();
    }
}
