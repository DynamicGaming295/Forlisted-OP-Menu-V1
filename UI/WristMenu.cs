using RigStuff;
using Uptime.Backend;
using Uptime.UI;
using Uptime.Utilities;
using ExitGames.Client.Photon;
using GorillaExtensions;
using HarmonyLib;
using Mono.CompilerServices.SymbolWriter;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Valve.VR;
using Valve.VR.InteractionSystem;
using static MonoMod.Cil.RuntimeILReferenceBag.FastDelegateInvokers;
using Object = UnityEngine.Object;
namespace Uptime.UI
{
    public class ButtonInfo
    {
        public string buttonText = "";
        public Action method = null;
        public Action disableMethod = null;
        public bool? enabled = false;
        public string toolTip = "";
        public bool IsToggle = true;
    }

    internal class WristMenu : MonoBehaviour
    {

        public static PhotonView rig2view(VRRig p)
        {
            return (PhotonView)Traverse.Create(p).Field("photonView").GetValue();
        }

        //settings
        public static List<ButtonInfo> settingsbuttons = new List<ButtonInfo>
        {
            new ButtonInfo { buttonText = "Back", method =() => Mods.Settings(), enabled = false},
            new ButtonInfo { buttonText = "Disconnect", method =() => Mods.Disconnect(), enabled = false},
            new ButtonInfo { buttonText = "Disconnect [RG]", method =() => Mods.TriggerDisconnectR(), enabled = false},
            new ButtonInfo { buttonText = "Disconnect [T]", method =() => Mods.TriggerDisconnect(), enabled = false},
            new ButtonInfo { buttonText = "Custom Boards", method =() => Mods.CustomBoards(), enabled = false},
            new ButtonInfo { buttonText = "Flush RPCs", method =() => Mods.RPCFlushermod(), enabled = false},
            new ButtonInfo { buttonText = "RPC Protection", method =() => Mods.SafetyRPCProtection(), enabled = false},
            new ButtonInfo { buttonText = "Anti-Report", method =() => Mods.AntiReportDisconnect(), enabled = false},
            new ButtonInfo { buttonText = "Anti-Ban", method =() => Mods.AntiBan(), enabled = false},
        };
        //norma

