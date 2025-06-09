using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Character PlayerCharacter { get; private set; }
    [SerializeField] private string name;
    [SerializeField] private int level;
    [SerializeField] private int atk;
    [SerializeField] private int def;
    [SerializeField] private int hp;
    [SerializeField] private int crit;
    [SerializeField] private int exp;
    [SerializeField] private int curexp;
    [SerializeField] private int gold;

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

    private void Start()
    {
        // �÷��̾� ĳ���� �ʱ�ȭ ����
        PlayerCharacter = new Character(name, level, atk, def, hp, crit, exp, gold);
        PlayerCharacter.GainExp(curexp);

        // UI�� ������ �̸� ����
        if (UIManager.Instance != null)
        {
            UIManager.Instance.UIStatus.SetCharacter(PlayerCharacter);
        }
        else
        {
            Debug.LogWarning("UIManager �ν��Ͻ��� ã�� �� �����ϴ�.");
        }
    }
}
