using System;
using System.Linq;
using System.Reflection;

Test.Run();

public class Operacoes
{
    public int Fatorial(int n)
    {
        if (n == 0)
            return 0;
        if (n == 1)
            return 1;
        
        return n * Fatorial(n - 1);
    }

    public int Fibonacci(int n)
    {
        if (n < 2)
            return 1;
        
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}

[ClassTest]
public class MyTests
{
    [MethodTest]
    public void TestFatorial()
    {
        Operacoes op = new Operacoes();
        Test.Assert(op.Fatorial(3), 6);
        Test.Assert(op.Fatorial(5), 120);
        Test.Assert(op.Fatorial(7), 5040);
    }

    [MethodTest]
    public void TestFibonacci()
    {
        Operacoes op = new Operacoes();
        Test.Assert(op.Fibonacci(2), 2);
        Test.Assert(op.Fibonacci(4), 5);
        Test.Assert(op.Fibonacci(6), 13);
        Test.Assert(op.Fibonacci(6), 14);
    }

    public void FuncVazia()
    {

    }
}