using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SAEOnOffUI : MonoBehaviour, IPointerDownHandler
{

    /* * * * * * * * * * ¸Þ´ºUI * * * * * * * * * */
    
    Inventory inventory;
    GameObject sae;

    private void Awake()
    {
        inventory = GetComponentInParent<Inventory>();
        sae = inventory.transform.GetChild(1).gameObject;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if(sae.gameObject.activeSelf)
        {
            sae.SetActive(false);
        }
        else
        {
            sae.SetActive(true);
        }
    }
}
