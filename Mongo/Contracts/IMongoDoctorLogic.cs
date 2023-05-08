using Mongo.Database.Models;
using Mongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Contracts
{
    public interface IMongoDoctorLogic
    {
        List<Doctor>? ReadList();
        IDoctor? ReadElement(int id);
        IDoctor CreateDoctor(IDoctor model);
        bool DeleteDoctor(IDoctor model);
        bool DeleteAllDoctor();
        bool UpdateDoctor(IDoctor model);
    }
}
