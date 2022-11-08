using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    /* * * * * * * * * * 인벤토리 * * * * * * * * * */
    //아이템을 담을 리스트
    public List<Item> items;

    //Slot의 부모가 되는 Bag를 담을 곳
    [SerializeField]
    Transform slotParent;

    //Bag의 하위에 등록된 슬롯들을 담을 곳
    [SerializeField]
    Slot[] slots;


    /* * * * * * * * * * 장비슬롯 * * * * * * * * * */
    //장비 아이템을 담을 리스트
    public List<Item> equipment;

    //EquipmentSlot의 부모가 되는 StateAndEquipment을 담을 곳
    [SerializeField]
    Transform equipmentslotParent;

    //StateAndEquipment의 하위에 등록된 슬롯들을 담을 곳
    [SerializeField]
    EquipmentSlot eqiupSlot;


    //OnValidate()는 유니티 에디터에서 바로 작동을 하는 역할
    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
        eqiupSlot = equipmentslotParent.GetComponentInChildren<EquipmentSlot>();
        
    }
    
    private void Awake()
    {
        
        FreshSlot();
    }

    

    //아이템이 들어오거나 나가면 Slot의 내용을 다시 정리해서 화면에 보여주는 역할
    public void FreshSlot()
    {
        //같은 i 값을 사용하기 위해 위부에 선언
        int i = 0;

        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].Item = items[i];
        }

        for(; i < slots.Length;i++)
        {
            slots[i].Item = null;
        }


        //다른 j 값을 사용해서 장비 슬롯 1개의 내용을 다시 정리해서 화면에 보여주는 역할
        //불완전한 것 같음, 그래서 EquipSlotItem 매서드에 eqiupSlot.Item = null;을 넣음
        int j = 0;

        for (; j < equipment.Count; j++)
        {
            eqiupSlot.Item = equipment[j];
        }
    }
    
    //아이템을 어떤 방식으로 획득해서 인벤토리에 추가하는 역할
    public void AddItem(Item item)
    {
        if(items.Count < slots.Length)
        {
            items.Add(item);
            FreshSlot();
        }
        else
        {
            Debug.Log("슬롯이 가득 차 있습니다.");
        }
    }

    //장비아이템슬롯
    public void EquipSlotItem(Item item)
    {
        equipment.Remove(item);
        eqiupSlot.Item = null;
        items.Add(item);
        FreshSlot();
        Debug.Log($"{item.itemName} 해제");
    }

    //소비아이템
    public void UseItem(Item item)
    {
        if(item.equipment)
        {
            if(eqiupSlot.Item == null)
            {
                equipment.Add(item);
                items.Remove(item);
                FreshSlot();
                Debug.Log($"{item.itemName} 장착");
            }
            else
            {
                Debug.Log("이미 장비 슬롯에 장비가 있습니다.");
            }
        }
        else if(item.expendables)
        {

            Debug.Log($"{item.itemName} 사용");
        }
        else
        {

            Debug.Log($"{item.itemName}");
        }
    }


    /* * * * * * * * * * 메뉴UI * * * * * * * * * */



    private void Start()
    {
        equipmentslotParent.gameObject.SetActive(false);
    }


    private void Update()
    {
        
    }

}
