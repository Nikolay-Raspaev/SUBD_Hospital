using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDataImport
{
    public interface IDataImport
    {
        void DataImportContract();
        void DataImportDoctor();
        void DataImportJob();
        void DataImportPatient();
        void DataImportService();
    }
}
