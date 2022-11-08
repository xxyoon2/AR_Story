using System.Collections.Generic;
using UniRx;
using TMPro;

namespace Model
{
    public static class MapModel
    {
        public static BoolReactiveProperty InteractionEnable = new BoolReactiveProperty();

        private static List<LocationRecord> _destinations;
        public static List<LocationRecord> Destinations
        {
            get { return _destinations; }
            set { _destinations = value; }
        }


        public static void SetPopUpUIText(bool canInteract)
        {
            InteractionEnable.Value = canInteract;
            if(canInteract)
            {
                // �� �ȳ� ���� ���� ~
            }
            else
            {
                // �� �ȳ� �Ұ��� ���� ~
            }
        }
    }
}
