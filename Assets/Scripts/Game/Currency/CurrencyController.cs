using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CurrencyController : MonoBehaviour
{
    [SerializeField] private CurrencyView _currencyView;

    private static Dictionary<long, string> NumberShortcuts = new Dictionary<long, string>()
    {
        [1000] = "K",
        [1000000] = "M",
        [1000000000] = "B",
        [1000000000000] = "T",
        [1000000000000000] = "q",
        [1000000000000000000] = "Q",
    };
    public static string ConvertCurrencyToString(long currency) 
    {
        float currencyFloat = currency;
        for(int i = NumberShortcuts.Count - 1; i >= 0; i--)
        {
            var currentLiteral = NumberShortcuts.ElementAt(i);
            if (currency >= currentLiteral.Key)
            {

                currencyFloat = (float)System.Math.Round(currencyFloat/ currentLiteral.Key, 2);



                return $"{currencyFloat}{currentLiteral.Value}";
            }
        }
        return currency.ToString();
    }
    public void SetMoneyValue(long value)
    {
        _currencyView.SetViewValue(ConvertCurrencyToString(value));
    }
}