        public static List<ButtonInfo> buttons = new List<ButtonInfo>
        {
            new ButtonInfo { buttonText = "Saftey", method =() => Mods.Settings(), enabled = false},
            new ButtonInfo { buttonText = "Disconnect", method =() => Mods.Disconnect(), enabled = false},
            new ButtonInfo { buttonText = "Quit GTAG", method =() => Mods.QuitMod(), enabled = false},
            new ButtonInfo { buttonText = "Platforms", method =() => Mods.Platforms(), enabled = false},
            new ButtonInfo { buttonText = "Long Arms", method =() => Mods.LongArmsMod(), enabled = false},
            new ButtonInfo { buttonText = "Normal Arms", method =() => Mods.NormalArms(), enabled = false},
            new ButtonInfo { buttonText = "Fly", method =() => Mods.FlyMod(), enabled = false},
            new ButtonInfo { buttonText = "No clip fly", method =() => Mods.FlyNoclip(), enabled = false},
            new ButtonInfo { buttonText = "Left Hand Fly", method =() => Mods.LeftHandFly(), enabled = false},
            new ButtonInfo { buttonText = "Slow Fly", method =() => Mods.SlothFly(), enabled = false},
            new ButtonInfo { buttonText = "Fast Fly", method =() => Mods.FastFly(), enabled = false},
            new ButtonInfo { buttonText = "Tag All", method =() => Mods.TagAll(), enabled = false},
            new ButtonInfo { buttonText = "Tag All V2", method =() => Mods.TagAllV2(), enabled = false},
            new ButtonInfo { buttonText = "Tag Bot [RS]", method =() => Mods.TagBot(), enabled = false},
            new ButtonInfo { buttonText = "Tag Gun", method =() => Mods.taggunv2(), enabled = false},
            new ButtonInfo { buttonText = "Both Hand Tag Flick", method =() => Mods.BothHandFlickTag(), enabled = false},
            new ButtonInfo { buttonText = "Tp Gun", method =() => Mods.Tpgun(), enabled = false},
            new ButtonInfo { buttonText = "Lag All", method =() => Mods.LagAll(), enabled = false},
            new ButtonInfo { buttonText = "Ghost Monke", method =() => Mods.GhostMonkeMod(), enabled = false},
            new ButtonInfo { buttonText = "Invis Monke", method =() => Mods.InvisMonkeMod(), enabled = false},
            new ButtonInfo { buttonText = "Spaz Monke", method =() => Mods.spazmonk(), enabled = false},
            new ButtonInfo { buttonText = "Spin Head Z", method =() => Mods.SpinHeadZ(), enabled = false},
            new ButtonInfo { buttonText = "Spin Head Y", method =() => Mods.SpinHeadY(), enabled = false},
            new ButtonInfo { buttonText = "Spin Head X", method =() => Mods.SpinHeadX(), enabled = false},
            new ButtonInfo { buttonText = "No Tap Cool Down", method =() => Mods.NoTapCoolDown(), enabled = false},
            new ButtonInfo { buttonText = "Iron Monke", method =() => Mods.IronMan(), enabled = false},
            new ButtonInfo { buttonText = "Grab Bug", method =() => Mods.GrabBug(), enabled = false},
            new ButtonInfo { buttonText = "Big Bug", method =() => Mods.BigBug(), enabled = false},
            new ButtonInfo { buttonText = "Small Bug", method =() => Mods.SmallBug(), enabled = false},
            new ButtonInfo { buttonText = "Big Bug", method =() => Mods.FixBug(), enabled = false},
            new ButtonInfo { buttonText = "Freeze Bug", method =() => Mods.freezebug(), enabled = false},
            new ButtonInfo { buttonText = "Orbit Bug", method =() => Mods.OrbitBug(), enabled = false},
            new ButtonInfo { buttonText = "Canyons Rope Control", method =() => Mods.CanyonsRopeControl(), enabled = false},
            new ButtonInfo { buttonText = "Set Name to R U N", method =() => Mods.Name5(), enabled = false},
            new ButtonInfo { buttonText = "Set Name to DYNAMIC", method =() => Mods.Name1(), enabled = false},
            new ButtonInfo { buttonText = "Make Gamemode Casual [LG]", method =() => Mods.CasualGamemode(), enabled = false},
            new ButtonInfo { buttonText = "Make Gamemode Infection [LG]", method =() => Mods.InfectionGamemode(), enabled = false},
            new ButtonInfo { buttonText = "Make Gamemode Hunt [LG]", method =() => Mods.HuntGamemode(), enabled = false},
            new ButtonInfo { buttonText = "Make Gamemode Battle [LG]", method =() => Mods.BattleGamemode(), enabled = false},
        };

        public static bool ChangingColors = true;
        public static Color FirstColor = Color.black;
        public static Color SecondColor = ((Color.white + Color.black) / 2);
        public static Color purple = new Color32(125,0,125,0); 

        public static Color NormalColor = Color.white;

        public static Color ButtonColorDisable = Color.black;
        public static Color ButtonColorEnabled = Color.black;
        public static Color ButtonTextColorDisabled = Color.white;
        public static Color ButtonTextColorEnabled = Color.green;

        public static string MenuTitle = "Forlisted Op Menu By DynamicGaming295"; // Made by DynamicGaming295 with love!


        //fuck ton of vars holy shit
        private static int lastPressedButtonIndex = -1;
        public static GameObject menu = null;
        private static GameObject canvasObj = null;
        private static GameObject reference = null;
        private static int pageSize = 6;
        private static int pageNumber = 0;
        public static bool gripDownR;
        public static bool triggerDownR;
        public static bool abuttonDown;
        public static bool bbuttonDown;
        public static bool xbuttonDown;
        public static bool ybuttonDown;
        public static bool gripDownL;
        public static bool triggerDownL;
        public static bool joystickR;
        public static bool joystickL;
        public static Vector2 joystickaxisR;
        public static WristMenu instance = new WristMenu();
        public static GameObject menuObj;
        public static Color colorToFade1 = Color.black;
        public static int selectedButton = 1;
        public static Color colorToFade2 = Color.magenta;
        private static Text tooltipText;
        private static string tooltipString;
        public static bool toggle = false;
        public static bool toggle1 = false;
        public static bool toggle2 = false;
        public static bool toggle3 = false;
        public static bool toggle4 = false;
        public static List<Photon.Realtime.Player> adminList = new List<Photon.Realtime.Player>();
        public static bool hasPanel = false;

