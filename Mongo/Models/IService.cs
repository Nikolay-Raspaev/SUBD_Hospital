using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Models
{
    public interface IService
    {
        int id { get; }

        string Name { get; }

        double Price { get; }
    }
}
