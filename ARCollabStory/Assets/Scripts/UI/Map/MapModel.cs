using System.Collections.Generic;
using UniRx;

namespace Model
{
    public static class MapModel
    {
        public static BoolReactiveProperty DestinationStatus = new BoolReactiveProperty();

        private static List<LocationRecord> _destinations;
        public static List<LocationRecord> Destinations
        {
            get { return _destinations; }
            set { _destinations = value; }
        }


        public static void SetDestinationStatus(bool canInteract)
        {
            DestinationStatus.Value = canInteract;
        }
    }
}
