using Mongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Database.Models
{
    public class Job : IJob
    {
        public int id { get; set; }

        public string jobTitle { get; set; }
    }
}
