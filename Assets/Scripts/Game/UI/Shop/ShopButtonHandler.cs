using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonHandler : MonoBehaviour
{
    [SerializeField] private Button _openShopButton;
    [SerializeField] private Button _closeShopButton;
    [SerializeField] private UIController _UIController;
    private void Start()
    {
        _openShopButton.onClick .AddListener(() => _UIController.EnableScreen(UIController.UIScreen.Shop));
        _closeShopButton.onClick.AddListener(() => _UIController.EnableScreen(UIController.UIScreen.None));
    }
    private void OnDestroy()
    {
        _openShopButton.onClick.RemoveAllListeners();
        _closeShopButton.onClick.RemoveAllListeners();
    }
}
