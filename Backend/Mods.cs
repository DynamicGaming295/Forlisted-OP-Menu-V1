using Uptime.Utilities;
using Photon.Pun;   
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using Object = UnityEngine.Object;
using ExitGames.Client.Photon;
using UnityEngine;
using System.Text;
using System.Threading.Tasks;
using Uptime.UI;
using GorillaNetworking;
using RigStuff;
using GorillaLocomotion.Gameplay;
using GorillaExtensions;
using Steamworks;
using HarmonyLib;
using System.Reflection;
using GorillaTag;
using static UnityEngine.UI.GridLayoutGroup;
using Photon.Pun.UtilityScripts;
using System.IO;
using static MonoMod.Cil.RuntimeILReferenceBag.FastDelegateInvokers;
using Oculus.Interaction.HandGrab;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;
using GorillaTagScripts;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Voice.Unity;
using System.ComponentModel;
using UnityEngine.UIElements;
using OVRSimpleJSON;
using GTAG_NotificationLib;
using System.Threading;
using UnityEngine.XR;
using UnityEngine.InputSystem.HID;
using System.Runtime.InteropServices;
using TMPro;
using Random = UnityEngine.Random;
using PlayFab.ClientModels;
using PlayFab;
using System.Text.RegularExpressions;
using UnityEngine.UI;

namespace Uptime.Backend
{
    internal class Mods : MonoBehaviour
    {
        public static bool oiwefkwenfjk;

