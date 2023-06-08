using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroppedItem : MonoBehaviour
{
    [SerializeField] private Item _item;
    private SpriteRenderer _spriteRenderer;
    public Item Item { get; private set; }
    private void Start()
    {
        if (Item == null) Item = Instantiate(_item);
        Item.Init(_item.ID);
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _item.Sprite;
    }
    public void Configure(Item item)
    {
        Item = Instantiate(item);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerObject>(out var obj))
        {
            var response = obj.Player.Inventory.ItemRepository.AddItem(Item);
            if (response == Inventory.InventoryAddReponse.OK) OnItemCollected(Item);
            else OnItemCollectFailed(Item, response);
        }
    }
    protected virtual void OnItemCollected(Item item)
    {
        Destroy(gameObject);
    }
    protected virtual void OnItemCollectFailed(Item item, Inventory.InventoryAddReponse reponse)
    {
        if (reponse == Inventory.InventoryAddReponse.UNINITIALIZED_ITEM) throw new System.Exception("Unitialized item!");
    }
}
