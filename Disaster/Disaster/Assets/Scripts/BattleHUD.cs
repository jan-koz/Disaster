using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Text levelText;
    public Slider hpSlider;

    public void SetupHud(Unit unit)
    {
        nameText.text ="Name: " + unit.unitName;
        levelText.text = "LvL: " + unit.unitLvl;
        hpSlider.maxValue = unit.maxHp;
        hpSlider.value = unit.currentHp;
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }

    public void Heal(int hp)
    {
        hpSlider.value += hp;
    }
}
