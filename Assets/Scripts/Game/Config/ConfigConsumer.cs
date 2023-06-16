using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConfigConsumer : MonoBehaviour
{
    private void Awake()
    {
        LoginResponse resp = ClientManager.TargetResponse;

        FarmCompositeRoot.Instance.CurrencyController.SetMoneyValue(resp.Gold);
        FarmCompositeRoot.Instance.BuildingController.InstantiateBuildings(resp.Plot.Buildings);
        FarmCompositeRoot.Instance.MapController.InitMap(new Vector2Int(resp.Plot.SizeX, resp.Plot.SizeY));
    }
}
