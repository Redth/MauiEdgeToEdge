using Android.App;
using Android.Views;
using Android.Widget;
using Google.Android.Material.AppBar;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Platform;

namespace MauiEdgeToEdge
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            Microsoft.Maui.Handlers.ToolbarHandler.Mapper.AppendToMapping("FixInsets", (handler, view)=>
            {
                var parentView = view.Parent?.Handler?.PlatformView;

                if (parentView is Activity activity)
                {
                    activity?.FindViewById<AppBarLayout>(Resource.Id.navigationlayout_appbar)
                        ?.SetFitsSystemWindows(true);
                }
                else if (parentView is Android.Views.View androidView)
                {
                    androidView?.FindViewById<AppBarLayout>(Resource.Id.navigationlayout_appbar)
                        ?.SetFitsSystemWindows(true);
                }
            });
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

      
    }
}
