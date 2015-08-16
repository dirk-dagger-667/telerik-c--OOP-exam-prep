namespace SoftwareAcademyAndShit
{
    using System;
    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            return new Teacher(name);
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            var result = new LocalCourse(name, teacher, lab);
            return result;
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            var result = new OffsiteCourse(name, teacher, town);
            return result;
        }
    }
}
