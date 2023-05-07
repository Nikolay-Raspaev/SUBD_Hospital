using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Contracts
{
    public interface IDocotorLogic
    {
        List<IDocotor>? ReadList();
        IDocotor? ReadElement(int id);
        bool CreateDocotor(IDocotor model);
        bool DeleteDocotor(IDocotor model);
        bool UpdateDocotor(IDocotor model);
    }
}
