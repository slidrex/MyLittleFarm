using System;
using UnityEngine;

public class WorkbenchScreen : MonoBehaviour, IInventory<Item>, ISlotEventCatcher
{
    [SerializeField] private Transform _slotContainer;
    private InventorySlot[] _renderSlots;
    private Item[] _items;
    public Action<Item, int, SlotEvent> SlotEventHandler { get; set; }

    public Action<InventorySlot, SlotEvent> BaseEventCatcher { get; set; }

    private void Awake()
    {
        _renderSlots = new InventorySlot[9];
        _items = new Item[9];

        for(int i = 0; i < _renderSlots.Length; i++)
        {
            var slot = _slotContainer.GetChild(i).GetComponent<InventorySlot>();
            slot.Configure(i, this);
            _renderSlots[i] = slot;
            BaseEventCatcher = CatchEvent;
        }
    }
    private void CatchEvent(InventorySlot slot, SlotEvent ev) => SlotEventHandler?.Invoke(_items[slot.SlotIndex], slot.SlotIndex, ev);
    public int GetFreeIndex()
    {
        for(int i = 0; i < _renderSlots.Length; i++)
        {
            if (_items[i] == null) return i;
        }
        return -1;
    }

    public void InsertItem(Item item, int index)
    {
        _items[index] = item;
        _renderSlots[index].RenderSlot(item);
    }

    public void RenderSlot(int index, Item item)
    {
        _renderSlots[index].RenderSlot(item);
    }
}
