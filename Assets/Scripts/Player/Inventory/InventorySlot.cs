using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image _slotImage;
    [SerializeField] private Image _itemImage;
    public int SlotIndex { get; private set; }
    public void Configure(int index)
    {
        SlotIndex = index;
    }
}
