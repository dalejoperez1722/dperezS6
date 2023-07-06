﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using dperezS5.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(MensajeAndroid))]
namespace dperezS5.Droid
{
    internal class MensajeAndroid : Mensaje
    {
        public void LongAlert(string mensaje)
        {
            Toast.MakeText(Application.Context,mensaje,ToastLength.Long).Show();
        }

        public void ShortAlert(string mensaje)
        {
            Toast.MakeText(Application.Context,mensaje, ToastLength.Short).Show();
        }
    }
}