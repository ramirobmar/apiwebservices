using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAll(string userName);
        void AddUpdate(string userName, Address address);
        void SetDefault(string userName, string defaultAddressId, AddressType addressType);
    }
}
