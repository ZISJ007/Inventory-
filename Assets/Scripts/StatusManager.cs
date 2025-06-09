using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusManager : MonoBehaviour
{
    [Header("Status UI Elements")]

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI atkText;
    [SerializeField] TextMeshProUGUI defText;
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] TextMeshProUGUI critText;
    public void SetCharacter(Character character)
    {
        nameText.text = $"{character.Name}";
        levelText.text = $"LV. {character.Level}";
        atkText.text = $"ATK: {character.Atk}";
        defText.text = $"DEF: {character.Def}";
        hpText.text = $"HP: {character.Hp}";
        critText.text = $"Crit: {character.Crit}";

        //hpSlider.maxValue = character.MaxHP;
        //hpSlider.value = character.CurrentHP;
    }
}
