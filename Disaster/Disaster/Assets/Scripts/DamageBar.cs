using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxAmount(int amount)
    {
        slider.maxValue = amount;
        slider.value = amount;
    }

    public void SetDamage(int damage)
    {
        Debug.Log("Changing amount");
        slider.value = damage;
        
    }

}
