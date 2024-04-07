using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using HarmonyLib;
using System.Threading;
using System.Net;
using Photon.Pun;
using System.Linq;
using GorillaLocomotion.Gameplay;

namespace Uptime.Backend
{
    [HarmonyPatch(typeof(VRRig), "OnDisable")]
    internal class GhostPatch : MonoBehaviour
    {
        public static bool Prefix(VRRig __instance)
        {
            if (__instance == GorillaTagger.Instance.offlineVRRig)
            {
                return false;
            }
            return true;
        }
    }
}
