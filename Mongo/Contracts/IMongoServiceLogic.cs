using Mongo.Database.Models;
using Mongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Contracts
{
    public interface IMongoServiceLogic
    {
        List<Service>? ReadList();
        IService? ReadElement(int id);
        bool CreateService(IService model);
        bool DeleteService(IService model);
        bool DeleteAllService();
        bool UpdateService(IService model);
    }
}
