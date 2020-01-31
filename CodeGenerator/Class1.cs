using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using CodeGenerator.generators;

namespace CodeGenerator
{
    class Class1
    {
        public static void Main(string[] args)
        {
            /*var emptyClassTree = simpleGenerator.CreateEmptyClass("GreetingBusinessRule");
            var emptyClass =
                emptyClassTree.GetRoot().DescendantNodes().
                    OfType<ClassDeclarationSyntax>().FirstOrDefault();
            if (emptyClass == null)
                return;
            Console.WriteLine(emptyClass.NormalizeWhitespace().ToString());

            var reference = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
            var compilation = CSharpCompilation.Create("internal")
                    .WithReferences(reference);
            var intType = compilation.GetTypeByMetadataName("System.Int32");
            var stringType = compilation.GetTypeByMetadataName("System.String");
            var dateTimeType = compilation.GetTypeByMetadataName("System.DateTime");

            emptyClass = emptyClass.AddProperty("Age", intType)
                                   .AddProperty("FirstName", stringType)
                                   .AddProperty("LastName", stringType)
                                   .AddProperty("DateOfBirth", dateTimeType)
                                   .NormalizeWhitespace();
            Console.WriteLine(emptyClass.ToString());*/

            GenerateSampleViewModel();

        }
        static void GenerateSampleViewModel()
        {
            const string models = @"namespace Models
            {
                public class Item
                {
                    public string ItemName { get; set; }
                }
            }";

            var node = CSharpSyntaxTree.ParseText(models).GetRoot();
            var viewModel = ViewModelGeneration.GenerateViewModel(node);
            if (viewModel != null)
                Console.WriteLine(viewModel.ToFullString());
            Console.ReadLine();
        }
        
    }
}
