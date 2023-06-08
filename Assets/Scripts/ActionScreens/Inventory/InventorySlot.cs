using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Image _slotImage;
    [SerializeField] private Image _itemImage;
    public int SlotIndex { get; private set; }
    private ISlotEventCatcher _eventCatcher;
    public void Configure(int index, ISlotEventCatcher catcher)
    {
        SlotIndex = index;
        _eventCatcher = catcher;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _eventCatcher?.BaseEventCatcher.Invoke(this, SlotEvent.OnPointerDown);
    }

    public void RenderSlot(Item item)
    {
        if(item == null)
        {
            _itemImage.gameObject.SetActive(false);
        }
        else
        {
            _itemImage.gameObject.SetActive(true);
            _itemImage.sprite = item.Sprite;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _eventCatcher?.BaseEventCatcher.Invoke(this, SlotEvent.OnDragBegin);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _eventCatcher?.BaseEventCatcher.Invoke(this, SlotEvent.OnDragEnd);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _eventCatcher?.BaseEventCatcher.Invoke(this, SlotEvent.OnDrag);
    }

    public void OnDrop(PointerEventData eventData)
    {
        _eventCatcher?.BaseEventCatcher.Invoke(this, SlotEvent.OnDrop);
    }
}
