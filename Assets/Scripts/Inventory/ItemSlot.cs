using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
public class ItemSlot : MonoBehaviour
{
    public Image Icon;
    public TextMeshProUGUI CountText;
    public TextMeshProUGUI ItemName;
    public GameObject nowEquip;
    private ItemData itemData;
    private int itemCount = 1;


    private void UpdateUI()
    {
        if (itemData != null)
        {
            Icon.sprite = itemData.Icon;
            ItemName.text = itemData.itemName;

            if (itemCount > 1)
            {
                CountText.text = itemCount.ToString();
            }
            else
            {
                CountText.text = "";
            }
        }
        else
        {
            Icon.sprite = null;
            CountText.text = "";
        }
    }

    public void SetUp(ItemData setItemData)
    {
        itemData = setItemData;
        UpdateUI();
    }


    //������ �������ΰ�� 
    public void AddCount(int amount)
    {
        itemCount += amount;
        UpdateUI();
    }


    //������ ���������� �ƴ��� 
    public bool HasItem(ItemData checkItem)
    {
        return itemData == checkItem;
    }

    // 1) ������ ��ȿ�� �˻�
    public void OnclickItem()
    {
        // ������ ������ ���ų� ������ 0 �����̸� ����
        if (itemData == null || itemCount <= 0)
            return;

        // ���� ĳ���� ���� ��������
        var character = GameManager.Instance.PlayerCharacter;

        // �̹� ������ �������̸� ���� ���� ����
        //Contains�� C#�� List<T> (�Ǵ� ICollection<T>)�� ���ǵ� �޼����, 
        //����Ʈ �ȿ� Ư�� ��Ұ� ����� �ִ����� (�� �̹� �߰��Ǿ� �ִ���) ���θ� bool ������ ��ȯ�� �ش�.
        if (character.EquippedItems.Contains(itemData)) // ����Ʈ�� �����ϴ��� Ȯ��
        {
            bool unequipped = character.UnEquip(itemData); // ���� ���� �õ�
            if (unequipped)
            {
                nowEquip.SetActive(false);
            }
            return; // ���� �� �޼��� ����
        }

        var toUnequip = character.EquippedItems.ToList(); // ���� ���� ����Ʈ ����
        foreach (var eq in toUnequip)
            character.UnEquip(eq); // �ϳ��� ����

        // UI���� ���Ե� ��� ���� ǥ�� ��Ȱ��ȭ
        ItemSlot[] allSlots = transform.parent.GetComponentsInChildren<ItemSlot>(true);
        foreach (var slot in allSlots)
            slot.nowEquip.SetActive(false);

        // ���õ� ������ ���� �õ�
        bool equipped = character.Equip(itemData);
        if (equipped)
        {
            // ���� ���� �� UI ǥ��, ���� ����, UI ����
            nowEquip.SetActive(true);
        }
    }
}