using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("UI References")]
    [SerializeField] private UIMainMenu mainMenu;      // ���� �޴� UI
    [SerializeField] private UIStatus statusUI;        // ����â UI
    [SerializeField] private UIInventory inventoryUI;  // �κ��丮 UI

    // �ܺο��� ������ �� �ִ� ������Ƽ
    public UIMainMenu UIMainMenu => mainMenu;
    public UIStatus UIStatus => statusUI;
    public UIInventory UIInventory => inventoryUI;

    private void Awake()
    {
        // �̱��� �ʱ�ȭ
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
