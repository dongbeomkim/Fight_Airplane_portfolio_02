using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] Image image;

    Item item;
    public Item Item
    {
        get => item;
        set
        {
            item = value;
            if(item != null)
            {
                image.sprite = Item.itemImage;
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }

    Inventory inventory;


    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    //�κ��丮 ������ ������ Ŭ������ ��
    //�켱 �� �������� Ȯ���ϰ� �ƴϸ� ��� Ȥ�� ���� ����
    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject go = eventData.pointerCurrentRaycast.gameObject;
        if (go.name == "SlotItem")
        {
            Slot slot = eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>();
            Item Uslot = slot.Item;
            if (Uslot == null)
            {
                Debug.Log("�� �κ��丮 ���� �Դϴ�.");
            }
            else
            {
                inventory.UseItem(Uslot);
            }
        }
    }
}
