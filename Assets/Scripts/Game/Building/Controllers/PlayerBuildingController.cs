using Assets.Scripts.Game.Building.Models;
using Newtonsoft.Json;
using Riptide;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerBuildingController : MonoBehaviour
{
    [SerializeField] private Color32 _blockedColor;
    [SerializeField] private Color32 _notBlockedColor;
    public static PlayerBuildingController Instance;
    private PlaceableObject _placeableObject;
    private Vector2 _placeableObjectPosition;
    private bool _isInsidePlot;
    private bool _isNotCollided;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if(_placeableObject != null) ProcessHoldingItem();
    }
    public void StartHoldingItem(PlaceableObject obj)
    {
        _placeableObject = obj;
        _isNotCollided = true;
        _placeableObject.StartCarring(OnPlaceableObjectClick, OnPlaceableObjectTriggerEnter);
    }
    private void ProcessHoldingItem()
    {
        Vector2 pointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 currentPlacealbeObjectPosition = new Vector2(Mathf.Round(pointerPosition.x), Mathf.Round(pointerPosition.y));
        if(currentPlacealbeObjectPosition != _placeableObjectPosition)
        {
            OnPlaceableObjectChangedPosition(currentPlacealbeObjectPosition);
        } 
        _placeableObjectPosition = new Vector2(Mathf.Round(pointerPosition.x), Mathf.Round(pointerPosition.y));
        
        _placeableObject.transform.position = _placeableObjectPosition;
    }
    private void SetBlockingColor()
    {
        _placeableObject.ChangeColor(_isInsidePlot && _isNotCollided ? _notBlockedColor : _blockedColor);
    }
    private void ReturnObjectColor()
    {
        _placeableObject.ChangeColor(Color.white);
    }
#region Handlers
    private void OnPlaceableObjectTriggerEnter(Collider2D collider, bool isEnterOrExit)
    {
        _isNotCollided = !isEnterOrExit;
        SetBlockingColor();
    }
    public void DestroyHoldingBuilding()
    {
        Destroy(_placeableObject.gameObject);
        _placeableObject = null;
    }
    private void OnPlaceableObjectClick()
    {
        if (!_isInsidePlot || !_isNotCollided) return;
        
        
        ReturnObjectColor();
        var placeRequest = Message.Create(MessageSendMode.Reliable, ClientToServer.BUILD_REQUEST);
        LoginResponse targetResponse = ClientManager.TargetResponse;
        
        var buildRequest = new BuildRequest(targetResponse.Plot.PlotID, (int)_placeableObject.transform.position.x, (int)_placeableObject.transform.position.y, 0);
        string buildRequestJSON = JsonConvert.SerializeObject(buildRequest);
        placeRequest.AddString(buildRequestJSON);
        Instance.DestroyHoldingBuilding();
        ClientManager.Client.Send(placeRequest);
        _placeableObject = null;
    }
    [MessageHandler((ushort)ServerToClient.BUILD_RESPONSE)]
    public static void BuildResponseHandler(Message message)
    {
        bool isSuccessful = message.GetBool();
        if (isSuccessful)
        {
            var buildingResponse = JsonConvert.DeserializeObject<BuildingModel>(message.GetString());
            FarmCompositeRoot.Instance.BuildingController.InstantiateBuilding(buildingResponse);
        }
    }
    private void OnPlaceableObjectChangedPosition(Vector2 newPosition)
    {
        _isInsidePlot = MapModel.IsInsidePlot(newPosition);


        SetBlockingColor();
    }
#endregion
}
