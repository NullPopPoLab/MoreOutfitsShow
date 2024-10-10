using BepInEx;
using BepInEx.Configuration;
using KKAPI.Studio;

namespace MoreOutfitsShow
{
    [BepInProcess("KoikatsuSunshine")]
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