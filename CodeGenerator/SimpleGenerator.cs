using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;

namespace CodeGenerator
{
    static class simpleGenerator
    { 
        public static SyntaxTree CreateEmptyClass(string className)
        {
        var code = @"
            public class Class1
            {
            }";
        var syntaxTree = CSharpSyntaxTree.ParseText(code);
        var identifierToken = syntaxTree.GetRoot().DescendantTokens()
                              .First(t => t.IsKind(SyntaxKind.IdentifierToken)
                               && t.Parent.Kind() == SyntaxKind.ClassDeclaration);
        var newIdentifier = SyntaxFactory.Identifier(className);
        return SyntaxFactory.SyntaxTree(syntaxTree.GetRoot()
                            .ReplaceToken(identifierToken, newIdentifier));


         }
        public static ClassDeclarationSyntax AddProperty(this ClassDeclarationSyntax currentClass, string name, INamedTypeSymbol type)
        {
            if(currentClass.DescendantNodes().OfType<PropertyDeclarationSyntax>().Any(p => p.Identifier.Text == name))
            {
                //class already has the specified property
                return currentClass;
            }
            var typeSentax = SyntaxFactory.ParseTypeName(type.Name);
            var newProperty = SyntaxFactory.PropertyDeclaration(typeSentax, name)
                .WithModifiers(
                    SyntaxFactory.TokenList(
                        SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                .WithAccessorList(
                    SyntaxFactory.AccessorList(SyntaxFactory.List(new[]
                    {
                        SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                            .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                        SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                            .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
                    })));
            return currentClass.AddMembers(newProperty);
        }
    }
}
