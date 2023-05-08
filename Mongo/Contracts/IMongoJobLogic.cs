using Mongo.Database.Models;
using Mongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Contracts
{
    public interface IMongoJobLogic
    {
        List<Job>? ReadList();
        IJob? ReadElement(int id);
        bool CreateJob(IJob model);
        bool DeleteJob(IJob model);
        bool DeleteAllJob();
        bool UpdateJob(IJob model);
    }
}
