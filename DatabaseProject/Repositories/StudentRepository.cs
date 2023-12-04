using DatabaseProject.DatabaseContext;
using DatabaseProject.Entity_Model;
using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        
       private readonly SqlServerContext _SqlServerContext;

        public StudentRepository(SqlServerContext sqlServerContext)
        {
            _SqlServerContext = sqlServerContext;
        }
        
        public SchoolStudent AddSubject(SchoolStudent schoolstudent)

        {
            var student = new Subject() {SubejectName= schoolstudent.SubjectName, SubjectMarks= schoolstudent.SubjectMarks};
            _SqlServerContext.Subject.Add(student);
            _SqlServerContext.SaveChanges();
            return schoolstudent;
        }

    }
}
