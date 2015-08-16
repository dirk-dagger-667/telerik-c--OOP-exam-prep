namespace SoftwareAcademyAndShit
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    public class Teacher : ITeacher
    {
        private IList<ICourse> courses;
        private string name;
        public Teacher(string name)
        {
            this.Name = name;
            this.Courses = new List<ICourse>();
        }
        public IList<ICourse> Courses
        {
            get;
            private set;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentNullException("the name of the teacher cannot be null or empty");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public void AddCourse(ICourse course)
        {
            this.Courses.Add(course);
        }

        public override string ToString()
        {
            var outputStringBuilder = new StringBuilder();
            outputStringBuilder.Append("Teacher : Name=" + this.Name);

            if (this.Courses.Count > 0)
            {
                outputStringBuilder.Append("; Courses=[");

                foreach (var course in this.Courses)
                {
                    outputStringBuilder.Append(course.Name + ", ");
                }

                return outputStringBuilder.ToString().TrimEnd(',', ' ') + "]";
            }

            return outputStringBuilder.ToString().TrimEnd(',', ' ');
        }
    }
}
