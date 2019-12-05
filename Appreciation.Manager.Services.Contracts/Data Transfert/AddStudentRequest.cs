using Appreciation.Manager.Infrastructure.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services.Contracts.Data_Transfert
{
    public class AddStudentRequest : Request
    {
        public int Age { get; set; }

        public CivilityEnum Civility { get; set; }

        public AddUsersRequest User { get; set; }
    }
}
