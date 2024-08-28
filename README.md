# MauiEdgeToEdge
Playing around with edge to edge apps and safe areas

## Android
If we enable Edge to Edge on Android in a MAUI app (built against, targeting, and _running_ on API 35), things don't quite look right:

![image](https://github.com/user-attachments/assets/7f3d46cf-bd24-4e7c-b383-f7a117db5b10)

> The 'EdgeToEdge' class was ported from Kotlin code until we reference newer AndroidX packages which contain this functionality


### Fixing the MaterialToolbar on NavigationPage

It looks like we use `MaterialToolbar` nested inside an `AppBarLayout`.  The `AppBarLayout` needs to be set to fit system windows in order to have the correct padding to cause content to not layout beneath the status bar:

```csharp
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
```