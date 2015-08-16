namespace SoftwareAcademyAndShit
{
    using System;
    using System.Text;
    public class LocalCourse: Course, ILocalCourse
    {
        private string lab;
        public LocalCourse(string name, ITeacher teacher, string lab)
            :base(name, teacher)
        {
            this.Lab = lab;
        }
        public string Lab
        {
            get
            {
                return this.lab;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentNullException("the lab cannot be null or empty");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (this.Lab != null)
            {
                sb.Append(base.ToString() + " Lab=" + this.Lab);
            }
            
            return sb.ToString();
        }
    }
}
