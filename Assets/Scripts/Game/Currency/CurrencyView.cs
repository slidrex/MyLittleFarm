using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _currencyCounter;
    [SerializeField] private TextMeshProUGUI[] _gpsCounter;
    public void SetViewValue(string value)
    {
        foreach (var item in _currencyCounter)
        {
            item.text = value;
        }
    }
    public void SetGPS(string gps)
    {
        foreach (var item in _gpsCounter)
        {
            item.text = gps;
        }
    }
}
