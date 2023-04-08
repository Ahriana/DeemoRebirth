using HarmonyLib;
using Il2CppMono;
using MelonLoader;
using System.Collections;
using UnityEngine;

namespace DeemoRebirth.Modules.RemoveGameplayBackgrounds {
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
        public static void OnSceneWasInitialized (int buildindex, string sceneName) {
            if (!Config.Performance.RemoveGameplayBackgrounds) { return; }
            if (!(sceneName == "RhythmStage")) { return; }
            Methods.DisableAssets();
        }
    }
}
