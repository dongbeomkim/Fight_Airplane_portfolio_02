using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectItem : MonoBehaviour
{

    [Header("������")]
    public Item item;

    [Header("�������̹���")]
    public Sprite itemImage;

    void Start()
    {
        itemImage = item.itemImage;
    }
}
