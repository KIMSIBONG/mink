using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpHandler : MonoBehaviour
{
    public Slider slider;
    public float maxHp = 200f;
    private float currentHp;

    private void Start()
    {
        currentHp = maxHp;
        slider.value = currentHp / maxHp;
    }
    
    public void SetHp(float damage)
    {
        currentHp -= damage;
        slider.value = currentHp / maxHp;
    }
}
