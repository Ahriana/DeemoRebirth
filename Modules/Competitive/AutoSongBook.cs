using HarmonyLib;
using MelonLoader;
using System.Collections;
using UnityEngine;

namespace DeemoRebirth.Modules.AutoSongBook {
    public static class Configuration {
        public static bool BookOpened { get; set; } = false;
    }

    [HarmonyPatch(typeof(PlayerInput), "OnInputEnable")]
    internal class PlayerInput_OnInputEnable {
        private static void Postfix (PlayerInput __instance) {
            if (!Config.Competitive.AutoSongBook) { return; }

            if (Configuration.BookOpened) { return; }
            Configuration.BookOpened = true;
            MelonCoroutines.Start(Methods.WaitToJump());
        }
    }

    internal class Methods {
        public static void JumpIntoSongSelect () {
            SongSelectBookUI component = GameObject.Find("StaticCanvas (TV)").transform.Find("SongSelectBookUI").gameObject.GetComponent<SongSelectBookUI>();
            component.ShowUI();
            // component.SetHardDifficulty();
        }

        public static IEnumerator WaitToJump () {
            yield return (object)new WaitForSecondsRealtime(1f);
            JumpIntoSongSelect();
        }
    }
}
