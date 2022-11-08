using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public bool equipment;
    public bool expendables;
    public string itemName;
    public Sprite itemImage;
    public GameObject itemPrefab;
    public int attackPower;
    public int fixtank;
}
