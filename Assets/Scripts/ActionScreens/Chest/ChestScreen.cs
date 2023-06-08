using System;
using UnityEngine;

public class ChestScreen : MonoBehaviour, IInventory<Item>, ISlotEventCatcher
{
    private Item[] _chestItems;
    private InventorySlot[] _renderSlots;
    [SerializeField] private Transform _slotsHolder;

    public Action<InventorySlot, SlotEvent> BaseEventCatcher { get; set; }
    public Action<Item, int, SlotEvent> SlotEventHandler { get; set; }

    private void Awake()
    {
        _chestItems = new Item[_slotsHolder.childCount];
        _renderSlots = new InventorySlot[_slotsHolder.childCount];
        for(int i = 0; i < _slotsHolder.childCount; i++)
        {
            var obj = _slotsHolder.GetChild(i).GetComponent<InventorySlot>();
            _renderSlots[i] = obj;
            BaseEventCatcher = CatchEvents;
            obj.Configure(i, this);
        }
    }
    private void CatchEvents(InventorySlot slot, SlotEvent ev) => SlotEventHandler?.Invoke(_chestItems[slot.SlotIndex], slot.SlotIndex, ev);
    public int GetFreeIndex()
    {
        for(int i = 0; i < _chestItems.Length; i++)
        {
            if (_chestItems[i] == null) return i;
        }
        return -1;
    }

    public void InsertItem(Item item, int index)
    {
        _chestItems[index] = item;
        _renderSlots[index].RenderSlot(item);
    }

    public void RenderSlot(int index, Item item) => _renderSlots[index].RenderSlot(item);
}
