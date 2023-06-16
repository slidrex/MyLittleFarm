using Newtonsoft.Json;
using Riptide;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotRequestHandler : MonoBehaviour
{
    public static void SendExpandRequest(bool horizontal)
    {
        var msg = Message.Create(MessageSendMode.Reliable, ClientToServer.PLOT_EXPAND_REQUEST);
        var request = new ExpandRequest(ClientManager.TargetResponse.Plot.PlotID, horizontal);
        string requestJSON = JsonConvert.SerializeObject(request);
        msg.AddString(requestJSON);
        ClientManager.Client.Send(msg);
    }
    [MessageHandler((ushort)ServerToClient.PLOT_EXPAND_RESULT)]
    public static void PlotExpandResultHandler(Message message)
    {
        string messageJSON = message.GetString();
        var response = JsonConvert.DeserializeObject<ExpandRequest>(messageJSON);
        FarmCompositeRoot.Instance.MapController.ExpandMap(response.horizontalExpand);
    }
}
