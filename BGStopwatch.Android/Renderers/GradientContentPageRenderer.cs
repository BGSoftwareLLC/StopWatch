using Android.Content;
using BGStopwatch.Droid.Renderers;
using BGStopwatch.Helpers;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Views;
using Android.Support.V4.Content;

[assembly: ExportRenderer (typeof(GradientContentPage), typeof(GradientContentPageRenderer))]

namespace BGStopwatch.Droid.Renderers
{
    public class GradientContentPageRenderer : PageRenderer
    {
        public Context context { get; set; }
        public GradientContentPageRenderer(Context context) : base(context)
        {
            this.context = context;
        }
        protected override void OnVisibilityChanged(Android.Views.View changedView, ViewStates visibility)
        {
            base.OnVisibilityChanged(changedView, visibility);
            SetBackground();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> page)
        {
            base.OnElementChanged(page);
            SetBackground();
        }

        private void SetBackground()
        {
            SetBackgroundDrawable(ContextCompat.GetDrawable(context, Resource.Drawable.BackgroundStyle));
        }
    }
}