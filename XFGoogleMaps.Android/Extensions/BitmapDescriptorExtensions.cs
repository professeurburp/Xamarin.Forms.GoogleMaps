using Android.Graphics;
using NativeBitmapDescriptor = Android.Gms.Maps.Model.BitmapDescriptor;
using NativeBitmapDescriptorFactory = Android.Gms.Maps.Model.BitmapDescriptorFactory;
using Android.Content.Res;

namespace Xamarin.Forms.GoogleMaps.Android.Extensions
{
    internal static class BitmapDescriptorExtensions
    {
        private const string DrawableType = "drawable";

        public static NativeBitmapDescriptor ToBitmapDescriptor(this BitmapDescriptor self)
        {
            switch (self.Type)
            {
                case BitmapDescriptorType.Default:
                    return NativeBitmapDescriptorFactory.DefaultMarker((float)((self.Color.Hue * 360f) % 360f));

                case BitmapDescriptorType.Resource:
                    var context = FormsGoogleMaps.Context;
                    int imageResourceId = context.Resources.GetIdentifier(
                        self.ResourceName,
                        DrawableType,
                        context.PackageName);
                    return NativeBitmapDescriptorFactory.FromResource(imageResourceId);

                case BitmapDescriptorType.Bundle:
                    return NativeBitmapDescriptorFactory.FromAsset(self.BundleName);

                case BitmapDescriptorType.Stream:
                    self.Stream.Position = 0;
                    return NativeBitmapDescriptorFactory.FromBitmap(BitmapFactory.DecodeStream(self.Stream));

                case BitmapDescriptorType.AbsolutePath:
                    return NativeBitmapDescriptorFactory.FromPath(self.AbsolutePath);

                default:
                    return NativeBitmapDescriptorFactory.DefaultMarker();
            }
        }
    }
}

