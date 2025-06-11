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


    //동일한 아이템인경우 
    public void AddCount(int amount)
    {
        itemCount += amount;
        UpdateUI();
    }


    //동일한 아이템인지 아닌지 
    public bool HasItem(ItemData checkItem)
    {
        return itemData == checkItem;
    }

    // 1) 데이터 유효성 검사
    public void OnclickItem()
    {
        // 아이템 정보가 없거나 개수가 0 이하이면 종료
        if (itemData == null || itemCount <= 0)
            return;

        // 현재 캐릭터 정보 가져오기
        var character = GameManager.Instance.PlayerCharacter;

        // 이미 장착된 아이템이면 해제 로직 수행
        //Contains는 C#의 List<T> (또는 ICollection<T>)에 정의된 메서드로, 
        //리스트 안에 특정 요소가 “들어 있는지” (즉 이미 추가되어 있는지) 여부를 bool 값으로 반환해 준다.
        if (character.EquippedItems.Contains(itemData)) // 리스트에 존재하는지 확인
        {
            bool unequipped = character.UnEquip(itemData); // 장착 해제 시도
            if (unequipped)
            {
                nowEquip.SetActive(false);
            }
            return; // 해제 후 메서드 종료
        }

        var toUnequip = character.EquippedItems.ToList(); // 현재 장착 리스트 복사
        foreach (var eq in toUnequip)
            character.UnEquip(eq); // 하나씩 해제

        // UI상의 슬롯들 모두 장착 표시 비활성화
        ItemSlot[] allSlots = transform.parent.GetComponentsInChildren<ItemSlot>(true);
        foreach (var slot in allSlots)
            slot.nowEquip.SetActive(false);

        // 선택된 아이템 장착 시도
        bool equipped = character.Equip(itemData);
        if (equipped)
        {
            // 장착 성공 시 UI 표시, 개수 감소, UI 갱신
            nowEquip.SetActive(true);
        }
    }
}