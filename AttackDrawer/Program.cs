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
        private static Menu _menu;

        private static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            _menu = new Menu("AttackDrawer", "Attack Drawer", true);
            _menu.AddItem(new MenuItem("Draw", "Draw Enemy Range").SetValue(new Circle(true, Color.FromArgb(150, Color.DodgerBlue))));
            _menu.AddToMainMenu();
            
            Drawing.OnDraw += Drawing_OnDraw;
            Game.PrintChat("Attack Range Loaded!");
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
             foreach (var hero in ObjectManager.Get<Obj_AI_Hero>().Where(hero => hero.IsEnemy))
             {
                 if (_menu.Item("Draw").GetValue<Circle>().Active)
                     Utility.DrawCircle(hero.Position, hero.AttackRange, _menu.Item("Draw").GetValue<Circle>().Color, 4, 30, false);
             }
        }

    }
}