﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace animatedGifRendering
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LocalImages();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}