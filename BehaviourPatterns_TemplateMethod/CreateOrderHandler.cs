using System;
using System.Collections.Generic;
using System.Text;

namespace BehaviourPatterns_TemplateMethod
{
    public record CreateOrderRequest(string productID, int count);

    internal class CreateOrderHandler : RequestHandler<CreateOrderRequest>
    {
        protected override string Execute(CreateOrderRequest request, string userID)
        {
            return ($"заказ {request.productID} создан. " +
                $"количество {request.count} " +
                $"для пользователя {userID}");
        }

        protected override bool Validate(CreateOrderRequest request, string userID)
        {
            if (request.count <= 0)
                return false;
            if (string.IsNullOrEmpty(request.productID)) return false;
            else return true;

        }
    }
}
