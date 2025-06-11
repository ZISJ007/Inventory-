using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIStatus : MonoBehaviour
{
    [Header("Status UI Elements")]

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI atkText;
    [SerializeField] TextMeshProUGUI defText;
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] TextMeshProUGUI critText;
    [SerializeField] TextMeshProUGUI expText;
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] private Image expBar;

    [Header("Status Menu Buttons")]
    [SerializeField] private Button BackButton;

    private Character character;
    private void Start()
    {
        // 버튼 클릭 이벤트 등록
        BackButton.onClick.AddListener(OnMainButtonClicked);
    }

    private void OnMainButtonClicked()
    {
        UIManager.Instance.OpenMainMenu();
    }
    public void SetCharacter(Character c)
    {
        character = c;
        Refresh();
    }

    public void Refresh()
    {
        if (character == null) return;

        nameText.text = $"{character.Name}";
        levelText.text = $"LV. {character.Level}";
        atkText.text = $"ATK: {character.Atk}";
        defText.text = $"DEF: {character.Def}";
        hpText.text = $"HP: {character.Hp}";
        critText.text = $"Crit: {character.Crit}";
        goldText.text = $"{character.Gold:N0}";

        if (expBar != null && character.MaxExp > 0)
        {
            expBar.fillAmount = (float)character.CurrentExp / character.MaxExp;
            expText.text = $"{character.CurrentExp} / {character.MaxExp}";
        }
    }
}

