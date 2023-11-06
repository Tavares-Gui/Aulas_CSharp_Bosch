using System;
using System.Reflection;
using System.Linq;

public static class Test
{
    private static string function = "";
    private static bool hasError = false;

    public static void Assert(object value, object expected)
    {
        if (value.Equals(expected))
            return;
        
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"""
            Erro na função {function}.
            Valor experado {expected} porém obtido {value}.

        """);
        hasError = true;
    }

    public static void Run()
    {
        var assembly = Assembly.GetCallingAssembly();
        var types = assembly.GetTypes();
        var searchClass = 
            from type in types
            where type.GetCustomAttribute<ClassTestAttribute>() is not null
            select type;

        foreach (var type in searchClass)
        {
            var methods = type.GetMethods();
            var obj = Activator.CreateInstance(type);

            foreach (var method in methods)
            {
                if (method.GetCustomAttribute<MethodTestAttribute>() is null)
                    continue;

                hasError = false;
                function = method.Name;
                method.Invoke(obj, new object[] { });
                if (hasError)
                    continue;
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Test {function} aprovado!");
            }
        }

            
    }
}

public class ClassTestAttribute : Attribute { }

public class MethodTestAttribute : Attribute { }