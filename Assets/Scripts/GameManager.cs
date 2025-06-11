using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Character PlayerCharacter { get; private set; }

    [Header("Character Stats (Inspector)")]
    [SerializeField] private string charname;
    [SerializeField] private int level;
    [SerializeField] private int atk;
    [SerializeField] private int def;
    [SerializeField] private int hp;
    [SerializeField] private int crit;
    [SerializeField] private int curExp;
    [SerializeField] private int maxexp;
    [SerializeField] private int gold;
    [SerializeField] private List<ItemData> Inventory;
    private void Awake()
    {
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

    private void Start()
    {
        // 캐릭터 인스턴스 생성 및 초기 경험치 세팅
        PlayerCharacter = new Character(charname, level, atk, def, hp, crit, maxexp, curExp, gold, Inventory);

        // stats 변경 시 UI 자동 갱신
        PlayerCharacter.OnStatsChanged += () =>
        {
            UIManager.Instance.UIStatus.Refresh();
        };

        // 최초 UI 세팅
        UIManager.Instance.UIStatus.SetCharacter(PlayerCharacter);
        foreach (var item in Inventory)
        {
            InventoryMananager.Instance.AddItem(item);
        }
    }

    private void OnValidate()
    {
        // 에디터에서 값 수정 시 플레이 중이면 UI 갱신
        if (Application.isPlaying && Instance != null && PlayerCharacter != null)
        {
            PlayerCharacter.SetStats(charname, level, atk, def, hp, crit, maxexp, curExp, gold);
        }
    }

}
