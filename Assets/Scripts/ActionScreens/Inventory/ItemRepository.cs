using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using static Inventory;

public class ItemRepository : MonoBehaviour, IInventory<Item>, ISlotEventCatcher
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private DroppedItem _droppedItemInstance;
    [SerializeField] private Transform _slotHolder;
    [SerializeField] private Image _slotPointer;
    public int SelectedSlot { get; private set; }

    public Action<InventorySlot, SlotEvent> BaseEventCatcher { get; set; }
    public Action<Item, int, SlotEvent> SlotEventHandler { get; set; }

    private InventorySlot[] _renderSlots;
    private Item[] _inventoryItems;
    public void Configure()
    {
        _renderSlots = new InventorySlot[_slotHolder.childCount];
        _inventoryItems = new Item[_slotHolder.childCount];
        for (int i = 0; i < _renderSlots.Length; i++)
        {
            _renderSlots[i] = _slotHolder.GetChild(i).GetComponent<InventorySlot>();
            BaseEventCatcher = CatchEvents;
            _renderSlots[i].Configure(i, this);
            
        }
        SelectSlot(0);
    }
    private void CatchEvents(InventorySlot slot, SlotEvent ev) => SlotEventHandler?.Invoke(_inventoryItems[slot.SlotIndex], slot.SlotIndex, ev);
    public InventoryAddReponse AddItem(Item item)
    {
        if (item.ID == 0) return InventoryAddReponse.UNINITIALIZED_ITEM;
        for(int i = 0; i < _inventoryItems.Length; i++)
        {
            if (_inventoryItems[i] == null)
            {
                _inventoryItems[i] = item;
                _renderSlots[i].RenderSlot(item);
                return InventoryAddReponse.OK;
            }
        }
        return InventoryAddReponse.FULL_INVENTORY;
    }
    private InventoryRemoveReponse RemoveItem()
    {
        if(_inventoryItems[SelectedSlot] == null)
        {
            return InventoryRemoveReponse.ITEM_NOT_EXISTS;
        }
        Vector2 mouseVector = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - _playerTransform.position).normalized;
        var item = Instantiate(_droppedItemInstance, _playerTransform.position + (Vector3)mouseVector * 5, Quaternion.identity);
        item.Configure(_inventoryItems[SelectedSlot]);

        _renderSlots[SelectedSlot].RenderSlot(null);
        _inventoryItems[SelectedSlot] = null;
        return InventoryRemoveReponse.OK;
    }
    private void SelectSlot(int index)
    {
        SelectedSlot = index;
        _slotPointer.transform.SetParent(_renderSlots[index].transform);
        _slotPointer.rectTransform.anchoredPosition = Vector2.zero;
    }
    public void PollSelectEvents()
    {
        if(Input.mouseScrollDelta.y != 0)
        {
            SelectSlot((int)Mathf.Repeat(SelectedSlot - Mathf.Sign(Input.mouseScrollDelta.y), _renderSlots.Length));
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RemoveItem();
        }
    }

    public void InsertItem(Item item, int index)
    {
        _renderSlots[index].RenderSlot(item);
        _inventoryItems[index] = item;
    }

    public void RenderSlot(int index, Item item)
    {
        _renderSlots[index].RenderSlot(item);
    }

    public int GetFreeIndex()
    {
        for(int i = 0; i < _inventoryItems.Length; i++)
        {
            if (_inventoryItems[i] == null) return i;
        }
        return -1;
    }
    public int GetSlotIndex(InventorySlot slot) => slot.SlotIndex;
}
