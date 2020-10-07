using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using AutorisationTravail.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer (typeof(Entry), typeof(ClearEntryLine))]
namespace AutorisationTravail.Droid.Renderers
{
    class ClearEntryLine : EntryRenderer
    {
        public ClearEntryLine(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                if (Control != null)
                {
                    Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
                }
            }
        }
    }
}