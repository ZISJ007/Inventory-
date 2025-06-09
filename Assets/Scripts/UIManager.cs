using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("UI References")]
    [SerializeField] private UIMainMenu mainMenu;      // 메인 메뉴 UI
    [SerializeField] private UIStatus statusUI;        // 상태창 UI
    [SerializeField] private UIInventory inventoryUI;  // 인벤토리 UI

    // 외부에서 접근할 수 있는 프로퍼티
    public UIMainMenu UIMainMenu => mainMenu;
    public UIStatus UIStatus => statusUI;
    public UIInventory UIInventory => inventoryUI;

    private void Awake()
    {
        // 싱글톤 초기화
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void OpenMainMenu()
    {
        mainMenu.gameObject.SetActive(true);
        statusUI.gameObject.SetActive(false);
        inventoryUI.gameObject.SetActive(false);
    }

    public void OpenStatus()
    {
        mainMenu.gameObject.SetActive(false);
        statusUI.gameObject.SetActive(true);
        inventoryUI.gameObject.SetActive(false);
    }

    public void OpenInventory()
    {
        mainMenu.gameObject.SetActive(false);
        statusUI.gameObject.SetActive(false);
        inventoryUI.gameObject.SetActive(true);
    }
}
