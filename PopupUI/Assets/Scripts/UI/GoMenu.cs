using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GoMenu : MonoBehaviour, IPointerDownHandler
{

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene("Menu");
    }
}
