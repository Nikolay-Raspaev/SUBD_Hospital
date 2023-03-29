using HospitalContracts.BindingModels;
using HospitalContracts.BuisnessLogicsContracts;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBuisnessLogic.BuisnessLogic
{
    public class PatientLogic : IPatientLogic
    {
        public bool Create(PatientBindingModel model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(PatientBindingModel model)
        {
            throw new NotImplementedException();
        }

        public PatientViewModel? ReadElement(PatientSearchModel model)
        {
            throw new NotImplementedException();
        }

        public List<PatientViewModel>? ReadList(PatientSearchModel? model)
        {
            throw new NotImplementedException();
        }

        public bool Update(PatientBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
