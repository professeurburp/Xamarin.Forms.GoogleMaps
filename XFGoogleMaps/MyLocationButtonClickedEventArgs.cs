using System;
namespace Xamarin.Forms.GoogleMaps
{
    public sealed class MyLocationButtonClickedEventArgs : EventArgs
    {
        public bool Handled { get; set; } = false;

        internal MyLocationButtonClickedEventArgs()
        {
        }
    }
}
