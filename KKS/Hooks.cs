using ActionGame;
using ActionGame.Chara;
using HarmonyLib;
using Illusion.Extensions;
using Manager;
using System;
using System.Reflection;

namespace MoreOutfitsShow
{
    internal static class Hooks
    {
        public static void Init()
        {
            Harmony.CreateAndPatchAll(typeof(Hooks));
            Harmony.CreateAndPatchAll(typeof(SetNextOutfitAtMove));
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(WaitPoint), nameof(WaitPoint.SetWait))]
        internal static void ChangeOutfitAtWaitPoint(WaitPoint __instance)
        {
            try
            {
                var Chara = (Base)Traverse.Create(__instance).Property("chara").GetValue();
                if (Chara != null){
//                    var didx = Chara.heroine.isDresses.Check(false);
//                    if (didx < 0) didx = 0;
                    var ofc = Chara.chaCtrl.chaFile.coordinate.Length;
                    Chara.heroine.coordinates = ofc - 1;
                }
            }
            catch (Exception ex)
            {
                Settings.Logger.LogError("ChangeOutfitAtWaitPoint fail - " + ex);
            }
        }

        [HarmonyPatch]
        static class SetNextOutfitAtMove
        {
            public static MethodBase TargetMethod() => AccessTools.Method(AccessTools.TypeByName("ActionGame.ActionControl+DesireInfo, Assembly-CSharp"), "SetWaitPoint");//Assembly Name because it hates me now that I didn't want to use it
            internal static void Postfix(WaitPoint wp, NPC _npc)
            {
                try
                {
                    if (_npc != null)
                    {
//                        var didx = _npc.heroine.isDresses.Check(false);
//                        if (didx < 0) didx = 0;
                        var ofc = _npc.chaCtrl.chaFile.coordinate.Length;
                        _npc.heroine.coordinates = ofc-1;
                    }
                }
                catch (Exception ex)
                {

                    Settings.Logger.LogError("SetWaitPoint fail - " + ex);
                }
            }
        }
    }
}
