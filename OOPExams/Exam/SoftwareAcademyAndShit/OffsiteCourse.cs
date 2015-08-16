namespace SoftwareAcademyAndShit
{
    using System;
    using System.Text;
    public class OffsiteCourse: Course, IOffsiteCourse
    {
        private string town;
        public OffsiteCourse(string name, ITeacher teacher, string town)
            :base(name, teacher)
        {
            this.Town = town;
        }
        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentNullException("the town cannot be null or empty");
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (this.Town != null)
            {
                sb.Append(base.ToString() + " Town=" + this.Town);
            }
            
            return sb.ToString();
        }
    }
}
