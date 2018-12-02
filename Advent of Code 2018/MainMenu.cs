using AdventOfCode2018.Challenges.Day1;
using Killerrin.Toolkit.CMD.Menus;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018
{
    public class MainMenu : Menu
    {
        public MainMenu() : base("Main Menu")
        {
            AddMenuItem(new SeparatorMenuItem("", '-'));
            AddMenuItem(new Day1Menu());
        }

        public override void Run()
        {
            RunDefaultLoop();
        }
    }
}