        public static string CheckSelectedButton()
        {
            string[] buttonss = buttons.Skip(pageNumber * pageSize).Take(pageSize).Select(button => button.buttonText).ToArray();
            string[] settingsbuttonss = settingsbuttons.Skip(pageNumber * pageSize).Take(pageSize).Select(button => button.buttonText).ToArray();
            if (selectedButton == 1)
            {
                return buttonss[1];
            }
            if (selectedButton == 2)
            {
                return buttonss[2];
            }
            if (selectedButton == 3)
            {
                return buttonss[3];
            }
            if (selectedButton == 4)
            {
                return buttonss[4];
            }
            if (selectedButton == 5)
            {
                return buttonss[5];
            }
            if (selectedButton == 6)
            {
                return buttonss[6];
            }
            return null;
        }

        static bool fun = false;
        public static bool rightcooldown = false;
        public static bool leftcooldown = false;
        public static void CheckPageChange()
        {
            if (triggerDownR)
            {
                if (!rightcooldown)
                {
                    Toggle("NextPage");
                    rightcooldown = true;
                }
            }
            else
            {
                if (rightcooldown)
                {
                    rightcooldown = false;
                }
            }
            if (triggerDownL)
            {
                if (!leftcooldown)
                {
                    Toggle("PreviousPage");
                    leftcooldown = true;
                }
            }
            else
            {
                if (leftcooldown)
                {
                    leftcooldown = false;
                }
            }
        }
        void Update()
        {

            try
            {
                gripDownL = ControllerInputPoller.instance.leftGrab;
                gripDownR = ControllerInputPoller.instance.rightGrab;
                triggerDownL = ControllerInputPoller.instance.leftControllerIndexFloat == 1f;
                triggerDownR = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
                abuttonDown = ControllerInputPoller.instance.rightControllerPrimaryButton;
                bbuttonDown = ControllerInputPoller.instance.rightControllerSecondaryButton;
                xbuttonDown = ControllerInputPoller.instance.leftControllerPrimaryButton;
                ybuttonDown = ControllerInputPoller.instance.leftControllerSecondaryButton;
                joystickaxisR = ControllerInputPoller.instance.rightControllerPrimary2DAxis;
                if (ybuttonDown)
                {
                    if (menu == null)
                    {
                        instance.Draw();
                    }
                    else
                    {
                        UpdateColor();
                        CheckPageChange();
                        menu.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position;
                        menu.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
                        if (reference == null)
                        {
                            reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            reference.name = "buttonPresser";
                        }
                        reference.transform.parent = GorillaLocomotion.Player.Instance.rightControllerTransform;
                        reference.transform.localPosition = new Vector3(0f, -0.1f, 0f) * GorillaLocomotion.Player.Instance.scale;
                        reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f) * GorillaLocomotion.Player.Instance.scale;
                    }
                }
                else if (ybuttonDown == false && menu != null)
                {
                    Rigidbody comp = menu.AddComponent(typeof(Rigidbody)) as Rigidbody;
                    comp.velocity = GorillaLocomotion.Player.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                    UnityEngine.Object.Destroy(menu, 2);
                    Object.Destroy(reference);
                    reference = null;
                    menu = null;
                }

                foreach (ButtonInfo buttonInfo in settingsbuttons)
                {
                    if (buttonInfo.method == null) continue;

                    if (buttonInfo.enabled == true)
                    {
                        buttonInfo.method.Invoke();
                        if (!buttonInfo.IsToggle)
                        {
                            buttonInfo.enabled = false;
                            DestroyMenu();
                        }
                    }
                    if (buttonInfo.enabled == false && buttonInfo.disableMethod != null)
                    {
                        buttonInfo.disableMethod.Invoke();
                    }
                }
                foreach (ButtonInfo buttonInfo in buttons)
                {
                    if (buttonInfo.method == null) continue;

                    if (buttonInfo.enabled == true)
                    {
                        buttonInfo.method.Invoke();
                        if (!buttonInfo.IsToggle)
                        {
                            buttonInfo.enabled = false;
                            DestroyMenu();
                        }
                    }
                    if (buttonInfo.enabled == false && buttonInfo.disableMethod != null)
                    {
                        buttonInfo.disableMethod.Invoke();
                    }
                }
            }
            catch { }
        }

