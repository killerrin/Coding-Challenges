using AdventOfCode2018.Challenges.Day1;
using Killerrin.Toolkit.CMD.Managers;
using System;

namespace AdventOfCode2018
{
    public class Program
    {
        static void Main(string[] args)
        {
            var navigationManager = NavigationManager.Instance;
            navigationManager.OnExit += NavigationManager_OnExit;

            navigationManager.Navigate(new MainMenu());
            var currentMenu = navigationManager.Peek();
            currentMenu.Run();
        }

        private static void NavigationManager_OnExit(object sender, object e)
        {
        }
    }
}
