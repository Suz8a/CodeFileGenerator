using Microsoft.CodeAnalysis.CSharp;
using System;
using System.IO;

namespace CodeGenerator.generators
{
    class FileGenerator
    {
        public static void createFile(string model, string fileName)
        {
            //GenerateCode
            var node = CSharpSyntaxTree.ParseText(model).GetRoot();
            var viewModel = ViewModelGeneration.GenerateViewModel(node).ToFullString();
            string path = @$"C:\{fileName}.cs";

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                // Create a new file with the code generated   
                using (StreamWriter sw = File.CreateText(path))
                {
                    //Add code to file
                    sw.WriteLine(viewModel);
                }
                Console.WriteLine("Archivo creado");
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
    }
}
