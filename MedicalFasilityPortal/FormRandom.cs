using HospitalBuisnessLogic.BuisnessLogic;
using HospitalContracts.BindingModels;
using HospitalBuisnessLogic.BuisnessLogicsContracts;
using HospitalDatabaseImplement;
using HospitalDatabaseImplement.Models;
using HospitalDataModels;
using HospitalDataModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace HospitalView
{
    public partial class FormRandom : Form
    {
        private readonly IPatientLogic _patientLogic;
        private readonly IJobLogic _jobLogic;
        private readonly IServiceLogic _serviceLogic;
        private readonly IDoctorLogic _doctorLogic;
        public FormRandom(IPatientLogic patientLogic, IServiceLogic serviceLogic, IJobLogic jobLogic, IDoctorLogic doctorLogic)
        {
            InitializeComponent();
            _patientLogic = patientLogic;
            _serviceLogic = serviceLogic;
            _jobLogic = jobLogic;
            _doctorLogic = doctorLogic;
        }
        string[] Names = new string[] { "Захар", "Ева", "Сергей", "Максим", "Максимильян", "Лука", "Олег", "Мишель", "София", "Стела", "Аким", "Матвей", "Анисия", "Василий", "Лукьян", "Руслан", "Клара", "Андрей", "Мстислав", "Федот", "Олег", "Аркадий", "Ангелина", "Анжелика", "Стефания", "Мариам", "Дементий", "Андрон", "Даниил", "Адам", "Евдоким", "Валерий", "Дамир", "Фёдор", "Василиса", "Сафина", "Даниэль", "Дарина", "Мир", "Феофан", "Всеслава", "Инна", "Платон", "Ирина", "Рафаэль", "Милана", "Клавдий", "Лейла", "Роза", "Тимофей", "Пимен", "Модест", "Эмма", "Георгий", "Дарья", "Дмитрий", "Эрик", "Филипп", "Владилен", "Евсей", "Даниль", "Ростислав", "Тихон", "Тея", "Наум", "Виолетта", "Анатолий", "Рустам", "Юлия", "Дана", "Самсон", "Ариадна", "Ибрагим", "Светлана", "Инга", "Али", "Виталий", "Алисия", "Оксана", "Тимур", "Аида", "Камиль", "Иннокентий", "Элина", "Виктория", "Анна", "Амелия", "Япсина", "Эвелина", "Кира", "Артур", "Владлена", "Никифор", "Марина", "Артем", "Моисей", "Иван", "Лидия", "Трофим", "Игорь" };
        string[] Surnames = new string[] { "Пищальников", "Яхонтов", "Кочетов", "Ермилова", "Разбойникова", "Окулова", "Дудинова", "Добрынина", "Кучава", "Лазарев", "Егорова", "Ипатьев", "Байдавлетов", "Шалаганов", "Масмехов", "Шентеряков", "Юдачёв", "Дагина", "Лавлинский", "Гунин", "Яшвили", "Шуршалина", "Сомкина", "Бояринов", "Коленко", "Меншикова", "Бойков", "Ябловский", "Любова", "Ямпольский", "Фанина", "Молчанова", "Верещагин", "Окладников", "Чичерина", "Ключников", "Барышев", "Вятт", "Толбугин", "Радченко", "Веселкова", "Щавлева", "Слепынина", "Садков", "Барышников", "Бенедиктов", "Графова", "Мирнова", "Васильев", "Никишина", "Краснов", "Набатников", "Пронин", "Стрельцов", "Булка", "Саврасова", "Элиашева", "Канаев", "Кичеева", "Портнова", "Машарин", "Ларина", "Курганова", "Лапаева", "Яшуков", "Шлыков", "Арнаутова", "Ширяев", "Зуев", "Синдеева", "Трутнев", "Кошечкин", "Логинов", "Колпаков", "Бендлина", "Мурзакова", "Витинский", "Ратаева", "Щедрин", "Овощников", "Язвецова", "Крупин", "Седельников", "Юхтрица", "Лыков", "Смешной", "Пожарский", "Мичуев", "Шлиппенбах", "Татаринов", "Янютин", "Кулагина", "Семёнов", "Зверева", "Ивакин", "Бабинова", "Цейдлерин", "Сагадиев", "Истлентьев", "Деменока" };
        string[] Patronymic = new string[] { "Владимирович(на)", "Олегович(на)", "Александрович(на)", "Алексеевич(на)", "Генадьевич(на)", "Максимович(на)", "Павлович(на)", "Акимович(на)", "Лукьянович(на)", "Матвеевич(на)", "Адреевич(на)", "Федотович(на)", "Аркадий(на)", "Мстиславович(на)", "Федотович(на)", "Даниилович(на)", "Никитьевич(на)", "Евдокимович(на)", "Валерьевич(на)", "Дамирович(на)", "Клавдьевич(на)", "Мирович(на)", "Миронович(на)", "Платонович(на)", "Игоревич(на)", "Антонович(на)", "Валерьевич(на)", "Модестович(на)", "Тимофеевич(на)", "Владленович(на)", "Дмитриевич(на)", "Бенедиктович(на)", "Рустамович(на)", "Ростиславович(на)", "Николаевич(на)", "Данателович(на)", "Ибрагимович(на)", "Анатольевич(на)" };

        Random rd = new Random();
        Random rand = new Random();
        string GetRandomTelNo()
        {
            StringBuilder telNo = new StringBuilder(12);
            int number;
            for (int i = 0; i < 3; i++)
            {
                number = rand.Next(0, 8); // digit between 0 (incl) and 8 (excl)
                telNo = telNo.Append(number.ToString());
            }
            telNo = telNo.Append("-");
            number = rand.Next(0, 743); // number between 0 (incl) and 743 (excl)
            telNo = telNo.Append(String.Format("{0:D3}", number));
            telNo = telNo.Append("-");
            number = rand.Next(0, 10000); // number between 0 (incl) and 10000 (excl)
            telNo = telNo.Append(String.Format("{0:D4}", number));
            return telNo.ToString();
        }
        string GetRandomPassport()
        {
            int number;
            string passport = "";
            for (int i = 0; i < 10; i++)
            {
                number = rand.Next(0, 9); // digit between 0 (incl) and 8 (excl)
                passport = string.Concat(passport, number.ToString());
            }
            return passport;
        }
        DateTime RandomDate()
        {
            DateTime start = new DateTime(1970, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rd.Next(range)).AddHours(rd.Next(0, 24)).AddMinutes(rd.Next(0, 60));
        }
        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26;

            for (var i = 0; i < size; i++)
            {
                var @char = (char)rand.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            switch (comboBoxQuary.SelectedItem)
            {
                case "Добавить":
                    switch (comboBoxWhat.SelectedItem)
                    {
                        case "Пациенты":
                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            for (int i = 0; i < Convert.ToInt32(textBoxCount.Text); i++)
                            {
                                DateOnly dateTime = DateOnly.FromDateTime(RandomDate());
                                var modelT = new PatientBindingModel
                                {
                                    Id = 0,
                                    Name = Names[rd.Next(0, Names.Length - 1)],
                                    Surname = Surnames[rd.Next(0, Surnames.Length - 1)],
                                    Patronymic = Patronymic[rd.Next(0, Patronymic.Length - 1)],
                                    Birthdate = dateTime,
                                    Passport = GetRandomPassport(),
                                    TelephoneNumber = GetRandomTelNo(),
                                };
                                _patientLogic.Create(modelT);
                            }
                            stopwatch.Stop();
                            TimeSpan ts = stopwatch.Elapsed;


                            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                ts.Hours, ts.Minutes, ts.Seconds,
                                ts.Milliseconds / 10);
                            label.Text = ("RunTime " + elapsedTime);
                            break;
                        case "Врачи":
                            Stopwatch stopwatch4 = new Stopwatch();
                            stopwatch4.Start();
                            int rnd1;
                            var list = _jobLogic.ReadList(null);
                            for (int i = 0; i < Convert.ToInt32(textBoxCount.Text); i++)
                            {
                                rnd1 = rand.Next(1, list.Count);
                                DateOnly dateTime = DateOnly.FromDateTime(RandomDate());
                                var modelT = new DoctorBindingModel
                                {
                                    Id = 0,
                                    Name = Names[rd.Next(0, Names.Length - 1)],
                                    Surname = Surnames[rd.Next(0, Surnames.Length - 1)],
                                    Patronymic = Patronymic[rd.Next(0, Patronymic.Length - 1)],
                                    Birthdate = dateTime,
                                    Passport = GetRandomPassport(),
                                    TelephoneNumber = GetRandomTelNo(),
                                    Education = "Высшее Улгту",
                                    Jobid = rnd1,
                                    AcademicRankId = 1,
                                };
                                _doctorLogic.Create(modelT);
                            }
                            stopwatch4.Stop();
                            TimeSpan ts4 = stopwatch4.Elapsed;


                            string elapsedTime4 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                ts4.Hours, ts4.Minutes, ts4.Seconds,
                                ts4.Milliseconds / 10);
                            label.Text = ("RunTime " + elapsedTime4);
                            break;
                        case "Профессии":
                            var listService = _serviceLogic.ReadList(0);
                            Stopwatch stopwatch1 = new Stopwatch();
                            stopwatch1.Start();
                            Dictionary<int, IService> _jobServices = new Dictionary<int, IService>();
                            int rnd;
                            for (int i = 0; i < Convert.ToInt32(textBoxCount.Text); i++)
                            {
                                _jobServices.Clear();
                                for (int j = 0; j < 20; j++)
                                {
                                    rnd = rand.Next(1, listService.Count);
                                    if (!_jobServices.ContainsKey(rnd))
                                    {
                                        _jobServices.Add(rnd, listService.FirstOrDefault(x => x.Id == rnd));
                                    }
                                }
                                if (_jobServices.Count == 0)
                                {
                                    _jobServices.Add(1, listService.FirstOrDefault(x => x.Id == 1));
                                }
                                var model = new JobBindingModel
                                {
                                    Id = 0,
                                    JobTitle = RandomString(20, false),
                                    JobServices = _jobServices
                                };
                                _jobLogic.Create(model);
                            }
                            stopwatch1.Stop();
                            TimeSpan ts1 = stopwatch1.Elapsed;


                            string elapsedTime1 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                ts1.Hours, ts1.Minutes, ts1.Seconds,
                                ts1.Milliseconds / 10);
                            label.Text = ("RunTime " + elapsedTime1);
                            break;
                        case "Услуги":
                            Stopwatch stopwatch2 = new Stopwatch();
                            stopwatch2.Start();
                            for (int i = 0; i < Convert.ToInt32(textBoxCount.Text); i++)
                            {
                                var modelT = new ServiceBindingModel
                                {
                                    Id = 0,
                                    ServiceName = RandomString(20, false),
                                    ServicePrice = rd.Next(1000, 20000),
                                };
                                _serviceLogic.Create(modelT);
                            }
                            stopwatch2.Stop();
                            TimeSpan ts2 = stopwatch2.Elapsed;

                            string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                ts2.Hours, ts2.Minutes, ts2.Seconds,
                                ts2.Milliseconds / 10);
                            label.Text = ("RunTime " + elapsedTime2);
                            break;
                    }
                    break;
                case "Select?":
                    switch (comboBoxWhat.SelectedItem)
                    {
                        case "Пациенты":
                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            var list = _patientLogic.ReadList(null);
                            stopwatch.Stop();
                            TimeSpan ts = stopwatch.Elapsed;
                            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                ts.Hours, ts.Minutes, ts.Seconds,
                                ts.Milliseconds / 10);
                            label.Text = ("RunTime " + elapsedTime);
                            break;
                        case "Профессии":
                            Stopwatch stopwatch1 = new Stopwatch();
                            stopwatch1.Start();
                            var list1 = _jobLogic.ReadList(null);
                            stopwatch1.Stop();
                            TimeSpan ts1 = stopwatch1.Elapsed;
                            string elapsedTime1 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                ts1.Hours, ts1.Minutes, ts1.Seconds,
                                ts1.Milliseconds / 10);
                            label.Text = ("RunTime " + elapsedTime1);
                            break;
                        case "Услуги":
                            Stopwatch stopwatch2 = new Stopwatch();
                            stopwatch2.Start();
                            var list2 = _serviceLogic.ReadList(0);
                            stopwatch2.Stop();
                            TimeSpan ts2 = stopwatch2.Elapsed;
                            string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                ts2.Hours, ts2.Minutes, ts2.Seconds,
                                ts2.Milliseconds / 10);
                            label.Text = ("RunTime " + elapsedTime2);
                            break;
                        case "Join":
                            Stopwatch stopwatch3 = new Stopwatch();
                            var context = new HospitalBdContext();
                            var services = context.Services;
                            var servicesJobs = context.ServicesJobs;
                            var doctors = context.Doctors;
                            stopwatch3.Start();
                            var employees = context.Jobs
                                .Join(servicesJobs, // второй набор
                                 job => job.Id, // свойство-селектор объекта из первого набора
                                 serviceJobs => serviceJobs.JobId, // свойство-селектор объекта из второго набора
                                 (job, serviceJobs) => new { JobTitle = job.JobTitle, JobId = job.Id, ServicesId = serviceJobs.ServicesId })// результат
                                .Join(services,
                                JS => JS.ServicesId,
                                service => service.Id,
                                (JS, service) => new { JobTitle = JS.JobTitle, JobId = JS.JobId, ServicesId = JS.ServicesId, ServicePrice = service.ServicePrice, ServiceName = service.ServiceName })
                                .Join(doctors,
                                JS => JS.JobId,
                                doctor => doctor.Jobid,
                                (JS, doctor) => new
                                {
                                    JobTitle = JS.JobTitle,
                                    JobId = JS.JobId,
                                    ServicesId = JS.ServicesId,
                                    ServicePrice = JS.ServicePrice,
                                    ServiceName = JS.ServiceName,
                                    Surname = doctor.Surname,
                                    Patronymic = doctor.Patronymic,
                                    Name = doctor.Name,
                                    Birthdate = doctor.Birthdate,
                                    Passport = doctor.Passport,
                                    TelephoneNumber = doctor.TelephoneNumber,
                                    Education = doctor.Education,
                                    AcademicRankId = doctor.AcademicRankId
                                });
                            stopwatch3.Stop();
                            TimeSpan ts3 = stopwatch3.Elapsed;
                            string elapsedTime3 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                ts3.Hours, ts3.Minutes, ts3.Seconds,
                                ts3.Milliseconds / 10);
                            label.Text = ("RunTime " + elapsedTime3);
                            break;
                    }
                    break;
            }

        }
    }
}
