using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int Atk { get; private set; }
    public int Def { get; private set; }
    public int Hp { get; private set; }
    public int Crit { get; private set; }
    public int CurrentExp { get; private set; }
    public int MaxExp { get; private set; }
    public int Gold { get; private set; }

    // �߰��� Inventory �� EquippedItems
    public List<ItemData> Inventory { get; private set; }
    public List<ItemData> EquippedItems { get; private set; }


    public event System.Action OnStatsChanged;

    public Character(string name, int level, int atk, int def,int hp, int crit,int maxExp, int curExp, int gold,
         List<ItemData> initialInventory)

    {
        Name = name;
        Level = level;
        Atk = atk;
        Def = def;
        Hp = hp;
        Crit = crit;
        MaxExp = maxExp;
        CurrentExp = curExp;
        Gold = gold;
        Inventory = new List<ItemData>(initialInventory);
        EquippedItems = new List<ItemData>();
    }

    public void SetStats(string name, int level, int atk, int def, int hp, int crit, int maxExp,int curExp, int gold)
    {
        Name = name;
        Level = level;
        Atk = atk;
        Def = def;
        Hp = hp;
        Crit = crit;
        MaxExp = maxExp;
        CurrentExp = curExp;
        Gold = gold;
        OnStatsChanged?.Invoke();
    }
    // ������ �߰� �޼���
    public void AddItem(ItemData item)
    {
        Inventory.Add(item);
        OnStatsChanged?.Invoke();
    }

    // Equip �޼���: �κ��丮���� ������ �̵� �� ���� ����
    public bool Equip(ItemData item)
    {
        if (Inventory.Contains(item))
        {
            Inventory.Remove(item);
            EquippedItems.Add(item);
            Atk += item.atk;
            Def += item.def;
            Hp += item.hp;
            Crit += item.crit;
            OnStatsChanged?.Invoke();
            return true;
        }
        return false;
    }

    // UnEquip �޼���: ���� ���� �� ���� ����
    public bool UnEquip(ItemData item)
    {
        if (EquippedItems.Contains(item))
        {
            EquippedItems.Remove(item);
            Inventory.Add(item);
            Atk -= item.atk;
            Def -= item.def;
            Hp -= item.hp;
            Crit -= item.crit;
            OnStatsChanged?.Invoke();
            return true;
        }
        return false;
    }
}