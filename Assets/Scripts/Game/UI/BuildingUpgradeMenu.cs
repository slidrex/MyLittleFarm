using Assets.Scripts.Game.Building.Models;
using Newtonsoft.Json;
using Riptide;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUpgradeMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _buildingTitle;
    [SerializeField] private TextMeshProUGUI _goldPerSecond;
    [SerializeField] private Button _subminButton;
    [SerializeField] private TextMeshProUGUI _upgradePrice;
    [SerializeField] private Image _buildingImage;
    [SerializeField] private Button _exitButton;
    private long _id;
    private void Awake()
    {
        _exitButton.onClick.AddListener(() => OnExitButtonPressed());
        _subminButton.onClick.AddListener(() => UpgradeBuildingRequest());
    }
    public void Configrure(long id, string buildingName, string upgradePrice, string rawGps, string additionalGps, bool canBeBought ,Sprite buildingImage)
    {
        _id = id;
        _buildingTitle.text = buildingName;
        _goldPerSecond.text = $"{rawGps} (+{additionalGps})";
        _upgradePrice.text = upgradePrice;
        _buildingImage.sprite = buildingImage;

        _subminButton.interactable = canBeBought;
    }
    private void OnExitButtonPressed()
    {
        UIController.Instance.CloseScreenIfActive(UIController.UIScreen.BuildingUpgradeMenu);
    }
    private void UpgradeBuildingRequest()
    {
        var upgradeRequest = Message.Create(MessageSendMode.Reliable, ClientToServer.UPGRADE_BUILDING_REQUEST);
        var request = new UpgradeBuildingRequest(_id);
        string requestJSON = JsonConvert.SerializeObject(request);
        upgradeRequest.AddString(requestJSON);
        ClientManager.Client.Send(upgradeRequest);
    }
    [MessageHandler((ushort)ServerToClient.UPGRADE_BUILDING_RESULT)]
    private static void UpgradeResult(Message message)
    {
        UIController.Instance.CloseScreenIfActive(UIController.UIScreen.BuildingUpgradeMenu);
    }
    [MessageHandler((ushort)ServerToClient.BUILDING_OPEN_UPGRADE_MENU)]
    private static void BuildingUpgradeMenuOpen(Message message)
    {
        string newLevelInfoJSON = message.GetString();
        var info = JsonConvert.DeserializeObject<NewBuildingLevelInfo>(newLevelInfoJSON);
        var screen = UIController.Instance.EnableScreen(UIController.UIScreen.BuildingUpgradeMenu);
        int deltaGPS = info.newGoldPerSecond - info.oldGoldPerSecond;
        var playerGold = ClientManager.TargetResponse.Gold;
        bool isAffordable = playerGold >= info.cost;
        screen.GetComponent<BuildingUpgradeMenu>().Configrure(info.buildingId, info.buildingName, CurrencyController.ConvertCurrencyToString(info.cost), CurrencyController.ConvertCurrencyToString(info.oldGoldPerSecond), CurrencyController.ConvertCurrencyToString(deltaGPS), isAffordable, null);
    }
}
