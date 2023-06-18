using Riptide;
using System.Collections.Generic;
using System.Linq;
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
    public long FromStringToCurrency(string str)
    {
        char literal = str[str.Length - 1];
        long multiplier = 1;
        for(int i = NumberShortcuts.Count - 1; i >= 0; i--)
        {
            var el = NumberShortcuts.ElementAt(i);
            if (el.Equals(literal))
            {
                multiplier = el.Key;
                break;
            }
        }
        if(multiplier != 1) str = str.Substring(0, str.Length - 1);
        return long.Parse(str) * multiplier;
    }
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
        ClientManager.TargetResponse.Gold = value;
        _currencyView.SetViewValue(ConvertCurrencyToString(value));
    }
    public void SetGPSValue(long value)
    {
        _currencyView.SetGPS(ConvertCurrencyToString(value));
    }
    [MessageHandler((ushort)ServerToClient.UPDATE_GOLD)]
    private static void UpdateGoldMessage(Message message)
    {

        FarmCompositeRoot.Instance.CurrencyController.SetMoneyValue(message.GetLong());
    }
    [MessageHandler((ushort)ServerToClient.UPDATE_GPS)]
    private static void UpdateGPSMessage(Message message)
    {

        FarmCompositeRoot.Instance.CurrencyController.SetGPSValue(message.GetLong());
    }

}
