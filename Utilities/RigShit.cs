using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Photon.Realtime;
using Uptime.UI;
using GorillaLocomotion.Gameplay;
using HarmonyLib;

namespace RigStuff //ignore its from my old shit
{
    internal class RigShit : MonoBehaviour
    {
        public static VRRig GetRigFromPlayer(Photon.Realtime.Player p)
        {
            return GorillaGameManager.instance.FindPlayerVRRig(p);
        }

        public static PhotonView GetViewFromPlayer(Photon.Realtime.Player p)
        {
            return WristMenu.rig2view(GorillaGameManager.instance.FindPlayerVRRig(p));
        }

        public static VRRig GetOwnVRRig()
        {
            return GorillaTagger.Instance.offlineVRRig;
        }

        public static PhotonView GetViewFromRig(VRRig rig)
        {
            return WristMenu.rig2view(rig);
        }

        public static Photon.Realtime.Player GetPlayerFromRig(VRRig rig)
        {
            return WristMenu.rig2view(rig).Owner;
        }

        public static GorillaRopeSwing GetPlayersRope(VRRig rig)
        {
            return (GorillaRopeSwing)Traverse.Create(rig).Field("currentRopeSwing").GetValue();
        }

        public static bool battleIsOnCooldown(VRRig rig)
        {
            return rig.mainSkin.material.name.Contains("hit");
        }

        public static Photon.Realtime.Player GetRandomPlayer(bool includeSelf)
        {
            if (includeSelf)
            {
                Player p = PhotonNetwork.PlayerList[UnityEngine.Random.Range(0, 11)];
                if (p != null)
                {
                    return p;
                }
                return GetRandomPlayer(includeSelf);
            }
            Player p2 = PhotonNetwork.PlayerListOthers[UnityEngine.Random.Range(0, 10)];
            if (p2 != null)
            {
                return p2;
            }
            return GetRandomPlayer(includeSelf);
        }
    }
}
