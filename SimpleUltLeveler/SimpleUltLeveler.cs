using System;
using LeagueSharp;
using LeagueSharp.Common;

namespace SimpleUltLeveler
{
    internal class SimpleUltLeveler
    {
        public SimpleUltLeveler()
        {
            CustomEvents.Game.OnGameLoad += OnGameLoad;
        }

        private void OnGameLoad(EventArgs args)
        {
           Game.PrintChat("<font color='#F7A100'>Simple Ult Leveler loaded.</font>");
           CustomEvents.Unit.OnLevelUp += OnLevelUp;
        }

        private void OnLevelUp(Obj_AI_Base sender, CustomEvents.Unit.OnLevelUpEventArgs args)
        {
            if (!sender.IsMe)
                return;

            ObjectManager.Player.Spellbook.LevelUpSpell(SpellSlot.R);
        }
    }
}