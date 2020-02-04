using CodeGenerator.generators;

namespace CodeGenerator
{
    class Class1
    {
        public static void Main(string[] args)
        {      
            GenerateSampleViewModel();
        }
        static void GenerateSampleViewModel()
        {
            //Modelo de la clase a crear
            const string model = @"namespace Models
            {
                public class Car
                {
                    public string carName { get; set; }
                }
            }";
            //crea archivos .cs (modelos, "nombreDelArchivo")
            FileGenerator.createFile(model, "carController");
        }
        
    }
}
