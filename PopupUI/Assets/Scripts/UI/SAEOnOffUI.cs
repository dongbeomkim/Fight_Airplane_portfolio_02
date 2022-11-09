using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SAEOnOffUI : MonoBehaviour, IPointerDownHandler
{

    /* * * * * * * * * * Ω∫≈»/¿Â∫Ò UI * * * * * * * * * */
    
    GameObject sae;

    private void Awake()
    {
        sae = GameObject.Find("StateAndEquipment");
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
            Time.timeScale = 1;
        }
        else
        {
            sae.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
