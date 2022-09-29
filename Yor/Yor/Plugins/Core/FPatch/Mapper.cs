using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yor.Plugins.Core.Memory;

namespace Yor.Plugins.Core.Fpatch
{
    public class Mapper
    {
        private Address address { get; set; }
        public Dictionary<Address.Method, Func<byte[], byte[]>> mapping { get; set; }

        public Mapper(Address address)
        {
            this.address = address;
            mapping = new Dictionary<Address.Method, Func<byte[], byte[]>>()
            {
                { Address.Method.insert, address.insert },
                { Address.Method.replace, address.replace }
            };
        }
    }
}
