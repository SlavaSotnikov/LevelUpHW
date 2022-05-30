using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace LINQ_Schedule_Task
{
    class TeacherStudentsDataModel
    {
        #region         
        
        private List<Group> _groups = new List<Group>();
        private List<Teacher> _teachers = new List<Teacher>();
        private List<Student> _students = new List<Student>();
        //private List<Schedule> _schedule = new List<Schedule>();
        private Dictionary<DayLesson, Schedule> _schedule = new Dictionary<DayLesson, Schedule>();
        
        #endregion

        public TeacherStudentsDataModel()
        {
            _teachers.Add(new Teacher() { ID = 1, FirstName = "Nick", LastName = "Ivanov", Specialty = "Prog" });
            _teachers.Add(new Teacher() { ID = 2, FirstName = "Vasily", LastName = "Petrov", Specialty = "Test" });
            _teachers.Add(new Teacher() { ID = 3, FirstName = "Dmtry", LastName = "Sidorov", Specialty = "Mngr" });
            _teachers.Add(new Teacher() { ID = 12, FirstName = "Alexey", LastName = "Simonov", Specialty = "Mngr" });
            _teachers.Add(new Teacher() { ID = 15, FirstName = "Alexander", LastName = "Ivanov", Specialty = "Prog" });

            _groups.Add(new Group() { ID = 1, GroupName = "Gr_1", TeacherID = 2 });
            _groups.Add(new Group() { ID = 2, GroupName = "Gr_2", TeacherID = 3 });
            _groups.Add(new Group() { ID = 3, GroupName = "Gr_3", TeacherID = 1 });
            _groups.Add(new Group() { ID = 2, GroupName = "Gr_4", TeacherID = 3 });
            _groups.Add(new Group() { ID = 4, GroupName = "Gr_7", TeacherID = 15 });
            _groups.Add(new Group() { ID = 6, GroupName = "Gr_8", TeacherID = 15 });
            _groups.Add(new Group() { ID = 6, GroupName = "Gr_9", TeacherID = 16 });
            _groups.Add(new Group() { ID = 6, GroupName = "Gr_9", TeacherID = 14 });

            _students.Add(new Student() { ID = 4, FirstName = "Alexey", LastName = "Simonov", GroupID = 1, RecordBookNumber = 10201 });
            _students.Add(new Student() { ID = 5, FirstName = "Alexander", LastName = "Alexandrov", GroupID = 4, RecordBookNumber = 10202 });
            _students.Add(new Student() { ID = 6, FirstName = "Gennady", LastName = "Belaev", GroupID = 1, RecordBookNumber = 10203 });

            _students.Add(new Student() { ID = 7, FirstName = "Alexey", LastName = "Koval", GroupID = 2, RecordBookNumber = 10204 });
            _students.Add(new Student() { ID = 3, FirstName = "Stanislav", LastName = "Alexeenko", GroupID = 2, RecordBookNumber = 10205 });
            _students.Add(new Student() { ID = 9, FirstName = "Valentina", LastName = "Belkina", GroupID = 3, RecordBookNumber = 10206 });
            _students.Add(new Student() { ID = 9, FirstName = "Alexander", LastName = "Miroshnichenko", GroupID = 3, RecordBookNumber = 10207 });
            _students.Add(new Student() { ID = 10, FirstName = "Marat", LastName = "Ivascheenko", GroupID = 2, RecordBookNumber = 10202 });
            _students.Add(new Student() { ID = 11, FirstName = "Vasily", LastName = "Petrov", GroupID = 3, RecordBookNumber = 10208 });
        }

        public IEnumerable<Teacher> Teachers
        {
            get => _teachers;
        }


        public IEnumerable<Person> Persons
        {
            get => _students.Concat<Person>(_teachers); 

        }

        public IEnumerable<Group> Groups { get => _groups; }

        public IEnumerable<Student> Students
        {
            get => _students;
        }

        //a) ID любых сущностей не должны повторяться
        public IEnumerable<Person> GetInvalidPersonsID()
        {
            IEnumerable<int> result = from person in Persons
                                                            group person by person.ID into groupId
                                                            where groupId.Count() > 1
                                                         select groupId.Key;

            IEnumerable<Person> res = from r in result 
                                        join person in Persons on r equals person.ID 
                                      select person;


            //IEnumerable<Person> res = from person in Persons
            //                            join person1 in Persons on person.ID equals person1.ID
            //                            where !ReferenceEquals(person, person1)
            //                          select person;

            //IEnumerable<Person> result = Persons
            //                                    .GroupBy(p => p.ID)
            //                                    .Where(i => i.Count() > 1)
            //                                    .Select(r => r)
            //                                    .SelectMany(p => p);

            return res;
        }

        //b) не должно быть персон с повторяющимися фамилиями и именами
        public IEnumerable<Person> GetInvalidPersons()
        {
            IEnumerable < IGrouping<string, Person> > result = from person in Persons
                                                                    group person by person.FirstName into name
                                                                    where name.Count() > 1
                                                               select name;

            IEnumerable<IGrouping<string, Person>> result1 = from person in Persons
                                                                group person by person.LastName into name
                                                                where name.Count() > 1
                                                            select name;

            var persons = result.SelectMany(p=>p).Concat(result1.SelectMany(p => p));

            return persons;
        }
        //b) не должно быть персон с повторяющимися фамилиями и именами
        public IEnumerable<Person> GetInvalidPersonsLastName()
        {
            IEnumerable<IGrouping<string, Person>> result = from person in Persons
                                                                group person by person.LastName into name
                                                                where name.Count() > 1
                                                            select name;

            return result.SelectMany(p => p);
        }

        //c) поле TeacherID(класс Group) не должно ссылаться на несуществующего преподавателя
        public IEnumerable<Group> GetInvalidGroups()
        {
            //IEnumerable<GroupTeacher> result = from @group in Groups
            //                                       join teacher in Teachers on
            //                                       @group.TeacherID equals teacher.ID
            //                                   select new GroupTeacher(@group, teacher);


            var teacherIDs = Groups
                    .Select(g => g.TeacherID)
                    .Except(from teacher in Teachers select teacher.ID);



            return from r in teacherIDs join g in Groups on r equals g.TeacherID select g;
        }

        //d) поле GroupID не должно ссылаться на несуществующую группу
        public IEnumerable<StudentGroup> GetInvalidStudents()
        {
            IEnumerable<StudentGroup> result = from student in Students
                                                    join @group in Groups on
                                                    student.GroupID equals @group.ID
                                               select new StudentGroup(student, @group);

            return result;
        }

        //e) поле RecordBookNumber должно быть уникальным
        public IEnumerable<Student> GetInvalidStudent()
        {
            IEnumerable<IGrouping<int, Student>> result = from student in Students
                                                                group student by student.RecordBookNumber into bookNumber
                                                                where bookNumber.Count() > 1
                                                          select bookNumber;

            return result.SelectMany(b => b);
        }

        // 2. Вывести студентов по куратору группы
        public IEnumerable<Student> GetStudentsByTeacher(int teacherId = -1)
        {
            IEnumerable<Student> studentsByTeacher = from teacher in _teachers
                                                   where teacher.ID == teacherId
                                                       join @group in _groups on teacher.ID equals @group.TeacherID
                                                       join student in _students on @group.ID equals student.GroupID 
                                                   select student;

            return studentsByTeacher;
        }

        // 3. Вывести полную информацию по связке<студент>-<группа>-<куратор>
        public IEnumerable<FullInfo> GetFullInfoByStudent()
        {
            IEnumerable<FullInfo> students = from student in _students
                                                  join @group in _groups on student.GroupID equals @group.ID
                                                  join teacher in _teachers on @group.TeacherID equals teacher.ID
                                             select new FullInfo(student.RecordBookNumber, student.FirstName +" "+ student.LastName, 
                                                  @group.GroupName, teacher.FirstName + " " + teacher.LastName);

            return students;
        }

        // 4a.Подсчёт количества студентов по каждой из групп
        public IEnumerable<GroupStud> GetStudentsAmountByGroups() 
        {
            IEnumerable<GroupStud> result = from student in Students
                                            join @group in Groups on student.GroupID equals @group.ID
                                            group @group by @group.GroupName into grp
                                            select new GroupStud(grp.Key, grp.Count()); // TODO: How Count() works? Why does it count values instead keys?

            //foreach (var grp in _groups)
            //{
            //    int amount = (from student in _students
            //                        where student.GroupID == grp.ID
            //                  select student).Count();

            //    yield return new GroupStud(grp.GroupName, amount);
            //}

            return result;
        }

        // b.Минимальное / Среднее / Максимальное количество студентов у каждого из кураторов групп
        public IEnumerable<StatisticTeacher> GetStatisticTeacher()
        {
            var result = from student in Students
                                                    join @group in Groups on student.GroupID equals @group.ID
                                                    join teacher in Teachers on @group.TeacherID equals teacher.ID
                                               group teacher by new { teacher.ID, teacher.FirstName, @group.GroupName }  into teachers
                                                   select new {teachers.Key.FirstName, teachers.Key.GroupName ,StudCount = teachers.Count()};
            

            return from r in result 
                    group result by r.FirstName into stat
                   select new StatisticTeacher(stat.Key, "GroupName", result.Min(d=>d.StudCount), result.Max(d=>d.StudCount), result.Average(d=>d.StudCount));
        }

        // 4c. "тезки"(имена) + количество повторений
        public IEnumerable<Namesakes> GetNamesakes()
        {
            //IEnumerable<Namesakes> result = from person in Persons
            //                  group person by person.FirstName into grp
            //                  where grp.Count() > 1
            //             select new Namesakes(grp.Key, grp.Count());

            IEnumerable<Namesakes> result = Persons
                                .GroupBy(p => p.FirstName)
                                .Where(p => p.Count() > 1)
                                .Select(group => new Namesakes(group.Key, group.Count()));

            return result;
        }
    }
}