        bool sentbefore = false;

        private static string GetButtonTooltip(int index)
        {
            if (Mods.inSettings)
            {
                ButtonInfo buttonInfo = settingsbuttons[index];
                return $"{buttonInfo.buttonText}: {buttonInfo.toolTip}";
            }
            else
            {
                ButtonInfo buttonInfo = buttons[index];
                return $"{buttonInfo.buttonText}: {buttonInfo.toolTip}";
            }
        }

        public void Draw()
        {
            menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Object.Destroy(menu.GetComponent<Rigidbody>());
            Object.Destroy(menu.GetComponent<BoxCollider>());
            Object.Destroy(menu.GetComponent<Renderer>());
            menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.4f) * 1f;
            menuObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Object.Destroy(menuObj.GetComponent<Rigidbody>());
            Object.Destroy(menuObj.GetComponent<BoxCollider>());
            menuObj.transform.parent = menu.transform;
            menuObj.transform.rotation = Quaternion.identity;
            menuObj.transform.localScale = new Vector3(0.1f, 0.95f, 1f) * 1f;
            menuObj.transform.position = new Vector3(0.05f, 0f, 0f) * 1f;
            canvasObj = new GameObject();
            canvasObj.transform.parent = menu.transform;
            Canvas canvas = canvasObj.AddComponent<Canvas>();
            CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
            canvasObj.AddComponent<GraphicRaycaster>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvasScaler.dynamicPixelsPerUnit = 1000f;
            Text text = new GameObject
            {
                transform =
                {
                    parent = canvasObj.transform
                }
            }.AddComponent<Text>();
            text.gameObject.name = "name";
            titiel = text;
            text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            int yau = pageNumber + 1;
            text.text = MenuTitle;
            text.fontSize = 1;
            text.alignment = TextAnchor.MiddleCenter;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.28f, 0.05f);
            component.position = new Vector3(0.06f, 0f, 0.175f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            string[] array2 = buttons.Skip(pageNumber * pageSize).Take(pageSize).Select(button => button.buttonText).ToArray();
            string[] array3 = settingsbuttons.Skip(pageNumber * pageSize).Take(pageSize).Select(button => button.buttonText).ToArray();
            if (Mods.inSettings)
            {
                for (int i = 0; i < array3.Length; i++)
                {
                    AddButton((float)i * 0.13f + 0.26f * 1f, array3[i]);
                }
            }
            else
            {
                for (int i = 0; i < array2.Length; i++)
                {
                    AddButton((float)i * 0.13f + 0.26f * 1f, array2[i]);
                }
            }
            GameObject tooltipObj = new GameObject();
            tooltipObj.transform.SetParent(canvasObj.transform);
            tooltipObj.transform.localPosition = new Vector3(0, 0, 1) * 1f;

            tooltipText = tooltipObj.GetComponent<Text>();
            if (tooltipText == null)
                tooltipText = tooltipObj.AddComponent<Text>();
            tooltipText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            tooltipText.text = "";
            tooltipText.fontSize = 20;
            tooltipText.alignment = TextAnchor.MiddleCenter;
            tooltipText.resizeTextForBestFit = true;
            tooltipText.resizeTextMinSize = 0;

            RectTransform componenttooltip = tooltipObj.GetComponent<RectTransform>();
            componenttooltip.localPosition = Vector3.zero;
            componenttooltip.sizeDelta = new Vector2(0.2f, 0.03f) * 1f;
            componenttooltip.position = new Vector3(0.06f, 0f, -0.18f) * 1f;
            componenttooltip.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        }

        public static Text titiel;

        public static void DisableButton(string buttonText)
        {
            if (Mods.inSettings)
            {
                foreach (ButtonInfo btninfo in settingsbuttons)
                {
                    if (btninfo.buttonText == buttonText)
                    {
                        btninfo.enabled = false;
                        instance.Draw();
                    }
                }
            }
            else
            {
                foreach (ButtonInfo btninfo in buttons)
                {
                    if (btninfo.buttonText == buttonText)
                    {
                        btninfo.enabled = false;
                        instance.Draw();
                    }
                }
            }
        }
        private static void AddPageButtons()
        {
            int num = (buttons.Count + pageSize - 1) / pageSize;
            int num2 = pageNumber + 1;
            int num3 = pageNumber - 1;
            if (num2 > num - 1)
            {
                num2 = 0;
            }
            if (num3 < 0)
            {
                num3 = num - 1;
            }
            float num4 = 0f;
            GameObject gameObject = GameObject.CreatePrimitive((PrimitiveType)3);
            Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.09f, 0.8f, 0.08f) * GorillaLocomotion.Player.Instance.scale;
            gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.28f - num4) * GorillaLocomotion.Player.Instance.scale;
            gameObject.AddComponent<BtnCollider>().relatedText = "PreviousPage";
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.grey);
            GradientColorKey[] array = new GradientColorKey[3];
            array[0].color = new Color32(50, 50, 50, 255);
            array[0].time = 0f;
            array[1].color = new Color32(90, 90, 90, 255);
            array[1].time = 0.5f;
            array[2].color = new Color32(50, 50, 50, 255);
            array[2].time = 1f;
            ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
            colorChanger.colors = new Gradient
            {
                colorKeys = array
            };
            colorChanger.Start();
            Text text = new GameObject
            {
                transform =
                {
                    parent = canvasObj.transform
                }
            }.AddComponent<Text>();
            
        }
            public static void DestroyMenu()
        {
            Object.Destroy(menu);
            Object.Destroy(canvasObj);
            Object.Destroy(reference);
            menu = null;
            menuObj = null;
            canvasObj = null;
            reference = null;
        }
        public static Color MenuUpdateColor = Color.Lerp(WristMenu.FirstColor, WristMenu.SecondColor, Mathf.PingPong(Time.time, 1f));
        public static void UpdateColor()
        {
            if (ChangingColors)
            {
                menuObj.GetComponent<Renderer>().material.color = MenuUpdateColor;
                MenuUpdateColor = Color.Lerp(WristMenu.FirstColor, WristMenu.SecondColor, Mathf.PingPong(Time.time, 1f));
            }
            else
            {
                menuObj.GetComponent<Renderer>().material.color = NormalColor;
            }
        }
        private static void AddButton(float offset, string text)
        {
            GameObject gameObject = GameObject.CreatePrimitive((PrimitiveType)3);
            Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.09f, 0.8f, 0.08f) * 1f;
            gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.55f - offset);
            gameObject.AddComponent<BtnCollider>().relatedText = text;
            int num = -1;
            if (Mods.inSettings)
            {
                for (int i = 0; i < settingsbuttons.Count; i++)
                {
                    bool flag = text == settingsbuttons[i].buttonText;
                    if (flag)
                    {
                        num = i;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < buttons.Count; i++)
                {
                    bool flag = text == buttons[i].buttonText;
                    if (flag)
                    {
                        num = i;
                        break;
                    }
                }
            }
            Text text2 = new GameObject
            {
                transform =
                {
                    parent = canvasObj.transform
                }
            }.AddComponent<Text>();
            text2.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            text2.text = text;
            text2.fontSize = 1;
            text2.alignment = TextAnchor.MiddleCenter;
            text2.resizeTextForBestFit = true;
            text2.resizeTextMinSize = 0;
            RectTransform component = text2.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.2f, 0.03f) * 1f;
            component.localPosition = new Vector3(0.064f, 0f, 0.215f - offset / 2.55f) * 1f;
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            if (Mods.inSettings)
            {
                if (settingsbuttons[num].enabled == true)
                {
                    gameObject.GetComponent<Renderer>().material.color = ButtonColorEnabled;
                    text2.color = ButtonTextColorEnabled;
                }
                else
                {
                    gameObject.GetComponent<Renderer>().material.color = ButtonColorDisable;
                    text2.color = ButtonTextColorDisabled;
                }
            }
            else
            {
                if (buttons[num].enabled == true)
                {
                    gameObject.GetComponent<Renderer>().material.color = ButtonColorEnabled;
                    text2.color = ButtonTextColorEnabled;
                }
                else
                {
                    gameObject.GetComponent<Renderer>().material.color = ButtonColorDisable;
                    text2.color = ButtonTextColorDisabled;
                }
            }
        }
        public static bool IsButtonToggled(string relatedText)
        {
            if (Mods.inSettings)
            {
                int num = -1;
                for (int i = 0; i < settingsbuttons.Count; i++)
                {
                    if (relatedText == settingsbuttons[i].buttonText)
                    {
                        num = i;
                        break;
                    }
                }

                if (settingsbuttons[num].enabled != null)
                {
                    return (bool)settingsbuttons[num].enabled;
                }
                return false;
            }
            else
            {
                int num = -1;
                for (int i = 0; i < buttons.Count; i++)
                {
                    if (relatedText == buttons[i].buttonText)
                    {
                        num = i;
                        break;
                    }
                }

                if (buttons[num].enabled != null)
                {
                    return (bool)buttons[num].enabled;
                }
                return false;
            }
        }

        

        public void Start()
        {
            Draw();
        }

        public static void Toggle(string relatedText)
        {
            
            if (Mods.inSettings)
            {
                int num = (settingsbuttons.Count + pageSize - 1) / pageSize;
                if (relatedText == "NextPage")
                {
                    if (pageNumber < num - 1)
                    {
                        pageNumber++;
                    }
                    else
                    {
                        pageNumber = 0;
                    }
                    DestroyMenu();
                    instance.Draw();
                }
                else
                {
                    if (relatedText == "PreviousPage")
                    {
                        if (pageNumber > 0)
                        {
                            pageNumber--;
                        }
                        else
                        {
                            pageNumber = num - 1;
                        }
                        DestroyMenu();
                        instance.Draw();
                    }
                    else
                    {
                        if (relatedText == "DisconnectingButton")
                        {
                            PhotonNetwork.Disconnect();
                            GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
                        }
                        else
                        {
                            int num2 = -1;
                            for (int i = 0; i < settingsbuttons.Count; i++)
                            {
                                if (relatedText == settingsbuttons[i].buttonText)
                                {
                                    num2 = i;
                                    break;
                                }
                            }
                            if (settingsbuttons[num2].enabled != null)
                            {
                                settingsbuttons[num2].enabled = !settingsbuttons[num2].enabled;
                                lastPressedButtonIndex = num2;
                                if (lastPressedButtonIndex != -1 && lastPressedButtonIndex < settingsbuttons.Count)
                                {
                                    tooltipString = GetButtonTooltip(lastPressedButtonIndex);
                                    tooltipText.text = tooltipString;
                                    lastPressedButtonIndex = -1;
                                }
                                DestroyMenu();
                                instance.Draw();
                            }
                        }
                    }
                }
            }
            else
            {
                int num = (buttons.Count + pageSize - 1) / pageSize;
                if (relatedText == "NextPage")
                {
                    if (pageNumber < num - 1)
                    {
                        pageNumber++;
                    }
                    else
                    {
                        pageNumber = 0;
                    }
                    DestroyMenu();
                    instance.Draw();
                }
                else
                {
                    if (relatedText == "PreviousPage")
                    {
                        if (pageNumber > 0)
                        {
                            pageNumber--;
                        }
                        else
                        {
                            pageNumber = num - 1;
                        }
                        DestroyMenu();
                        instance.Draw();
                    }
                    else
                    {
                        if (relatedText == "DisconnectingButton")
                        {
                            PhotonNetwork.Disconnect();
                            GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
                        }

                        else
                        {
                            int num2 = -1;
                            for (int i = 0; i < buttons.Count; i++)
                            {
                                if (relatedText == buttons[i].buttonText)
                                {
                                    num2 = i;
                                    break;
                                }
                            }
                            if (buttons[num2].enabled != null)
                            {
                                buttons[num2].enabled = !buttons[num2].enabled;
                                lastPressedButtonIndex = num2;
                                if (lastPressedButtonIndex != -1 && lastPressedButtonIndex < buttons.Count)
                                {
                                    tooltipString = GetButtonTooltip(lastPressedButtonIndex);
                                    tooltipText.text = tooltipString;
                                    lastPressedButtonIndex = -1;
                                }
                                DestroyMenu();
                                instance.Draw();
                            }
                        }
                    }
                }
            }
        }
    }
}

internal class BtnCollider : MonoBehaviour
{
    public static int framePressCooldown = 0;
    private void OnTriggerEnter(Collider collider)
    {
        if (Time.frameCount >= framePressCooldown + 20 && collider.name == "buttonPresser")
        {
            GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.1f);
            GorillaTagger.Instance.StartVibration(false, 0.5f, 0.01f);
            WristMenu.Toggle(this.relatedText);
            framePressCooldown = Time.frameCount;
        }
    }

    public string relatedText;
}