        public static void CasualGamemode() 
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                Hashtable hashtable = new Hashtable();
                hashtable.Add("gameMode", "forestDEFAULTMODDED_MODDED_CASUALCASUAL");
                PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable, null, null);
            }
        }

        public static void HuntGamemode()  
        {

            if (ControllerInputPoller.instance.leftGrab)
            {
                Hashtable hashtable = new Hashtable();
                hashtable.Add("gameMode", "forestDEFAULTMODDED_MODDED_HUNTHUNT");
                PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable, null, null);
            }
        }

        public static void BattleGamemode() 
        {

            if (ControllerInputPoller.instance.leftGrab)
            {
                Hashtable hashtable = new Hashtable();
                hashtable.Add("gameMode", "forestDEFAULTMODDED_MODDED_BATTLEPAINTBRAWL");
                PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable, null, null);
            }
        }


        public static void InfectionGamemode() 
        {

            if (ControllerInputPoller.instance.leftGrab)
            {
                Hashtable hashtable = new Hashtable();
                hashtable.Add("gameMode", "forestDEFAULTMODDED_MODDED_INFECTION");
                PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable, null, null);
            }
        }


        public static void TrapStump() 
        {

            if (ControllerInputPoller.instance.leftGrab)
            {
                Hashtable hashtable = new Hashtable();
                string name = "";
                foreach (char character in PhotonNetwork.CurrentRoom.CustomProperties["gameMode"].ToString())
                {
                    if (!char.IsLower(character))
                    {
                        name += character;
                    }
                }
                hashtable.Add("gameMode", name);
                PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable, null, null);
            }
        }


        public static void BreakAudioAll()
        {
            if (ControllerInputPoller.TriggerFloat(XRNode.RightHand) == 1f)
            {
                GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", RpcTarget.Others, new object[]{
                    111,
                    false,
                    999999f
                });
            }
        }


        public static void Name1()
        {
            SetName1("DYNAMIC");
        }

        private static void SetName1(string PlayerName)
        {
            PhotonNetwork.LocalPlayer.NickName = PlayerName;
            PhotonNetwork.NickName = PlayerName;
            PhotonNetwork.NetworkingClient.NickName = PlayerName;
            GorillaComputer.instance.currentName = PlayerName;
            GorillaComputer.instance.savedName = PlayerName;
            GorillaComputer.instance.offlineVRRigNametagText.text = PlayerName;
            GorillaLocomotion.Player.Instance.name = PlayerName;
            PlayerPrefs.SetString("playerName", PlayerName);
            PlayerPrefs.Save();
        }


        public static void Name5()
        {
            SetName5("R U N");
        }

        private static void SetName5(string PlayerName)
        {
            PhotonNetwork.LocalPlayer.NickName = PlayerName;
            PhotonNetwork.NickName = PlayerName;
            PhotonNetwork.NetworkingClient.NickName = PlayerName;
            GorillaComputer.instance.currentName = PlayerName;
            GorillaComputer.instance.savedName = PlayerName;
            GorillaComputer.instance.offlineVRRigNametagText.text = PlayerName;
            GorillaLocomotion.Player.Instance.name = PlayerName;
            PlayerPrefs.SetString("playerName", PlayerName);
            PlayerPrefs.Save();
        }

        public static void popsoundspam()
        {
            GorillaGameManager instance = GorillaGameManager.instance;
            foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
            {
                RPCFlushermod();
                PhotonView photonView = instance.FindVRRigForPlayer(player);
                bool flag = photonView != null;
                if (flag)
                {
                    photonView.RPC("PlayHandTap", 0, new object[]
                    {
                84,
                true,
                6560f
                    });
                }
            }
        }
        public static void CupidBowProjectile()
        {
            GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/Slingshot Chest Snap/DropZoneAnchor/Slingshot Anchor/Slingshot").GetComponent<Slingshot>().projectilePrefab.tag = "CupidBow_Projectile";
        }

        public static void WaterBallProjectile()
        {
            GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/Slingshot Chest Snap/DropZoneAnchor/Slingshot Anchor/Slingshot").GetComponent<Slingshot>().projectilePrefab.tag = "WaterBalloonProjectile";
        }


        public static void ForceTagLag()
        {
            RPCProtection();
            foreach (GorillaTagManager gorillaTagManager in GameObject.FindObjectsOfType<GorillaTagManager>())
            {
                gorillaTagManager.tagCoolDown = 999999f;
                gorillaTagManager.tagCoolDown = 999999f;
                gorillaTagManager.UpdateInfectionState();
            }
        }


        public static void CanyonsRopeControl()
        {
            Vector2 rightControllerPrimary2DAxis = ControllerInputPoller.instance.rightControllerPrimary2DAxis;
            bool flag = (double)Mathf.Abs(rightControllerPrimary2DAxis.x) > 0.3 || (double)Mathf.Abs(rightControllerPrimary2DAxis.y) > 0.3;
            if (flag)
            {
                foreach (GorillaRopeSwing gorillaRopeSwing in UnityEngine.Object.FindObjectsOfType(typeof(GorillaRopeSwing)))
                {
                    RopeSwingManager.instance.SendSetVelocity_RPC(gorillaRopeSwing.ropeId, 1, new Vector3(rightControllerPrimary2DAxis.x * 50f, rightControllerPrimary2DAxis.y * 50f, 0f), true);

                }
            }
        }


        public static void SmallBug()
        {
            GameObject.Find("Floating Bug Holdable").transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        public static void BigBug()
        {
            GameObject.Find("Floating Bug Holdable").transform.localScale = new Vector3(30f, 30f, 30f);
        }

        public static void FixBug()
        {
            GameObject.Find("Floating Bug Holdable").transform.localScale = new Vector3(1f, 1f, 1f);
        }

        public static void freezebug()
        {
            foreach (ThrowableBug throwableBug in UnityEngine.Object.FindObjectsOfType(typeof(ThrowableBug)))
            {
                throwableBug.bobingSpeed = 0f;
                throwableBug.maxNaturalSpeed = 0f;
                throwableBug.startingSpeed = 0f;
            }
        }


        public static void GrabBug()
        {
            GameObject.Find("Floating Bug Holdable").transform.position = GorillaTagger.Instance.rightHandTransform.position;
        }


        public static void OrbitBug()
        {
            GameObject bug = GameObject.Find("Floating Bug Holdable");
            Collider headCollider = GorillaTagger.Instance.headCollider;
            Vector3 orbit = headCollider.bounds.center;
            float speed = 37.5f;
            bug.transform.RotateAround(orbit, Vector3.right, speed * Time.deltaTime);
            bug.transform.RotateAround(orbit, Vector3.up, speed * Time.deltaTime);
        }


        public static void IronMan()
        {
            bool skibidi1 = ControllerInputPoller.instance.leftGrab;
            if (skibidi1)
            {
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(10f * GorillaTagger.Instance.offlineVRRig.transform.Find("rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L").right, (ForceMode)5);
                GorillaTagger.Instance.StartVibration(true, GorillaTagger.Instance.tapHapticStrength / 50f * GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.velocity.magnitude, GorillaTagger.Instance.tapHapticDuration);
            }
            bool skibidi2 = ControllerInputPoller.instance.rightGrab;
            if (skibidi2)
            {
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(10f * -GorillaTagger.Instance.offlineVRRig.transform.Find("rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R").right, (ForceMode)5);
                GorillaTagger.Instance.StartVibration(false, GorillaTagger.Instance.tapHapticStrength / 50f * GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.velocity.magnitude, GorillaTagger.Instance.tapHapticDuration);
            }
        }

        public static void NoTapCoolDown()
        {
            GorillaTagger.Instance.tapCoolDown = 0f;
        }


        public static void LoudHandTaps()
        {
            GorillaTagger.Instance.handTapVolume = 9999999999999999999;
        }


        public static void SilentHandTaps()
        {
            GorillaTagger.Instance.handTapVolume = 0;
        }


        public static void WallWalk()
        {
            RaycastHit raycastHit;
            Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position, -GorillaLocomotion.Player.Instance.rightControllerTransform.right, out raycastHit, 100f, int.MaxValue);
            RaycastHit raycastHit2;
            Physics.Raycast(GorillaLocomotion.Player.Instance.leftControllerTransform.position, GorillaLocomotion.Player.Instance.leftControllerTransform.right, out raycastHit2, 100f, int.MaxValue);
            if (ControllerInputPoller.instance.rightGrab)
            {
                if (raycastHit.distance < raycastHit2.distance)
                {
                    if (raycastHit.distance < 1f)
                    {
                        Vector3 normalized = (raycastHit.point - GorillaLocomotion.Player.Instance.rightControllerTransform.position).normalized;
                        Physics.gravity = normalized * 9.81f;
                    }
                    else
                    {
                        Physics.gravity = new Vector3(0f, -9.81f, 0f);
                    }
                }
                if (raycastHit.distance == raycastHit2.distance)
                {
                    Physics.gravity = new Vector3(0f, -9.81f, 0f);
                }
            }
            else
            {
                Physics.gravity = new Vector3(0f, -9.81f, 0f);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                if (raycastHit.distance > raycastHit2.distance)
                {
                    if (raycastHit2.distance < 1f)
                    {
                        Vector3 normalized2 = (raycastHit2.point - GorillaLocomotion.Player.Instance.leftControllerTransform.position).normalized;
                        Physics.gravity = normalized2 * 9.81f;
                    }
                    else
                    {
                        Physics.gravity = new Vector3(0f, -9.81f, 0f);
                    }
                }
                if (raycastHit.distance == raycastHit2.distance)
                {
                    Physics.gravity = new Vector3(0f, -9.81f, 0f);
                }
            }
            else
            {
                Physics.gravity = new Vector3(0f, -9.81f, 0f);
            }
        }


        public static void WallWalk2()
        {
            RaycastHit raycastHit;
            Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position, -GorillaLocomotion.Player.Instance.rightControllerTransform.right, out raycastHit, 100f, int.MaxValue);
            RaycastHit raycastHit2;
            Physics.Raycast(GorillaLocomotion.Player.Instance.leftControllerTransform.position, GorillaLocomotion.Player.Instance.leftControllerTransform.right, out raycastHit2, 100f, int.MaxValue);
            if (ControllerInputPoller.instance.rightGrab)
            {
                if (raycastHit.distance < raycastHit2.distance)
                {
                    if (raycastHit.distance < 1f)
                    {
                        Vector3 normalized = (raycastHit.point - GorillaLocomotion.Player.Instance.rightControllerTransform.position).normalized;
                        Physics.gravity = normalized * 9.81f;
                    }
                    else
                    {
                        Physics.gravity = new Vector3(0f, -9.81f, 0f);
                    }
                }
                if (raycastHit.distance == raycastHit2.distance)
                {
                    Physics.gravity = new Vector3(0f, -9.81f, 0f);
                }
            }
            else
            {
                Physics.gravity = new Vector3(0f, -9.81f, 0f);
            }
            if (ControllerInputPoller.instance.rightGrab)
            {
                if (raycastHit.distance > raycastHit2.distance)
                {
                    if (raycastHit2.distance < 1f)
                    {
                        Vector3 normalized2 = (raycastHit2.point - GorillaLocomotion.Player.Instance.leftControllerTransform.position).normalized;
                        Physics.gravity = normalized2 * 9.81f;
                    }
                    else
                    {
                        Physics.gravity = new Vector3(0f, -9.81f, 0f);
                    }
                }
                if (raycastHit.distance == raycastHit2.distance)
                {
                    Physics.gravity = new Vector3(0f, -9.81f, 0f);
                }
            }
            else
            {
                Physics.gravity = new Vector3(0f, -9.81f, 0f);
            }
        }


        public static void WallWalkBoth()
        {
            RaycastHit raycastHit;
            Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position, -GorillaLocomotion.Player.Instance.rightControllerTransform.right, out raycastHit, 100f, int.MaxValue);
            RaycastHit raycastHit2;
            Physics.Raycast(GorillaLocomotion.Player.Instance.leftControllerTransform.position, GorillaLocomotion.Player.Instance.leftControllerTransform.right, out raycastHit2, 100f, int.MaxValue);
            if (ControllerInputPoller.instance.rightGrab)
            {
                if (raycastHit.distance < raycastHit2.distance)
                {
                    if (raycastHit.distance < 1f)
                    {
                        Vector3 normalized = (raycastHit.point - GorillaLocomotion.Player.Instance.rightControllerTransform.position).normalized;
                        Physics.gravity = normalized * 9.81f;
                    }
                    else
                    {
                        Physics.gravity = new Vector3(0f, -9.81f, 0f);
                    }
                }
                if (raycastHit.distance == raycastHit2.distance)
                {
                    Physics.gravity = new Vector3(0f, -9.81f, 0f);
                }
            }
            else
            {
                Physics.gravity = new Vector3(0f, -9.81f, 0f);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                if (raycastHit.distance > raycastHit2.distance)
                {
                    if (raycastHit2.distance < 1f)
                    {
                        Vector3 normalized2 = (raycastHit2.point - GorillaLocomotion.Player.Instance.leftControllerTransform.position).normalized;
                        Physics.gravity = normalized2 * 9.81f;
                    }
                    else
                    {
                        Physics.gravity = new Vector3(0f, -9.81f, 0f);
                    }
                }
                if (raycastHit.distance == raycastHit2.distance)
                {
                    Physics.gravity = new Vector3(0f, -9.81f, 0f);
                }
            }
            else
            {
                Physics.gravity = new Vector3(0f, -9.81f, 0f);
            }



            if (ControllerInputPoller.instance.rightGrab)
            {
                if (raycastHit.distance > raycastHit2.distance)
                {
                    if (raycastHit2.distance < 1f)
                    {
                        Vector3 normalized2 = (raycastHit2.point - GorillaLocomotion.Player.Instance.leftControllerTransform.position).normalized;
                        Physics.gravity = normalized2 * 9.81f;
                    }
                    else
                    {
                        Physics.gravity = new Vector3(0f, -9.81f, 0f);
                    }
                }
                if (raycastHit.distance == raycastHit2.distance)
                {
                    Physics.gravity = new Vector3(0f, -9.81f, 0f);
                }
            }
            else
            {
                Physics.gravity = new Vector3(0f, -9.81f, 0f);
            }
        }


        public static void SpinHeadX()
        {
            VRMap head = GorillaTagger.Instance.offlineVRRig.head;
            head.trackingRotationOffset.x = head.trackingRotationOffset.x + 10f;
        }


        public static void SpinHeadY()
        {
            VRMap head = GorillaTagger.Instance.offlineVRRig.head;
            head.trackingRotationOffset.y = head.trackingRotationOffset.y + 10f;
        }


        public static void SpinHeadZ()
        {
            VRMap head = GorillaTagger.Instance.offlineVRRig.head;
            head.trackingRotationOffset.z = head.trackingRotationOffset.z + 10f;
        }


        public static void spazmonk()
        {
            GorillaTagger.Instance.offlineVRRig.head.rigTarget.eulerAngles = new UnityEngine.Vector3((float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 360));
            GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.eulerAngles = new UnityEngine.Vector3((float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 360));
            GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.eulerAngles = new UnityEngine.Vector3((float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 360));
            GorillaTagger.Instance.offlineVRRig.head.rigTarget.eulerAngles = new UnityEngine.Vector3((float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 180), (float)UnityEngine.Random.Range(0, 180));
            GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.eulerAngles = new UnityEngine.Vector3((float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 180), (float)UnityEngine.Random.Range(0, 180));
            GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.eulerAngles = new UnityEngine.Vector3((float)UnityEngine.Random.Range(0, 360), (float)UnityEngine.Random.Range(0, 180), (float)UnityEngine.Random.Range(0, 180));
        }


        public static void InvisMonkeMod()
        {
            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset.x = 180f;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset.x = 0f;
            }
        }


        public static void GhostMonkeMod()
        {
            bool Primary = ControllerInputPoller.instance.rightControllerSecondaryButton;
            {
                if (Primary == true)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }
        }


        public static void NoclipMod()
        {
            if (ControllerInputPoller.TriggerFloat(XRNode.RightHand) == 1f)
            {
                foreach (MeshCollider m in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    m.enabled = false;
                }
            }
            else
            {
                foreach (MeshCollider m2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    m2.enabled = true;
                }
            }
        }


        public static void LagAll()
        {
            if (GorillaGameManager.instance != null)
            {
                GorillaGameManager.instance.returnPhotonView.RPC("LaunchSlingshotProjectile", RpcTarget.All, new object[]
                {
                    GorillaLocomotion.Player.Instance.transform.position - new Vector3(0, 1,0),
                    Vector3.zero,
                    PoolUtils.GameObjHashCode(GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools/LavaRockProjectile(Clone)")),
                    -1,
                    true,

                    false,
                    1f,
                    1f,
                    1f,
                    1f,
                });
                GorillaGameManager.instance.returnPhotonView.RPC("LaunchSlingshotProjectile", RpcTarget.All, new object[]
                {
                    GorillaLocomotion.Player.Instance.transform.position - new Vector3(0, 1,0),
                    Vector3.zero,
                    PoolUtils.GameObjHashCode(GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools/LavaRockProjectile(Clone)")),
                    -1,
                    true,

                    false,
                    1f,
                    1f,
                    1f,
                    1f,
                });
            }
        }


        public static void Tpgun()
        {
            RaycastHit raycastHit;
            Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.transform.position, GorillaLocomotion.Player.Instance.rightControllerTransform.transform.forward, out raycastHit);
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            gameObject.transform.position = raycastHit.point;
            GameObject.Destroy(gameObject.GetComponent<BoxCollider>());
            GameObject.Destroy(gameObject.GetComponent<Rigidbody>());
            GameObject.Destroy(gameObject.GetComponent<Collider>());
            GameObject.Destroy(gameObject, Time.deltaTime);
            bool rightGrab = ControllerInputPoller.instance.rightGrab;
            if (rightGrab)
            {
                GorillaLocomotion.Player.Instance.transform.position = gameObject.transform.position;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = gameObject.transform.position;
            }
        }


        public static void taggunv2()
        {
            Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.transform.position, GorillaLocomotion.Player.Instance.headCollider.transform.forward, out var Ray);
            pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            pointer.transform.position = Ray.point;
            UnityEngine.Object.Destroy(pointer.GetComponent<BoxCollider>());
            UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(pointer.GetComponent<Collider>());
            UnityEngine.Object.Destroy(pointer, Time.deltaTime);
            if (ControllerInputPoller.instance.rightGrab == true)
            {
                GorillaLocomotion.Player.Instance.rightControllerTransform.position = pointer.transform.position;
            }
        }


        public static void TagBot()
        {
            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {

            }
            if (PhotonNetwork.InRoom)
            {
                if (!GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
                {
                    bool isInfectedPlayers = false;
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (vrrig.mainSkin.material.name.Contains("fected"))
                        {
                            isInfectedPlayers = true;
                            break;
                        }
                    }
                    if (isInfectedPlayers)
                    {


                    }
                }
                else
                {
                    bool isInfectedPlayers = false;
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (!vrrig.mainSkin.material.name.Contains("fected"))
                        {
                            isInfectedPlayers = true;
                            break;
                        }
                    }
                    if (isInfectedPlayers)
                    {
                        ;
                    }
                }
            }
        }



        private static bool rightHand;

        public static void TagAll()
        {
            if (!GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("infected"))
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You must be tagged.</color>");

            }
            else
            {
                bool isInfectedPlayers = false;
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (!vrrig.mainSkin.material.name.Contains("infected"))
                    {
                        isInfectedPlayers = true;
                        break;
                    }
                }
                if (isInfectedPlayers == true)
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (!vrrig.mainSkin.material.name.Contains("unfected"))
                        {
                            if (GorillaTagger.Instance.offlineVRRig.enabled == true)
                                GorillaTagger.Instance.offlineVRRig.enabled = false;
                            GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.transform.position;
                            GorillaTagger.Instance.myVRRig.transform.position = vrrig.transform.position;

                            Vector3 they = vrrig.transform.position;
                            Vector3 notthem = GorillaTagger.Instance.offlineVRRig.head.rigTarget.position;
                            float distance = Vector3.Distance(they, notthem);

                            if (GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("infected") && !vrrig.mainSkin.material.name.Contains("infected") && distance < 1.667)
                            {
                                if (rightHand == true) { GorillaLocomotion.Player.Instance.rightControllerTransform.position = they; } else { GorillaLocomotion.Player.Instance.leftControllerTransform.position = they; }
                            }
                        }
                    }
                }
                else
                {
                    NotifiLib.SendNotification("<color=grey>[</color><color=green>SUCCESS!</color><color=grey>]</color> <color=white>Everyone is tagged!</color>");
                    GorillaTagger.Instance.offlineVRRig.enabled = true;

                }
            }
        }

        private static object GetIndex(string v)
        {
            throw new NotImplementedException();
        }


        public static void TagAllV2()
        {
            foreach (GorillaTagManager tagManager in UnityEngine.Object.FindObjectsOfType(typeof(GorillaTagManager)))
            {
                foreach (Photon.Realtime.Player AllPlayer in PhotonNetwork.PlayerList)
                {
                    tagManager.currentInfected.Add(AllPlayer);
                    tagManager.UpdateState();

                }
            }
        }


        public static void BothHandFlickTag()
        {
            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {
                Vector3 currentPositionl = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                Vector3 forwardVectorl = GorillaLocomotion.Player.Instance.rightControllerTransform.forward;
                GorillaLocomotion.Player.Instance.rightControllerTransform.position = currentPositionl + forwardVectorl * 10f;

                GameObject left = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                GameObject right = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                left.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                right.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

                left.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                right.transform.position = GorillaTagger.Instance.rightHandTransform.position;

                left.GetComponent<Renderer>().material.color = new Color32(50, 50, 50, 255);
                right.GetComponent<Renderer>().material.color = new Color32(50, 50, 50, 255);

                UnityEngine.Object.Destroy(left.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(left.GetComponent<SphereCollider>());
                UnityEngine.Object.Destroy(right.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(right.GetComponent<SphereCollider>());
                UnityEngine.Object.Destroy(left, Time.deltaTime);
                UnityEngine.Object.Destroy(right, Time.deltaTime);
            }
            if (ControllerInputPoller.instance.leftControllerSecondaryButton)
            {
                Vector3 currentPositionr = GorillaLocomotion.Player.Instance.leftControllerTransform.position;
                Vector3 forwardVectorr = GorillaLocomotion.Player.Instance.leftControllerTransform.forward;
                GorillaLocomotion.Player.Instance.leftControllerTransform.position = currentPositionr + forwardVectorr * 10f;

                GameObject left = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                GameObject right = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                left.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                right.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

                left.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                right.transform.position = GorillaTagger.Instance.rightHandTransform.position;

                left.GetComponent<Renderer>().material.color = new Color32(50, 50, 50, 255);
                right.GetComponent<Renderer>().material.color = new Color32(50, 50, 50, 255);

                UnityEngine.Object.Destroy(left.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(left.GetComponent<SphereCollider>());
                UnityEngine.Object.Destroy(right.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(right.GetComponent<SphereCollider>());
                UnityEngine.Object.Destroy(left, Time.deltaTime);
                UnityEngine.Object.Destroy(right, Time.deltaTime);
            }
        }


        public static void noTagFreeze()
        {
            GorillaLocomotion.Player.Instance.disableMovement = false;
        }


        public static void AntiTagMod()
        {
            if (GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
            {
                foreach (GorillaTagManager tagman in GameObject.FindObjectsOfType<GorillaTagManager>())
                {
                    if (tagman.currentInfected.Contains(PhotonNetwork.LocalPlayer))
                    {
                        tagman.currentInfected.Remove(PhotonNetwork.LocalPlayer);
                    }
                    else
                    {
                        tagman.currentInfected.Add(PhotonNetwork.LocalPlayer);
                    }
                }
            }
        }


        public static void UnTagSelf()
        {
            foreach (GorillaTagManager tagManager in UnityEngine.Object.FindObjectsOfType(typeof(GorillaTagManager)))
            {
                var forme = PhotonNetwork.LocalPlayer;
                tagManager.currentInfected.Remove(forme);
                tagManager.UpdateState();

            }
        }


        public static void TagSelf()
        {
            foreach (GorillaTagManager tagManager in UnityEngine.Object.FindObjectsOfType(typeof(GorillaTagManager)))
            {
                var forme = PhotonNetwork.LocalPlayer;
                tagManager.currentInfected.Add(forme);
                tagManager.UpdateState();

            }
        }


        public static void FlyMod()
        {
            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime) * 15;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        public static void LeftHandFly()
        {
            if (ControllerInputPoller.instance.leftControllerPrimaryButton)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.leftControllerTransform.transform.forward * Time.deltaTime) * 4.5f;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }


        public static void FlyNoclip()
        {
            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {
                GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * 13f;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = false;
                }
            }
            else
            {
                foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider2.enabled = true;
                }
            }



        }



        public static void SlothFly()
        {
            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime) * 2;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }



        public static void FastFly()
        {
            bool rightControllerSecondaryButton = ControllerInputPoller.instance.rightControllerSecondaryButton;
            if (rightControllerSecondaryButton)
            {
                GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * 35.5f;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }


        public static void NormalArms()
        {
            GorillaLocomotion.Player.Instance.transform.localScale = new UnityEngine.Vector3(1.0f, 1.0f, 1.0f);
        }


        public static void LongArmsMod()
        {
            GorillaLocomotion.Player.Instance.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }


        public static void QuitMod()
        {
            Application.Quit();
        }


        public static void AntiReportDisconnect()
        {
            try
            {
                GameObject gameObject = GameObject.Find("Environment Objects/PersistentObjects_Prefab/GorillaUI");
                Transform transform = gameObject.transform;
                for (int i = 0; i < transform.childCount; i++)
                {
                    Transform transform2 = transform.GetChild(i);
                    bool flag = transform2.gameObject.name.Contains("Anchor") && transform2.gameObject.activeSelf;
                    if (flag)
                    {
                        string name = transform2.gameObject.name;
                        transform2 = transform2.Find("GorillaScoreBoard/LineParent");
                        for (int j = 0; j < transform2.childCount; j++)
                        {
                            Transform child = transform2.GetChild(j);
                            bool flag2 = child.name.Contains("GorillaPlayerScoreboardLine");
                            if (flag2)
                            {
                                Text component = child.Find("Player Name").GetComponent<Text>();
                                Transform transform3 = child.Find("ReportButton");
                                bool flag3 = component != null;
                                if (flag3)
                                {
                                    bool flag4 = component.text == PhotonNetwork.LocalPlayer.NickName.ToUpper();
                                    if (flag4)
                                    {
                                        foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                                        {
                                            bool flag5 = vrrig != GorillaTagger.Instance.offlineVRRig;
                                            if (flag5)
                                            {
                                                float num = Vector3.Distance(vrrig.rightHandTransform.position, transform3.position);
                                                float num2 = Vector3.Distance(vrrig.leftHandTransform.position, transform3.position);
                                                float num3 = 0.35f;
                                                bool flag6 = !name.Contains("Forest");
                                                if (flag6)
                                                {
                                                    num3 = 0.2f;
                                                }
                                                bool flag7 = num < num3 || num2 < num3;
                                                if (flag7)
                                                {
                                                    PhotonNetwork.Disconnect();
                                                    RPCProtection();
                                                    NotifiLib.SendNotification("<color=grey>[</color><color=purple>ANTI-REPORT</color><color=grey>]</color> <color=white>Someone attempted to report you, you have been disconnected.</color>");
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {

                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public static void SafetyRPCProtection()
        {
            GorillaNot.instance.rpcErrorMax = int.MaxValue;
            GorillaNot.instance.rpcCallLimit = int.MaxValue;
            GorillaNot.instance.logErrorMax = int.MaxValue;
            PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
            PhotonNetwork.OpCleanRpcBuffer(GorillaTagger.Instance.myVRRig);
            PhotonNetwork.RemoveBufferedRPCs(GorillaTagger.Instance.myVRRig.ViewID, null, null);
            PhotonNetwork.RemoveRPCsInGroup(int.MaxValue);
            PhotonNetwork.SendAllOutgoingCommands();
            GorillaNot.instance.OnPlayerLeftRoom(PhotonNetwork.LocalPlayer);
        }


        public static void SpeedTTTPig()
        {
            GorillaLocomotion.Player.Instance.jumpMultiplier = 1.7f;
            GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.7f;
        }

        public static void CustomBoards()
        {
            GameObject.Find("motdtext").GetComponent<Text>().text = "<color=white> Hey! This Menu was created by @dynamicgamingofficial295 for [forlisted] there are a LOT of mods on this menu and please go join the Discord" +
                "to get updates on the menu and my YouTube channel! </color>";
            GameObject.Find("COC Text").GetComponent<Text>().text = "<color=white>             Meanings                      " +



                " UND = UNDETECTABLE" +

                " Dectected = DETECTABLE" +

                " Dectected? = MAYBE DETECTED" +

                " LT = LEFT TRIGGER" +

                " RT = RIGHT TRIGGER" +

                " LG = LEFT GRIP" +

                " RG = RIGHT GRIP " +

                "I am not responsible for you getting banned, and if you do get banned report it in the Discord immediately" +

                "Have fun!";


            GameObject.Find("CodeOfConduct").GetComponent<Text>().text = "<color=white> Made by: @dynamicgamingofficial295 </color>";
            GameObject.Find("motd").GetComponent<Text>().text = "<color=white> Dynamic Mods </color>";
            GameObject.Find("WallScreenForest").GetComponent<Text>().text = "<color=yellow> Forlisted OP Menu has been successfully loaded, and is ready to be used. Click Y on left contoller to get" +
                "started.</color>";
            GameObject.Find("WallScreenCave").GetComponent<Text>().text = "<color=yellow> Forlisted OP Menu has been successfully loaded, and is ready to be used. Click Y on left contoller to get started" +
                " Use mods in Private to be safe! </color>";
            GameObject.Find("motdscreen").GetComponent<Renderer>().material.color = Color.black;
            GameObject.Find("REMOVE board").GetComponent<Renderer>().material.color = Color.white;
            GameObject.Find("wallmonitorforest").GetComponent<Renderer>().material.color = Color.black;
            GameObject.Find("wallmonitorcave").GetComponent<Renderer>().material.color = Color.white;
            GameObject.Find("wallmonitorcanyon").GetComponent<Renderer>().material.color = Color.black;
            GameObject.Find("screen").GetComponent<Renderer>().material.color = Color.white;
            GameObject.Find("wallmonitorcosmetics").GetComponent<Renderer>().material.color = Color.black;
            GameObject.Find("wallmonitorskyjungle").GetComponent<Renderer>().material.color = Color.white;
            GameObject.Find("monitor (1)").GetComponent<Renderer>().material.color = Color.black;
            GameObject.Find("info page 2 (1)").GetComponent<Renderer>().material.color = Color.white;
            GameObject.Find("stand (1)").GetComponent<Renderer>().material.color = Color.black;
            GameObject.Find("wallmonitor - mountain").GetComponent<Renderer>().material.color = Color.cyan;
            GameObject.Find("wallmonitor city back").GetComponent<Renderer>().material.color = Color.blue;
            GameObject.Find("screen (combined by EdMeshCombinerSceneProcessor)").GetComponent<Renderer>().material.color = Color.black;
            GameObject.Find("board (1)").GetComponent<Renderer>().material.color = Color.white;

        }

        public static void Disconnect()
        {
            PhotonNetwork.Disconnect();
        }


        public static void TriggerDisconnectR()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                if (PhotonNetwork.InRoom == true)
                {
                    PhotonNetwork.Disconnect();
                }
                else
                {
                    NotifiLib.SendNotification("<color=red>{ERROR}</color> <color=purple>{YOU ARE NOT CONNECTED TO A ROOM}</color>");
                }
            }
        }


        public static void TriggerDisconnect()
        {
            if (PhotonNetwork.InRoom == true)
            {
                if (ControllerInputPoller.instance.rightControllerIndexTouch > 0.5f)
                {
                    PhotonNetwork.Disconnect();
                }
            }
            else
            {
                NotifiLib.SendNotification("ERROR {NOT CONNECTED TO A ROOM}");
            }
        }


        public static void RPCFlushermod()
        {
            if (PhotonNetwork.InRoom && PhotonNetwork.CurrentRoom.IsVisible && GorillaTagger.Instance.myVRRig != null)
            {
                PhotonNetwork.OpCleanRpcBuffer(GorillaTagger.Instance.myVRRig);
                PhotonNetwork.OpCleanActorRpcBuffer(GorillaTagger.Instance.myVRRig.Controller.ActorNumber);
                PhotonNetwork.RemoveBufferedRPCs(GorillaTagger.Instance.myVRRig.ViewID);
            }
        }


        public static void AntiBan()
        {
            object obj;
            PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue("gameMode", out obj);
            if (!obj.ToString().Contains("MODDED") && PhotonNetwork.InRoom && PhotonNetwork.IsConnectedAndReady && PhotonNetwork.IsConnected)
            {
                ExecuteCloudScriptRequest executeCloudScriptRequest = new ExecuteCloudScriptRequest();
                executeCloudScriptRequest.FunctionName = "RoomClosed";
                executeCloudScriptRequest.FunctionParameter = new
                {
                    GameId = PhotonNetwork.CurrentRoom.Name,
                    Region = Regex.Replace(PhotonNetwork.CloudRegion, "[^a-zA-Z0-9]", "").ToUpper(),
                    UserId = PhotonNetwork.MasterClient.UserId,
                    ActorNr = 1,
                    ActorCount = 1,
                    AppVersion = PhotonNetwork.AppVersion
                };
                PlayFabClientAPI.ExecuteCloudScript(executeCloudScriptRequest, delegate (ExecuteCloudScriptResult result)
                {
                }, null, null, null);
                string gamemode = PhotonNetwork.CurrentRoom.CustomProperties["gameMode"].ToString().Replace(GorillaComputer.instance.currentQueue, GorillaComputer.instance.currentQueue + "MODDEDMODDED");
                ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable
  {
      { "gameMode", gamemode }
  };
                PhotonNetwork.CurrentRoom.SetCustomProperties(hash);
            }

        }


        public static void RPCProtection()
        {
            GorillaNot.instance.rpcErrorMax = int.MaxValue;
            GorillaNot.instance.rpcCallLimit = int.MaxValue;
            GorillaNot.instance.logErrorMax = int.MaxValue;
            PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
            PhotonNetwork.OpCleanRpcBuffer(GorillaTagger.Instance.myVRRig);
            PhotonNetwork.RemoveBufferedRPCs(GorillaTagger.Instance.myVRRig.ViewID, null, null);
            PhotonNetwork.RemoveRPCsInGroup(int.MaxValue);
            PhotonNetwork.SendAllOutgoingCommands();
            GorillaNot.instance.OnPlayerLeftRoom(PhotonNetwork.LocalPlayer);


        }

        public static void HeadSpin()
        {
            RigShit.GetOwnVRRig().head.trackingRotationOffset.y += 15f;
        }

        public static void nuhuhheadspin()
        {
            RigShit.GetOwnVRRig().head.trackingRotationOffset.y = 0.0f;

        }
        public static void placeholder() { }
        public static bool inSettings = false;

        public static void Settings()
        {
            WristMenu.settingsbuttons[0].enabled = false;
            WristMenu.buttons[0].enabled = false;
            inSettings = !inSettings;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static bool invisplat = false;
        public static bool stickyplatforms = false;
        public static GameObject funn;
        public static bool fpcc;

        public static void Platforms()
        {
            PlatformsThing(invisplat, stickyplatforms);
        }

        public static GameObject pointer;
        public static void fpc()
        {
            fpcc = true;
            if (GameObject.Find("Third Person Camera") != null)
            {
                funn = GameObject.Find("Third Person Camera");
                funn.SetActive(false);
            }
            if (GameObject.Find("CameraTablet(Clone)") != null)
            {
                funn = GameObject.Find("CameraTablet(Clone)");
                funn.SetActive(false);
            }
        }

        public static void fpcoff()
        {
            fpcc = false;
            if (funn != null)
            {
                funn.SetActive(true);
                funn = null;
            }
        }
        
        public static void Save()
        {
            WristMenu.settingsbuttons[1].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
            List<String> list = new List<String>();
            foreach (ButtonInfo info in WristMenu.settingsbuttons)
            {
                if (info.enabled == true)
                {
                    list.Add(info.buttonText);
                }
            }
            System.IO.Directory.CreateDirectory("TemplatePrefs");
            System.IO.File.WriteAllLines("TemplatePrefs\\templateSavedPrefs.txt", list);
        }

        public static void Load()
        {
            String[] thing = System.IO.File.ReadAllLines("TemplatePrefs\\templateSavedPrefs.txt");
            foreach (String thing2 in thing)
            {
                foreach (ButtonInfo b in WristMenu.settingsbuttons)
                {
                    if (b.buttonText == thing2)
                    {
                        b.enabled = true;
                    }
                }
            }
        }

        private static void PlatformsThing(bool invis, bool sticky)
        {
            colorKeysPlatformMonke[0].color = Color.red;
            colorKeysPlatformMonke[0].time = 0f;
            colorKeysPlatformMonke[1].color = Color.green;
            colorKeysPlatformMonke[1].time = 0.3f;
            colorKeysPlatformMonke[2].color = Color.blue;
            colorKeysPlatformMonke[2].time = 0.6f;
            colorKeysPlatformMonke[3].color = Color.red;
            colorKeysPlatformMonke[3].time = 1f;
            bool inputr;
            bool inputl;
                inputr = WristMenu.gripDownR;
                inputl = WristMenu.gripDownL;
            if (inputr)
            {
                if (!once_right && jump_right_local == null)
                {
                    if (sticky)
                    {
                        jump_right_local = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    }
                    else
                    {
                        jump_right_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    }
                    jump_right_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                    if (invis)
                    {
                        UnityEngine.Object.Destroy(jump_right_local.GetComponent<Renderer>());
                    }
                    jump_right_local.transform.localScale = scale;
                    jump_right_local.transform.position = new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                    jump_right_local.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
                    object[] eventContent = new object[2]
                    {
                    new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position,
                    GorillaLocomotion.Player.Instance.rightControllerTransform.rotation
                    };
                    RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                    {
                        Receivers = ReceiverGroup.Others
                    };
                    PhotonNetwork.RaiseEvent(70, eventContent, raiseEventOptions, SendOptions.SendReliable);
                    once_right = true;
                    once_right_false = false;
                    ColorChanger colorChanger = jump_right_local.AddComponent<ColorChanger>();
                    Gradient gradient = new Gradient();
                    gradient.colorKeys = colorKeysPlatformMonke;
                    colorChanger.colors = gradient;
                    colorChanger.Start();
                }
            }
            else if (!once_right_false && jump_right_local != null)
            {
                UnityEngine.Object.Destroy(jump_right_local);
                jump_right_local = null;
                once_right = false;
                once_right_false = true;
                RaiseEventOptions raiseEventOptions2 = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others
                };
                PhotonNetwork.RaiseEvent(72, null, raiseEventOptions2, SendOptions.SendReliable);
            }
            if (inputl)
            {
                if (!once_left && jump_left_local == null)
                {
                    if (sticky)
                    {
                        jump_left_local = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    }
                    else
                    {
                        jump_left_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    }
                    jump_left_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                    if (invis)
                    {
                        UnityEngine.Object.Destroy(jump_left_local.GetComponent<Renderer>());
                    }
                    jump_left_local.transform.localScale = scale;
                    jump_left_local.transform.position = new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.Player.Instance.leftControllerTransform.position;
                    jump_left_local.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
                    object[] eventContent2 = new object[2]
                    {
                    new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.Player.Instance.leftControllerTransform.position,
                    GorillaLocomotion.Player.Instance.leftControllerTransform.rotation
                    };
                    RaiseEventOptions raiseEventOptions3 = new RaiseEventOptions
                    {
                        Receivers = ReceiverGroup.Others
                    };
                    PhotonNetwork.RaiseEvent(69, eventContent2, raiseEventOptions3, SendOptions.SendReliable);
                    once_left = true;
                    once_left_false = false;
                    ColorChanger colorChanger2 = jump_left_local.AddComponent<ColorChanger>();
                    Gradient gradient2 = new Gradient();
                    gradient2.colorKeys = colorKeysPlatformMonke;
                    colorChanger2.colors = gradient2;
                    colorChanger2.Start();
                }
            }
            else if (!once_left_false && jump_left_local != null)
            {
                UnityEngine.Object.Destroy(jump_left_local);
                jump_left_local = null;
                once_left = false;
                once_left_false = true;
                RaiseEventOptions raiseEventOptions4 = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others
                };
                PhotonNetwork.RaiseEvent(71, null, raiseEventOptions4, SendOptions.SendReliable);
            }
            if (!PhotonNetwork.InRoom)
            {
                for (int i = 0; i < jump_right_network.Length; i++)
                {
                    UnityEngine.Object.Destroy(jump_right_network[i]);
                }
                for (int j = 0; j < jump_left_network.Length; j++)
                {
                    UnityEngine.Object.Destroy(jump_left_network[j]);
                }
            }
        }

        private static Vector3 scale = new Vector3(0.0125f, 0.28f, 0.3825f);

        private static bool once_left;

        private static bool once_right;

        private static bool once_left_false;

        private static bool once_right_false;

        private static bool once_networking;

        private static GameObject[] jump_left_network = new GameObject[9999];

        private static GameObject[] jump_right_network = new GameObject[9999];

        private static GameObject jump_left_local = null;

        private static GameObject jump_right_local = null;

        private static GradientColorKey[] colorKeysPlatformMonke = new GradientColorKey[4];

        private static Vector3? checkpointPos;

    }
}
