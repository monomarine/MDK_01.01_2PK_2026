using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralPatterns_Facade
{
    internal class OrderFacade
    {
        private BoxingService _boxingService;
        private DeliveryService _deliveryService;
        private NotifyService _notifyService;
        private Order _order;

        public OrderFacade(Order order)
        {
            _boxingService = new BoxingService();
            _notifyService = new NotifyService();
            _deliveryService = new DeliveryService();
            _order = order;
        }

        public void ProcessOrder()
        {
            _boxingService.Pack(_order);
            _notifyService.Notify(_order);
            _deliveryService.Delivery(_order);
        }
    }
}
