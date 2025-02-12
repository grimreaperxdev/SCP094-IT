using System.Collections.Generic;
using Exiled.CustomItems.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.API.Enums;
using UnityEngine;
using Exiled.API.Features;


namespace CustomItems1.SCP094IT
{
    public class Class1 : Plugin<CustomItem1Config>
    {
        public static Class1 Instance;

        public override void OnEnabled()
        {
            Instance = this;

            Exiled.CustomItems.API.Features.CustomItem.RegisterItems();
            Exiled.CustomRoles.API.Features.CustomRole.RegisterRoles(false, null);

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;

            Exiled.CustomItems.API.Features.CustomItem.UnregisterItems();
            Exiled.CustomRoles.API.Features.CustomRole.UnregisterRoles();

            base.OnDisabled();
        }
    }
    namespace CustomItems1.SCP094IT
{

    [CustomItem(ItemType.Adrenaline)]
    public class CustomItem1 : CustomItem
    {
        public override ItemType Type { get; set; } = ItemType.Adrenaline;
        public override uint Id { get; set; } = 1;

        public override string Name { get; set; } = "SCP 094 IT";

        public override string Description { get; set; } = "SCP-094-IT è un'entità anomala che causa la perdita della memoria a " +
            "breve termine e altera la percezione del tempo, rendendo difficili le interazioni con la realtà.";

        public override float Weight { get; set; } = 1f;

        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            DynamicSpawnPoints = new List<DynamicSpawnPoint>()
            {
                new DynamicSpawnPoint()
                {
                        Location = SpawnLocationType.Inside173Gate,
                        Chance = 100
                }
            }
        };

        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsingItem += OnUsingItem;
            Exiled.Events.Handlers.Map.PickupAdded += OnPickupAdded;
            Exiled.Events.Handlers.Player.PickingUpItem += OnPickingUpItem;
            Exiled.Events.Handlers.Player.ChangingItem += OnChangingItem;
            base.SubscribeEvents();
        }
        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsingItem -= OnUsingItem;
            Exiled.Events.Handlers.Map.PickupAdded -= OnPickupAdded;
            Exiled.Events.Handlers.Player.PickingUpItem -= OnPickingUpItem;
            Exiled.Events.Handlers.Player.ChangingItem -= OnChangingItem;
            base.UnsubscribeEvents();
        }
        private void OnUsingItem(Exiled.Events.EventArgs.Player.UsingItemEventArgs ev)
        {
            if (ev.Player.CurrentItem == null || ev.Player.CurrentItem.Type != ItemType.Adrenaline)
                return;

            int chance = Random.Range(0, 100);

            switch (chance) 
            {
                case int n when (n < 10):
                    ev.Player.EnableEffect(EffectType.Burned);
                     break;
                case int n when (n < 20):
                    ev.Player.EnableEffect(EffectType.CardiacArrest);
                     break;
                case int n when (n < 30):
                    ev.Player.EnableEffect(EffectType.Hypothermia);
                     break;
                case int n when (n < 40):
                    ev.Player.EnableEffect(EffectType.Invisible);
                    break;
                case int n when (n < 50):
                    ev.Player.EnableEffect(EffectType.SilentWalk);
                    break;
                case int n when (n < 60):
                    ev.Player.EnableEffect(EffectType.AmnesiaItems);
                    break;
                case int n when (n < 70):
                    ev.Player.EnableEffect(EffectType.BodyshotReduction);
                    break;
                case int n when (n < 80):
                    ev.Player.EnableEffect(EffectType.Corroding);
                    break;
                case int n when (n < 90):
                    ev.Player.EnableEffect(EffectType.Traumatized);
                    break;
                default:
                    ev.Player.EnableEffect(EffectType.Hemorrhage);
                    break;


            }
        }

        private void OnPickingUpItem(Exiled.Events.EventArgs.Player.PickingUpItemEventArgs ev)
        {
        }

        private void OnPickupAdded(Exiled.Events.EventArgs.Map.PickupAddedEventArgs ev)
        {
        }

        private void OnChangingItem(Exiled.Events.EventArgs.Player.ChangingItemEventArgs ev)
        {
        }
    }
}
}