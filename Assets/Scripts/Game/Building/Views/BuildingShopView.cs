using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingShopView : MonoBehaviour
{
    [SerializeField] private BuildingCardTemplate[] _cardTemplates;
    [SerializeField] private Transform _buildingShopCardContainer;
    private BuildingCard[] _cards;
    private void Awake()
    {
        Configure();
        RenderOffers(_cardTemplates);
    }
    private void Configure()
    {
        _cards = new BuildingCard[_buildingShopCardContainer.childCount];
        for(int i = 0; i < _cards.Length; i++)
        {
            _cards[i] = _buildingShopCardContainer.GetChild(i).GetComponent<BuildingCard>();
        }
    }
    public void RenderOffers(BuildingCardTemplate[] template)
    {
        for(int i = 0; i < _cards.Length; i++)
        {
            bool templatesUsed = template.Length <= i;
            if (templatesUsed)
            {
                _cards[i].gameObject.SetActive(false);
            }
            else _cards[i].InsertCard(template[i]);
        }
    }
}
