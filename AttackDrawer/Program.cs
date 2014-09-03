#region

using System;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;
//using SharpDX;
using Color = System.Drawing.Color;

#endregion

namespace AttackDrawer
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            
            Drawing.OnDraw += Drawing_OnDraw;
            Game.PrintChat("Attack Range Loaded!");
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
             foreach (var hero in ObjectManager.Get<Obj_AI_Hero>().Where(hero => hero.IsEnemy && hero.IsVisible && !hero.IsDead))
             {
                Utility.DrawCircle(hero.Position, Orbwalking.GetRealAutoAttackRange(hero), ObjectManager.Player.Distance(hero) < Orbwalking.GetRealAutoAttackRange(hero) ? Color.Red : Color.LimeGreen, 4, 30, false);
             }
        }

    }
}