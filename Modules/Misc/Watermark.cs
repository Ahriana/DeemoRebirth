using HarmonyLib;
using Il2CppMono;
using MelonLoader;
using System.Collections;
using UnityEngine;

namespace DeemoRebirth.Modules.Watermark {
    public static class Configuration {
        public static GUIStyle LabelStyle { get; set; }
    }

    internal class Methods {
        public static void DisableAssets () {
            GameObject gameObject = GameObject.Find("MainCameraController");
            Object.Destroy(gameObject.transform.GetChild(3).gameObject);
            Object.Destroy(gameObject.transform.GetChild(2).gameObject);
            Object.Destroy(gameObject.transform.GetChild(1).gameObject);
            Object.Destroy(gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject);
            Object.Destroy(GameObject.Find("Scene_Switch").gameObject);
        }
    }
    internal class Events {
        public static void OnApplicationStart () {
            Configuration.LabelStyle = new GUIStyle();
            Configuration.LabelStyle.fontSize = 18;
            Configuration.LabelStyle.normal.textColor = Color.white;
        }

        public static void OnGUI () {
            GUI.Label(new Rect(10, 10, 100, 25), $"Deemo Rebirth v{BuildInfo.Version}", Configuration.LabelStyle);
        }
    }
}
