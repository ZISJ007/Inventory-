using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public string itemName; 
    public string itemDescription;
    public int atk;
    public int def;
    public int hp;
    public int crit;
    public Sprite Icon; 
}
