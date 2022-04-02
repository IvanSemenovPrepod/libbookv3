using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extentions;

namespace Services
{
    public class Teacher
    {
        datamodel.Entities db = new datamodel.Entities();

        /// <summary>
        /// Возвращает список преподавателей для поиска
        /// </summary>
        /// <param name="term">фраза для поиска</param>
        /// <returns></returns>
        public List<datamodel.vTeacher> GetTeacher(string term)
        {
            if (term.IsNullOrEmptyOrWhitespace())
            {
                return null;
            }

            var parts = term.Split(new char[] { ' ', '.'},
                             StringSplitOptions.RemoveEmptyEntries);

            var teachers = db.vTeachers.AsEnumerable();

            foreach (var part in parts)
            {
                teachers = teachers.Where(
                    p=>p.FirstName.ToLower().Contains(part) ||
                    p.LastName.ToLower().Contains(part) ||
                    p.SecondName.ToLower().Contains(part)
                    );
            }
            
            return teachers.ToList();
        }

        /// <summary>
        /// Получение преподавателя по id
        /// </summary>
        /// <param name="id">номер</param>
        /// <returns></returns>
        public datamodel.vTeacher GetTeacherById(int id)
        {
            return db.vTeachers.FirstOrDefault(p => p.Id == id);
        }

        public  IEnumerable<datamodel.vTeacher> GetAllTeachers()
        {
            return db.vTeachers;
        }
    }
}
