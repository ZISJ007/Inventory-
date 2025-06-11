using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
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
