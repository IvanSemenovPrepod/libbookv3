using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extentions;

namespace Services
{
    public class Student:baseService
    {
        datamodel.Entities db = new datamodel.Entities();

        /// <summary>
        /// Возвращает список студетов для поиска
        /// </summary>
        /// <param name="term">фраза для поиска</param>
        /// <returns></returns>
        public List<datamodel.vStudent> GetStudent(string term)
        {
            if (term.IsNullOrEmptyOrWhitespace())
            {
                return null;
            }

            var parts = term.Split(new char[] { ' ', '.' },
                             StringSplitOptions.RemoveEmptyEntries);

            var students = db.vStudents.AsEnumerable();

            foreach (var part in parts)
            {
                students = students.Where(
                    p => p.FirstName.Contains(part) ||
                    p.LastName.Contains(part) ||
                    p.SecondName.Contains(part) ||
                    p.GroupFullName.Contains(part) ||
                    p.GroupLittleName.Contains(part)
                    );
            }

            return students.ToList();
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
