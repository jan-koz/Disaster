using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxAmount(float amount)
    {
        slider.maxValue = amount;
        slider.value = amount;
    }

    public void SetDamage(float damage)
    {
        Debug.Log("Changing amount");
        slider.value = damage;
        
    }

}
