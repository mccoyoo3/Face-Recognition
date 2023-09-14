using Mapbox.Geocoding;

namespace Mapbox.Examples.Scripts
{
    internal class MapboxGeocoding
    {
        private ForwardGeocodeResource resource;

        public MapboxGeocoding(ForwardGeocodeResource resource)
        {
            this.resource = resource;
        }
    }
}