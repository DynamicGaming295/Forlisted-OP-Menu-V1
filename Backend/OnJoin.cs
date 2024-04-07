using System;
using System.Collections.Generic;
using System.Text;
using Photon.Realtime;
using GorillaNetworking;
using HarmonyLib;
using Mono;
using UnityEngine;
using GTAG_NotificationLib;
using Uptime.UI;
using Photon.Pun;
using System.Runtime.CompilerServices;

namespace Uptime.Backend
{

    [HarmonyPatch(typeof(GorillaNot))]
    [HarmonyPatch("OnPlayerEnteredRoom", MethodType.Normal)]
    internal class OnJoin : HarmonyPatch
    {
        private static void Prefix(Player newPlayer)
        {
            NotifiLib.SendNotification("<color=blue>[ROOM]:</color> Player " + newPlayer.NickName + " Joined Lobby");
        }
    }

    [HarmonyPatch(typeof(GorillaNot))]
    [HarmonyPatch("OnPlayerLeftRoom", MethodType.Normal)]
    internal class OnLeave : HarmonyPatch
    {
        private static void Prefix(Player otherPlayer)
        {
            if (otherPlayer != PhotonNetwork.LocalPlayer)
            {
                NotifiLib.SendNotification("<color=blue>[ROOM]:</color> Player " + otherPlayer.NickName + " Left Lobby");
                if (PhotonNetwork.IsMasterClient)
                {
                    NotifiLib.SendNotification("<color=yellow>[ROOM]: YOU ARE NOW MASTER CLIENT!</color>");
                }
            }
        }
    }
}