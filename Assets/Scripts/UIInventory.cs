using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [Header("Status Menu Buttons")]
    [SerializeField] private Button BackButton;

    private void Start()
    {
        // ��ư Ŭ�� �̺�Ʈ ���
        BackButton.onClick.AddListener(OnMainButtonClicked);
    }
    private void OnMainButtonClicked()
    {
        UIManager.Instance.OpenMainMenu();
    }

}
