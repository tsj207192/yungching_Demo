using System;
using yungching_Demo.Areas.Hotel.Service;

namespace yungching_Demo.Areas.Hotel.Models
{
    public class SupplierFactory
    {
        public enum Supplier
        {
            Agoda,
            Expedia
        }

        private Supplier _supplierName;
        private IHotelService _hotelService;

        public SupplierFactory(string supplierName)
        {
            _supplierName = (Supplier)Enum.Parse(typeof(Supplier), supplierName, true);
        }

        public IHotelService GetService()
        {
            switch (_supplierName)
            {
                case Supplier.Agoda:
                    _hotelService = new AgodaHotelService();
                    break;
                case Supplier.Expedia:
                    _hotelService = new ExpediaHotelService();
                    break;
            }
            return _hotelService;
        }
    }
}