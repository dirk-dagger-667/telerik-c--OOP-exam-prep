namespace SoftwareAcademyAndShit
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    public abstract class Course : ICourse
    {
        private IList<string> topics;
        private string name;
        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.topics = new List<string>();
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
                    throw new ArgumentNullException("the name of the course cannot be empty or null");
                }

                this.name = value;
            }
        }

        public ITeacher Teacher
        {
            get;
            set;
        }

        public void AddTopic(string topic)
        {
            if (topic == string.Empty)
            {
                throw new ArgumentNullException("a topic cannot be null or empty");
            }

            this.topics.Add(topic);
        }

        public override string ToString()
        {
            var outputStringBuilder = new StringBuilder();

            if (this.Name != null)
            {
                outputStringBuilder.Append(this.GetType().Name + ": Name=" + this.Name + ";");
            }
            if (this.Teacher != null)
            {
                outputStringBuilder.Append(" Teacher=" + this.Teacher.Name + ";");
            }
            if (this.topics.Count > 0)
            {
                outputStringBuilder.Append(" Topics=[");

                foreach (var topic in topics)
                {
                    outputStringBuilder.Append(topic + ", ");
                }

                return outputStringBuilder.Replace(outputStringBuilder.ToString(), outputStringBuilder.ToString().TrimEnd(' ', ',')).ToString() + "]; ";
            }
            
            return outputStringBuilder.Replace(outputStringBuilder.ToString(), outputStringBuilder.ToString().TrimEnd(' ', ',')).ToString();
        }
    }
}
