using UnityEngine;
using UnityEngine.UI;
public class UIInventory : MonoBehaviour
{
    [Header("Inventory UI Elements")]
    [SerializeField] private GameObject inventorySlotPrefab; // 슬롯 프리팹
    [SerializeField] private Transform slotsParent;           // 슬롯 배치 부모 트랜스폼

    [Header("Status Menu Buttons")]
    [SerializeField] private Button BackButton;

    private void Start()
    {
        // 버튼 클릭 이벤트 등록
        BackButton.onClick.AddListener(OnMainButtonClicked);
    }


    private void OnMainButtonClicked()
    {
        UIManager.Instance.OpenMainMenu();
    }
}
