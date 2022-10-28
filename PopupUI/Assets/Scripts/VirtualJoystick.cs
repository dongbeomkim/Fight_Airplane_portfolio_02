using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField]
    RectTransform lever;
    RectTransform rectTransform;

    [SerializeField, Range(10, 150)]
    float leverRange;

    Vector2 inputDirection;
    bool isInput;

    PlayerController playerController;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        playerController = FindObjectOfType<PlayerController>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ControllJoystickLever(eventData);
        isInput = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        ControllJoystickLever(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
        isInput = false;
        playerController.Move(Vector2.zero);
    }

    void ControllJoystickLever(PointerEventData eventData)
    {
        var inputPos = eventData.position - rectTransform.anchoredPosition;
        var inputVector = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;
        lever.anchoredPosition = inputVector;
        inputDirection = inputVector / leverRange;
    }

    void InputControllVector()
    {
        playerController.Move(inputDirection);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        if(isInput)
        {
            InputControllVector();
        }
    }
}
