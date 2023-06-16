using Riptide;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRuntimeGoldHandler : MonoBehaviour
{
    [MessageHandler((ushort)ServerToClient.ADD_PLAYER_GOLD)]
    private static void GoldAddHandler(Message message)
    {
        long newGold = message.GetLong();

        ClientManager.TargetResponse.Gold += newGold;
        FarmCompositeRoot.Instance.CurrencyController.SetMoneyValue(ClientManager.TargetResponse.Gold);
    }
}
