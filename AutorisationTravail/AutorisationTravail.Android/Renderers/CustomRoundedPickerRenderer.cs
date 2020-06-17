[assembly: Xamarin.Forms.ExportRenderer(typeof(AutorisationTravail.Controls.CustomRoundedPicker), typeof(AutorisationTravail.Droid.Renderers.CustomRoundedPickerRenderer))]
namespace AutorisationTravail.Droid.Renderers
{
    public class CustomRoundedPickerRenderer : Xamarin.Forms.Platform.Android.AppCompat.PickerRenderer
    {
        public CustomRoundedPickerRenderer(Android.Content.Context context) : base(context)
        {

        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.Picker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.SetBackgroundResource(AutorisationTravail.Droid.Resource.Layout.StylePicker);
                Control.SetPadding(15, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);
                Control.SetTextSize(Android.Util.ComplexUnitType.Dip, 14);
            }
        }
    }
}