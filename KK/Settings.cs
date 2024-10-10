using BepInEx;
using BepInEx.Configuration;
using KKAPI.MainGame;
using KKAPI.Studio;
using System.Collections.Generic;

namespace MoreOutfitsShow
{
    [BepInProcess("Koikatu")]
    [BepInProcess("KoikatuVR")]
    [BepInProcess("Koikatsu Party")]
    [BepInProcess("Koikatsu Party VR")]
    public partial class Settings : BaseUnityPlugin
    {

        public void Awake()
        {
            if (StudioAPI.InsideStudio)
            {
                return;
            }
            Hooks.Init();
        }
    }
}