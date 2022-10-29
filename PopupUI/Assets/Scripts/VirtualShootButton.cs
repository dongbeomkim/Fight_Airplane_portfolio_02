using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

public class VirtualShootButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    Image lever;

    PlayerController playerController;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("´©¸§");
        playerController.Attack();
        lever.color = new Color(0.3f, 0.3f, 0.5f, 1);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("¶«");
        lever.color = new Color(0.3f, 0.3f, 0.5f, 0.5f);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
