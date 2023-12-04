using DatabaseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Interfaces
{
    public interface IStudentRepository
    {
        SchoolStudent AddSubject(SchoolStudent subject);
    }
}
