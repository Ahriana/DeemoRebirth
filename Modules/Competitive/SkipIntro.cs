using MelonLoader;
using HarmonyLib;

namespace DeemoRebirth.Modules.SkipIntro {
    [HarmonyPatch(typeof(SystemMessageUI), "ShowUI")]
    internal class SystemMessageUI_ShowUI {
        private static void Postfix (SystemMessageUI __instance) {
            if (!Config.Competitive.SkipIntro) { return; }

            MelonLogger.Msg($"SystemMessageUI ShowUI: {__instance.currUID}");
            if (__instance.currUID == 1)
                __instance.OnClickButton(0);
            if (__instance.currUID != 2)
                return;
            __instance.OnClickButton(1);
        }
    }

    [HarmonyPatch(typeof(TitleUI), "ShowUI")]
    internal class TitleUI_ShowTitle {
        private static void Postfix (TitleUI __instance) {
            if (!Config.Competitive.SkipIntro) { return; }

            MelonLogger.Msg("TitleUI ShowUI");
            __instance.fadeAnimator.speed = 1000f;
            __instance.ShowLoadGameUI();
        }
    }

    [HarmonyPatch(typeof(TitleUI), "SetupUI")]
    internal class TitleUI_SetupUI {
        private static void Prefix (ref TitleUI.TitleUISettings settings, ref bool fade) {
            if (!Config.Competitive.SkipIntro) { return; }

            MelonLogger.Msg("TitleUI SetupUI");
            fade = false;
        }
    }
}
