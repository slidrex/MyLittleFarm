using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _currencyCounter;
    public void SetViewValue(string value)
    {
        foreach (var item in _currencyCounter)
        {
            item.text = value;
        }
    }
}
