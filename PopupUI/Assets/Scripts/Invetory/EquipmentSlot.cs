using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour, IPointerDownHandler
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

    //�������� ������ ������ Ŭ������ ��
    //�켱 �� �������� Ȯ���ϰ� �ƴϸ� �����ϱ� ����
    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject go = eventData.pointerCurrentRaycast.gameObject;
        if (go.name == "EquipmentSlotItem")
        {
            EquipmentSlot slot = eventData.pointerCurrentRaycast.gameObject.GetComponent<EquipmentSlot>();
            Item Eslot = slot.Item;
            if (Eslot == null)
            {
                Debug.Log("�� ��� ���� �Դϴ�.");
            }
            else
            {
                inventory.EquipSlotItem(Eslot);
            }
        }
    }
}
