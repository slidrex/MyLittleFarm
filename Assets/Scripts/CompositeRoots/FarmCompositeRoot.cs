using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmCompositeRoot : MonoBehaviour
{
    public ClientManager ClientManager { get; private set; }
    public CurrencyController CurrencyController;
    public MapController MapController;
    public BuildingController BuildingController;
    public static FarmCompositeRoot Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        ClientManager = FindObjectOfType<ClientManager>();
    }
}
