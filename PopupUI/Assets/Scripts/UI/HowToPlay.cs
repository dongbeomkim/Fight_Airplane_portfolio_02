using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HowToPlay : MonoBehaviour, IPointerDownHandler
{

    GameObject image;

    void Start()
    {
        image = transform.GetChild(1).gameObject;
    }

    
    void Update()
    {
        
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if(image.activeSelf)
        {
            image.gameObject.SetActive(false);
        }
        else
        {
            image.gameObject.SetActive(true);
        }
    }
}
