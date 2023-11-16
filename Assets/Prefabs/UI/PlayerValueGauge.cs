using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerValueGauge : MonoBehaviour
{
    [SerializeField] Image fill;
    [SerializeField] TextMeshProUGUI lifeText;

    public void SetValue(float current, float max)
    {
        fill.fillAmount = current / max;
        lifeText.text = ((int)current).ToString() + " / " + ((int)max).ToString();
    }

}
