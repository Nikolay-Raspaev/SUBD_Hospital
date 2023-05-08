using HospitalBuisnessLogic.BuisnessLogicsContracts;
using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using HospitalDatabaseImplement;
using HospitalDatabaseImplement.Implements;
using HospitalDatabaseImplement.Models;
using HospitalDatabaseImplement.StoragesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBuisnessLogic.BuisnessLogic
{
    public class DoctorLogic : IDoctorLogic
    {
        private readonly IDoctorStorage _doctorStorage;
        public DoctorLogic(IDoctorStorage doctorStorage)
        {
            _doctorStorage = doctorStorage;
        }

        public bool Create(DoctorBindingModel model)
        {
            CheckModel(model);
            if (_doctorStorage.Insert(model) == null)
            {
                return false;
            }
            return true;
        }

        public bool Delete(DoctorBindingModel model)
        {
            CheckModel(model, false);
            if (_doctorStorage.Delete(model) == null)
            {
                return false;
            }
            return true;
        }

        public DoctorViewModel? ReadElement(DoctorSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var element = _doctorStorage.GetElement(model);
            if (element == null)
            {
                return null;
            }
            return element;
        }

        public List<DoctorViewModel>? ReadList(DoctorSearchModel? model)
        {
            var list = _doctorStorage.GetFullList();
            if (list == null)
            {
                return null;
            }
            return list;
        }

        public List<Doctor>? ReadListDoctor()
        {
            var list = _doctorStorage.GetFullListDoctor();
            if (list == null)
            {
                return null;
            }
            return list;
        }

        public bool Update(DoctorBindingModel model)
        {
            CheckModel(model);
            if (_doctorStorage.Update(model) == null)
            {
                return false;
            }
            return true;
        }
        private void CheckModel(DoctorBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.Passport))
            {
                throw new ArgumentNullException("Нет названия компонента", nameof(model.Passport));
            }
            using var context = new HospitalBdContext();
            if(context.Doctors.Count() > 0)
            {
                var element = _doctorStorage.GetElement(new DoctorSearchModel
                {
                    Passport = model.Passport
                });
                if (element != null && element.Id != model.Id)
                {
                    throw new InvalidOperationException("Продукт с таким названием уже есть");
                }
            }
        }
    }
}
