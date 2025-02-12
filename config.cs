using Exiled.API.Interfaces;
using System.Collections.Generic;
using Exiled.API.Enums;

namespace CustomItems1.SCP094IT
{
    public class CustomItem1Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public string UseMessage { get; set; } = "Ti senti un po' strano...";
        public Dictionary<EffectType, int> EffectChances { get; set; } = new Dictionary<EffectType, int>
        {
            { EffectType.Burned, 10 },
            { EffectType.CardiacArrest, 10 },
            { EffectType.Hypothermia, 10 },
            { EffectType.Invisible, 10 },
            { EffectType.SilentWalk, 10 },
            { EffectType.AmnesiaItems, 10 },
            { EffectType.BodyshotReduction, 10 },
            { EffectType.Corroding, 10 },
            { EffectType.Traumatized, 10 },
            { EffectType.Hemorrhage, 10 }
        };
        public List<EffectType> DisabledEffects { get; set; } = new List<EffectType>();
    }
}
