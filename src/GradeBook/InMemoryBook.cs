using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class InMemoryBook : Book
    {
        private List<double> grades;
        // public string Name
        // {
        //     get;
        //     private set;
        // }
        // readonly string category = "Science";
        public const string CATEGORY = "Science";
        private string name;

        /*
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    name = value;
                }
            }
        }
        */

        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)} was introduced: {grade}");
            }
        }

        public override  event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            /*
            foreach (var grade in grades)
            {
                if (grade == 42.1)
                {
                    break;
                }
                if (grade == 4.21)
                {
                    // skip over this
                    continue;
                }
            }
            */
            for (var index = 0; index < grades.Count; index++)
            {
                result.Add(grades[index]);
            }
            
            return result;
        }
    }
}