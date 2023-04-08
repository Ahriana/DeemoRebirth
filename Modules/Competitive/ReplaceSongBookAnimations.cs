using HarmonyLib;

namespace DeemoRebirth.Modules.ReplaceSongBookAnimations {
    [HarmonyPatch(typeof(SongSelectBookUI), "ShowUI")]
    internal class SongSelectBookUI_ShowUI {
        private static void Postfix (SongSelectBookUI __instance) {
            if (!Config.Competitive.ReplaceSongBookAnimations) { return; }

            // check for nulls since this animation is not always used
            if (__instance.enterBookListAnimator != null) { __instance.enterBookListAnimator.speed = 10f; }
            if (__instance.enterSongListAnimator != null) { __instance.enterSongListAnimator.speed = 10f; }

            // Song select SPEEEEEEEEED
            __instance.maxTime_FPS = 0.15f;

            __instance.songPageTurning.animator.speed = 4f;
            __instance.songSelectAnimator.speed = 4f;

            __instance.songStore.animator.speed = 4f;
            __instance.songSelectText.animator.speed = 4f;
            __instance.songSelectArrowL.animator.speed = 4f;
            __instance.songSelectArrowR.animator.speed = 4f;
            __instance.songSettingInfo.animator.speed = 4f;
            __instance.difficultyEasy.animator.speed = 4f;
            __instance.difficultyNormal.animator.speed = 4f;
            __instance.difficultyHard.animator.speed = 4f;
            __instance.customizeSpeedL.animator.speed = 4f;
            __instance.customizeSpeedR.animator.speed = 4f;
            __instance.customizeKeyL.animator.speed = 4f;
            __instance.customizeKeyR.animator.speed = 4f;
            __instance.customizeSkinL.animator.speed = 4f;
            __instance.customizeSkinR.animator.speed = 4f;
            __instance.customizeWindow.animator.speed = 4f;
        }
    }
}
