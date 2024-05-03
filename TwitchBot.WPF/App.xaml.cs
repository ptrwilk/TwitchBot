using System;
using System.Collections.Generic;
using System.Windows;
using TwitchBot.Core;
using TwitchBot.WPF.Helpers;
using TwitchBot.WPF.Models;
using TwitchBot.WPF.Services;

namespace TwitchBot.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            ResultsService.Init();
        }
    }
}