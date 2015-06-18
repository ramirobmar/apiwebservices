using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IPaymentMethodRepository
    {
        IEnumerable<PaymentMethod> GetAll(string userName);
        void AddUpdate(string userName, PaymentMethod paymentMethod);
        void SetDefault(string userName, string defaultPaymentMethodId);
    }
}
