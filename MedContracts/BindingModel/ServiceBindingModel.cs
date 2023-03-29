using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedContracts.BindingModel
{
    public class ServiceBindingModel
    {
        public int Id { get; set; }

        public string ServicesName { get; set; } = null!;

        public decimal ServicesPrice { get; set; }
    }
}
