using Students.DataAccess;
using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Services
{
   public class ActionResult
    {
        static List<Group> groups = new List<Group>();
        static Group group = new Group();

        static List<Student> students = new List<Student>();

        static void SelectionGroup()
        {
            Console.WriteLine("Список групп:");
            groups=StudentRepository.GetGroups();
            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Id}. {group.Name}");
            }
        }

        public static void DemonstrationJob()
        {
            SelectionGroup();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("Добавим запись в таблицу группы");
            group.Name = "KVO-123";
            StudentRepository.CreateGroup(group);
            SelectionGroup();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("Выберите из списка номер записи которую хотели бы удалить:");
            int id = 0;
            while (id==0)
            {
            int.TryParse(Console.ReadLine(), out id);
            }
            StudentRepository.DeleteGroup(id);
            SelectionGroup();
            Console.WriteLine("\n\n\n");
           
            Console.WriteLine("Обновить данные таблицы: ");
            id = 0;
            while (id == 0)
            {
                int.TryParse(Console.ReadLine(), out id);
            }

            StudentRepository.UpdateGroup(id);

            Console.Clear();
            Console.WriteLine("Запоним таблицу студентов: ");
            Student student = new Student();
            Console.Write("Введите имя: ");
            student.FirstName = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            student.LastName = Console.ReadLine();
            Console.Write("Введите отчество: ");
            student.MiddleName = Console.ReadLine();

            SelectionGroup();
            Console.WriteLine("Выберите из списка принадлежность студента к группе:");
            id = 0;
            while (id == 0)
            {
                int.TryParse(Console.ReadLine(), out id);
            }
            student.GroupId = id;
            StudentRepository.CreateStudent(student);
            Console.WriteLine("Изменим данные студента:");
            id = 1;
            StudentRepository.UpdateStudent(id);
            StudentRepository.ShowStudent();
            id = 0;
            Console.WriteLine("Введите id студента запись которого надо удалить");
            while (id == 0)
            {
                int.TryParse(Console.ReadLine(), out id);
            }
            StudentRepository.DeleteStudent(id);
            StudentRepository.ShowStudent();
        }
    }
}
