using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    /* * * * * * * * * * �κ��丮 * * * * * * * * * */
    //�������� ���� ����Ʈ
    public List<Item> items;

    //Slot�� �θ� �Ǵ� Bag�� ���� ��
    [SerializeField]
    Transform slotParent;

    //Bag�� ������ ��ϵ� ���Ե��� ���� ��
    [SerializeField]
    Slot[] slots;


    /* * * * * * * * * * ��񽽷� * * * * * * * * * */
    //��� �������� ���� ����Ʈ
    public List<Item> equipment;

    //EquipmentSlot�� �θ� �Ǵ� StateAndEquipment�� ���� ��
    [SerializeField]
    Transform equipmentslotParent;

    //StateAndEquipment�� ������ ��ϵ� ���Ե��� ���� ��
    [SerializeField]
    EquipmentSlot eqiupSlot;


    //OnValidate()�� ����Ƽ �����Ϳ��� �ٷ� �۵��� �ϴ� ����
    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
        eqiupSlot = equipmentslotParent.GetComponentInChildren<EquipmentSlot>();
        
    }
    
    private void Awake()
    {
        
        FreshSlot();
    }

    

    //�������� �����ų� ������ Slot�� ������ �ٽ� �����ؼ� ȭ�鿡 �����ִ� ����
    public void FreshSlot()
    {
        //���� i ���� ����ϱ� ���� ���ο� ����
        int i = 0;

        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].Item = items[i];
        }

        for(; i < slots.Length;i++)
        {
            slots[i].Item = null;
        }


        //�ٸ� j ���� ����ؼ� ��� ���� 1���� ������ �ٽ� �����ؼ� ȭ�鿡 �����ִ� ����
        //�ҿ����� �� ����, �׷��� EquipSlotItem �ż��忡 eqiupSlot.Item = null;�� ����
        int j = 0;

        for (; j < equipment.Count; j++)
        {
            eqiupSlot.Item = equipment[j];
        }
    }
    
    //�������� � ������� ȹ���ؼ� �κ��丮�� �߰��ϴ� ����
    public void AddItem(Item item)
    {
        if(items.Count < slots.Length)
        {
            items.Add(item);
            FreshSlot();
        }
        else
        {
            Debug.Log("������ ���� �� �ֽ��ϴ�.");
        }
    }

    //�������۽���
    public void EquipSlotItem(Item item)
    {
        equipment.Remove(item);
        eqiupSlot.Item = null;
        items.Add(item);
        FreshSlot();
        Debug.Log($"{item.itemName} ����");
    }

    //�Һ������
    public void UseItem(Item item)
    {
        if(item.equipment)
        {
            if(eqiupSlot.Item == null)
            {
                equipment.Add(item);
                items.Remove(item);
                FreshSlot();
                Debug.Log($"{item.itemName} ����");
            }
            else
            {
                Debug.Log("�̹� ��� ���Կ� ��� �ֽ��ϴ�.");
            }
        }
        else if(item.expendables)
        {

            Debug.Log($"{item.itemName} ���");
        }
        else
        {

            Debug.Log($"{item.itemName}");
        }
    }


    /* * * * * * * * * * �޴�UI * * * * * * * * * */



    private void Start()
    {
        equipmentslotParent.gameObject.SetActive(false);
    }


    private void Update()
    {
        
    }

}
