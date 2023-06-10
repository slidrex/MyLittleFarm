using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using static Inventory;

public class ItemRepository : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _slotHolder;
    [SerializeField] private Image _slotPointer;
    public int SelectedSlot { get; private set; }

    private InventorySlot[] _renderSlots;
    public void Configure()
    {
        _renderSlots = new InventorySlot[_slotHolder.childCount];

        for (int i = 0; i < _renderSlots.Length; i++)
        {
            _renderSlots[i] = _slotHolder.GetChild(i).GetComponent<InventorySlot>();
            _renderSlots[i].Configure(i);
            
        }
    }
}
