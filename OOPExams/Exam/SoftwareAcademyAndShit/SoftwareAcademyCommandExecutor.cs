namespace SoftwareAcademyAndShit
{
    using Microsoft.CSharp;
    using System;
    using System.CodeDom.Compiler;
    using System.Reflection;
    using System.Text;
    public class SoftwareAcademyCommandExecutor
    {
        static void Main()
        {
            CourseFactory factory = new CourseFactory();
            ITeacher nakov = factory.CreateTeacher("Nakov");
            Console.WriteLine(nakov);
            nakov.Name = "Svetlin Nakov";
            ICourse oop = factory.CreateLocalCourse("OOP", nakov, "Light");
            oop.AddTopic("Using Classes and Objects");
            oop.AddTopic("Defining Classes");
            oop.AddTopic("OOP Principles");
            oop.AddTopic("Teamwork");
            oop.AddTopic("Exam Preparation");
            Console.WriteLine(oop);
            ICourse html = factory.CreateOffsiteCourse("HTML", nakov, "Plovdiv");
            html.AddTopic("Using Classes and Objects");
            html.AddTopic("Defining Classes");
            html.AddTopic("OOP Principles");
            html.AddTopic("Teamwork");
            html.AddTopic("Exam Preparation");
            Console.WriteLine(html);
            nakov.AddCourse(oop);
            nakov.AddCourse(html);
            Console.WriteLine(nakov);
            oop.Name = "Object-Oriented Programming";
            (oop as ILocalCourse).Lab = "Enterprise";
            oop.Teacher = factory.CreateTeacher("George Georgiev");
            oop.AddTopic("Practical Exam");
            Console.WriteLine(oop);
            html.Name = "HTML Basics";
            (html as IOffsiteCourse).Town = "Varna";
            html.Teacher = oop.Teacher;
            html.AddTopic("Practical Exam");
            Console.WriteLine(html);
            ICourse css = factory.CreateLocalCourse("CSS", null, "Ultimate");
            Console.WriteLine(css);

            //string csharpCode = ReadInputCSharpCode();
            //CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using SoftwareAcademyAndShit;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}
