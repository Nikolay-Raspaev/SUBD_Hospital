using Mongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Contracts
{
    public interface IJobLogic
    {
        List<IJob>? ReadList();
        IJob? ReadElement(int id);
        bool CreateJob(IJob model);
        bool DeleteJob(IJob model);
        bool UpdateJob(IJob model);
    }
}
