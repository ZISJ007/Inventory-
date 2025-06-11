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
        // ĳ���� �ν��Ͻ� ���� �� �ʱ� ����ġ ����
        PlayerCharacter = new Character(charname, level, atk, def, hp, crit, maxexp, curExp, gold, Inventory);

        // stats ���� �� UI �ڵ� ����
        PlayerCharacter.OnStatsChanged += () =>
        {
            UIManager.Instance.UIStatus.Refresh();
        };

        // ���� UI ����
        UIManager.Instance.UIStatus.SetCharacter(PlayerCharacter);
        foreach (var item in Inventory)
        {
            InventoryMananager.Instance.AddItem(item);
        }
    }

    private void OnValidate()
    {
        // �����Ϳ��� �� ���� �� �÷��� ���̸� UI ����
        if (Application.isPlaying && Instance != null && PlayerCharacter != null)
        {
            PlayerCharacter.SetStats(charname, level, atk, def, hp, crit, maxexp, curExp, gold);
        }
    }

}
