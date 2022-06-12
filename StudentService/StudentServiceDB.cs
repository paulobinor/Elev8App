using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elev8App.StudentService
{
    public static class StudentServiceDB
    {
        public static elev8dbEntites _context = null;
     
       
        public async static void AddNewStudent(student student)
        {
            _context = new elev8dbEntites();
            _context.students.Add(student);
            await _context.SaveChangesAsync();
        }
    }
}
