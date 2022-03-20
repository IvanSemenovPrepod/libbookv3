using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Student
    {
        datamodel.Entities db = new datamodel.Entities();

        //public  ActionResult test() { }
        /// <summary>
        /// Возвращает список студетов для поиска
        /// </summary>
        /// <param name="term">фраза для поиска</param>
        /// <returns></returns>
        public List<datamodel.vStudent> GetStudent(string term)
        {

            var t = db.vStudents.Where(p => p.FirstName.StartsWith(term)).ToList();
            if (t == null)
                throw new ArgumentNullException();
           return t;
        }

        /// <summary>
        /// Получение студента по id
        /// </summary>
        /// <param name="id">номер</param>
        /// <returns></returns>
        public datamodel.vStudent GetStudentById(int id)
        {
            return db.vStudents.FirstOrDefault(p => p.Id == id);
        }
    }
}
