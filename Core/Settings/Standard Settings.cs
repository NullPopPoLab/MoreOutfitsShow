using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using KKAPI.Chara;
using KKAPI.Maker;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using UnityEngine;
#if TRACE
using System.Diagnostics;
#endif

namespace MoreOutfitsShow
{
    [BepInPlugin(GUID, "More Outfits Show", Version)]
    [BepInDependency(KKAPI.KoikatuAPI.GUID, KKAPI.KoikatuAPI.VersionConst)]
    public partial class Settings : BaseUnityPlugin
    {
        public const string GUID = "MoreOutfitsShow";
        public const string Version = "0.1";
        public static Settings Instance;
        internal static new ManualLogSource Logger { get; private set; }

        internal void StandardSettings()
        {
            Instance = this;
            Logger = base.Logger;
        }
    }
}