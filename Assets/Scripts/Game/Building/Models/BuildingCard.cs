using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingCard : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image _buildingIcon;
    [SerializeField] private TextMeshProUGUI _buildingName;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private TextMeshProUGUI _goldPerSecond;
    private PlaceableObject _object;
    private BuildingCardTemplate _template;
    public void InsertCard(BuildingCardTemplate template)
    {
        _template = template;
        _buildingIcon.sprite = template.IconImage;
        _buildingName.text = template.Name;
        _price.text = template.Price.ToString();
        _goldPerSecond.text = template.GoldPerSecond.ToString();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        UIController.Instance.EnableScreen(UIController.UIScreen.None);
        _object = Instantiate(_template.Object);
        PlayerBuildingController.Instance.StartHoldingItem(_object);
    }
}