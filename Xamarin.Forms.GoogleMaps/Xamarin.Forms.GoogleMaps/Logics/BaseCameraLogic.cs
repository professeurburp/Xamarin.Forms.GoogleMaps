﻿using Xamarin.Forms.GoogleMaps.Internals;

namespace Xamarin.Forms.GoogleMaps.Logics
{
    internal abstract class BaseCameraLogic<TNativeMap> : IMapRequestDelegate where TNativeMap:class
    {
        protected Map _map;
        protected TNativeMap _nativeMap;

        public float ScaledDensity { get; internal set; }

        public virtual void Register(Map map, TNativeMap nativeMap)
        {
            _map = map ?? throw new System.ArgumentNullException(nameof(map));
            _nativeMap = nativeMap ?? throw new System.ArgumentNullException(nameof(nativeMap));

            _map.OnMoveToRegion = OnMoveToRegionRequest;
            _map.OnMoveCamera = OnMoveCameraRequest;
            _map.OnAnimateCamera = OnAnimateCameraRequest;
        }

        public virtual void Unregister()
        {
            if (_map != null)
            {
                _map.OnAnimateCamera = null;
                _map.OnMoveCamera = null;
                _map.OnMoveToRegion = null;
            }
        }

        public abstract void OnMoveToRegionRequest(MoveToRegionMessage m);
        public abstract void OnMoveCameraRequest(CameraUpdateMessage m);
        public abstract void OnAnimateCameraRequest(CameraUpdateMessage m);
    }
}