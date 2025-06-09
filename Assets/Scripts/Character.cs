using UnityEngine;
public class Character
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int Atk { get; private set; }
    public int Def { get; private set; }
    public int Hp { get; private set; }
    public int Crit { get; private set; }
    public int CurrentExp { get; private set; }
    public int Exp { get; private set; }
    public int Gold { get; private set; }
    /// stats ���� �� �߻��ϴ� �̺�Ʈ
    /// </summary>
    public event System.Action OnStatsChanged;
    public Character(string name, int level, int atk, int def, int hp, int crit, int exp, int gold)
    {
        Name = name;
        Level = level;
        Atk = atk;
        Def = def;
        Hp = hp;
        Crit = crit;
        CurrentExp = 0;
        Exp = exp;
        Gold = gold; // �ʱ� ��� ����
    }
    public void SetStats(string name, int level, int atk, int def, int hp, int crit, int exp, int gold)
    {
        Name = name;
        Level = level;
        Atk = atk;
        Def = def;
        Hp = hp;
        Crit = crit;
        CurrentExp = 0;
        Exp = exp;
        Gold = gold; // �ʱ� ��� ����
        OnStatsChanged?.Invoke();
    }
    public void GainExp(int amount)
    {
        CurrentExp = Mathf.Min(CurrentExp + amount, Exp);
    }
}