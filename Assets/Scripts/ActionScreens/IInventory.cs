public enum SlotEvent
{
    OnPointerDown,
    OnDragBegin,
    OnDragEnd,
    OnDrag,
    OnDrop
}
public interface ISlotEventCatcher
{
    public System.Action<InventorySlot, SlotEvent> BaseEventCatcher { get; }
}
public interface IInventory<I> where I : Item
{
    public void InsertItem(I item, int index);
    public int GetFreeIndex();
    public System.Action<I, int, SlotEvent> SlotEventHandler { get; set; }
    public void RenderSlot(int index, I item);
}
