using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryMananager : MonoBehaviour
{
    public static InventoryMananager Instance;

    public Transform ItemSlotParent;
    public GameObject ItemSlotPrefab;

    private List<ItemSlot> slots = new List<ItemSlot>();



    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    //아이템을 추가하는 함수
    public void AddItem(ItemData newItem)
    {
        //동일한 아이템이 있는지 없는지 확인
        ItemSlot exitsSlot = null;

        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i] != null && slots[i].HasItem(newItem) == true)
            {
                //동일한 아이템 
                exitsSlot = slots[i];
                break;
            }
        }

        if (exitsSlot != null)

        {
            exitsSlot.AddCount(1);
        }
        else
        {
            //Instantiate(생성할 오브젝트.생성될위치)
            GameObject newSlot = Instantiate(ItemSlotPrefab, ItemSlotParent);
            ItemSlot itemslot = newSlot.GetComponent<ItemSlot>();
            itemslot.SetUp(newItem);
            slots.Add(itemslot);
        }
    }
}