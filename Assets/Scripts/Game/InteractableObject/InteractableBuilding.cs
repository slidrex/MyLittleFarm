using Riptide;
using UnityEditor;
using UnityEngine;

[RequireComponent (typeof(PlaceableObject))]
public class InteractableBuilding : InteractableObject
{
    private PlaceableObject _placeableObject;
    private void Awake()
    {
        _placeableObject = GetComponent<PlaceableObject>();
    }
    protected override bool OnActivate(bool isActive)
    {
        if (_placeableObject.IsConstructed == false) return false;
        

        var openInfoRequest = Message.Create(MessageSendMode.Reliable, ClientToServer.BUILDING_OPEN_BUILDING_UPGRADE_MENU_REQUEST);
        openInfoRequest.AddLong(_placeableObject.Id);
        ClientManager.Client.Send(openInfoRequest);
        
        return true;
    }
}
