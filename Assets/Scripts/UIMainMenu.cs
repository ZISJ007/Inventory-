using UnityEngine;
using UnityEngine.UI;
public class UIMainMenu : MonoBehaviour
{
    [Header("Main Menu Buttons")]
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;

    private void Start()
    {
        // ��ư Ŭ�� �̺�Ʈ ���
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

