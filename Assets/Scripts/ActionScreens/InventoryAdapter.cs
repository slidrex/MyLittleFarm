

using UnityEngine;

public class InventoryAdapter<T> where T : Item
{
    private IInventory<T> _firstScreen;
    private IInventory<T> _secondScreen;
    private T _handedItem;
    private int _handedIndex;
    private bool isFirst;
    public InventoryAdapter(IInventory<T> first, IInventory<T> second)
    {
        _firstScreen = first;
        _secondScreen = second;
    }
    public void Start()
    {
        _firstScreen.SlotEventHandler = OnSlotActionFirst;
        _secondScreen.SlotEventHandler = OnSlotActionSecond;
    }
    public void Stop()
    {
        _firstScreen.SlotEventHandler = null;
        _secondScreen.SlotEventHandler = null;
    }
    private void OnSlotActionFirst(T item, int slot, SlotEvent slotEvent)
    {
        if (slotEvent == SlotEvent.OnDragBegin && item != null && _handedItem == null)
        {
            _handedIndex = slot;
            _handedItem = item;
            isFirst = true;
            _firstScreen.RenderSlot(slot, null);
        }
        if(slotEvent == SlotEvent.OnDrop && _handedItem != null)
        {
            _firstScreen.InsertItem(_handedItem, slot);
            if (isFirst) _firstScreen.InsertItem(item, _handedIndex);
            else _secondScreen.InsertItem(item, _handedIndex);
        }
        if(slotEvent == SlotEvent.OnDragEnd) _handedItem = null;
    }
    private void OnSlotActionSecond(T item, int slot, SlotEvent slotEvent)
    {
        if (slotEvent == SlotEvent.OnDragBegin && item != null && _handedItem == null)
        {
            _handedIndex = slot;
            _handedItem = item;
            isFirst = false;
            _secondScreen.RenderSlot(slot, null);
        }
        if (slotEvent == SlotEvent.OnDrop && _handedItem != null)
        {
            _secondScreen.InsertItem(_handedItem, slot);
            if (isFirst) _firstScreen.InsertItem(item, _handedIndex);
            else _secondScreen.InsertItem(item, _handedIndex);
        }
        if (slotEvent == SlotEvent.OnDragEnd) _handedItem = null;
    }
}
