using UnityEngine;

public class Inventory : MonoBehaviour
{
    public enum InventoryAddReponse
    {
        OK,
        FULL_INVENTORY,
        UNINITIALIZED_ITEM
    }
    public enum InventoryRemoveReponse
    {
        OK,
        ITEM_NOT_EXISTS
    }
    [field: SerializeField] public ItemRepository ItemRepository { get; private set; }
    private void Awake()
    {
        InitRepositories();
    }
    private void Update()
    {
        PollRepositoryEvents();
    }
    private void InitRepositories()
    {
        ItemRepository.Configure();
    }
    private void PollRepositoryEvents()
    {
        ItemRepository.PollSelectEvents();
    }
}
