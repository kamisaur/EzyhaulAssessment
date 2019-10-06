using EzyhaulAssessment.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EzyhaulAssessment.Forms.UI.Templates
{
    public class LocationTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DeliveryLocationTemplate = new DataTemplate(typeof(DeliveryLocation));

        public DataTemplate PickupLocationTemplate = new DataTemplate(typeof(PickupLocation));

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var temp = item as Location;

            if(temp.type == "DEL")
            {
                return DeliveryLocationTemplate;
            }
            else
            {
                return PickupLocationTemplate;
            }

        }
    }
}
