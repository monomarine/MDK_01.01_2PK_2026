using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BehaviourPatterns_TemplateMethod
{
    public record WithdrawRequest(decimal amount);
    internal class WithdrawHandler : RequestHandler<WithdrawRequest>
    {
        private decimal _balance = 1000;
        protected override string Execute(WithdrawRequest request, string userID)
        {
            _balance -= request.amount;
            return new string($"списано {request.amount} остаток на счету {_balance}");
        }

        protected override bool Validate(WithdrawRequest request, string userID)
        {
            if (request.amount <= 0) return false;
            if (request.amount > _balance) return false;
            else return true;
        }
    }
}
