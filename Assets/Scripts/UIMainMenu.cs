using UnityEngine;
using UnityEngine.UI;
public class UIMainMenu : MonoBehaviour
{
    [Header("Main Menu Buttons")]
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;

    private void Start()
    {
        // 버튼 클릭 이벤트 등록
        statusButton.onClick.AddListener(OnStatusButtonClicked);
        inventoryButton.onClick.AddListener(OnInventoryButtonClicked);
    }

    private void OnStatusButtonClicked()
    {
        UIManager.Instance.OpenStatus();
    }

    private void OnInventoryButtonClicked()
    {
        UIManager.Instance.OpenInventory();
    }
}

