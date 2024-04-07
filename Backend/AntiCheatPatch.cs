using GTAG_NotificationLib;
using HarmonyLib;
using Photon.Pun;
using PlayFab;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Uptime.Backend
{
    [HarmonyPatch(typeof(GorillaNot), "SendReport")]
    internal class anticheatnotif : MonoBehaviour
    {
        // Token: 0x06000010 RID: 16 RVA: 0x0000216C File Offset: 0x0000036C
        private static bool Prefix(string susReason, string susId, string susNick)
        {
            if (susId == PhotonNetwork.LocalPlayer.UserId)
            {
                NotifiLib.SendNotification("<color=red>[ANTICHEAT] REPORTED FOR: " + susReason + "</color>");
            }
            return false;
        }
    }
}
