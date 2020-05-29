using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Visual.Droid.VisualComponents;
using Visual.VisualComponents;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace Visual.Droid.VisualComponents
{
    public class CustomEntryRenderer : EntryRenderer
    { 
        public CustomEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(global::Android.Graphics.Color.ParseColor("#3C3C3B"));
                gd.SetCornerRadius(15);
                gd.SetStroke(2, global::Android.Graphics.Color.ParseColor("#EDEDED"));
                Control.SetBackground(gd);
                Control.SetTextColor(global::Android.Graphics.Color.ParseColor("#FFFFFF"));
                Control.SetHintTextColor(global::Android.Graphics.Color.ParseColor("#BCBEC0"));
                Control.SetPadding(20, 20, 20, 20);
            }
        }
    }
}