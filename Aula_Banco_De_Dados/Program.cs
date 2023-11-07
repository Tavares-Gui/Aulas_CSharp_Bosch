using System;
using System.Linq;
using System.Threading.Tasks;
using Aula_Banco_De_Dados.Model;
using System.Collections.Generic;


//Creation of the data

AulaBcContext context = new AulaBcContext(); 


//Lists

List<Carro> Cars = new List<Carro>();
List<Funcionario> Employees = new List<Funcionario>();
List<Loja> Store = new List<Loja>();


//Tests of CREATE - UPDATE - DELETE

// await CreateCar();
// await UpdateCar();
// await DeleteCar();

// await CreateEmployee();
// await UpdateEmployee();
// await DeleteEmployee();

// await CreateStore();
// await UpdateStore();
// await DeleteStore();


GetCarList();
GetEmployeeList();
GetStoreList();


//CREATE - UPDATE - DELETE of the cars

async Task CreateCar(string model, string color, string plate)
{
    Carro car = new Carro();
    car.Modelo = model;
    car.Cor = color;
    car.Placa = plate;

    context.Carros.Add(car);
    await context.SaveChangesAsync();
}

async Task UpdateCar(int id, string model, string color, string plate)
{
    var car = context.Carros.FirstOrDefault(args => args.Id == id);

    if(car != null)
    {
        car.Modelo = model;
        await context.SaveChangesAsync();
    }
}

async Task DeleteCar(int id)
{
    var car = context.Carros.FirstOrDefault(args => args.Id == id);

    if(car != null)
    {
        context.Carros.Remove(car);
        await context.SaveChangesAsync();
    }
}

void GetCarList()
{
    var query =
        from carro in context.Carros
        select carro;

    foreach (var carrinho in query)
    {
        Console.WriteLine(carrinho.Modelo);
    }

}


//CREATE - UPDATE - DELETE of the employees

async Task CreateEmployee(string nome, int idade, int evd)
{
    Funcionario employee = new Funcionario();
    employee.Nome = nome;
    employee.Idade = idade;
    employee.Edv = evd;

    context.Funcionarios.Add(employee);
    await context.SaveChangesAsync();
}

async Task UpdateEmployee(string nome, int idade, int evd)
{
    var employee = context.Funcionarios.FirstOrDefault(args => args.Id == id);

    if(employee != null)
    {
        employee.Nome = nome;
        await context.SaveChangesAsync();
    }
}

async Task DeleteEmployee(int id)
{
    var employee = context.Funcionarios.FirstOrDefault(args => args.Id == id);

    if(employee != null)
    {
        context.Funcionarios.Remove(employee);
        await context.SaveChangesAsync();
    }
}

void GetEmployeeList()
{
    var query =
        from funcionario in context.Funcionarios
        select funcionario;

    foreach (var funcionariozinho in query)
    {
        Console.WriteLine(funcionariozinho.Nome);
    }

}


//CREATE - UPDATE - DELETE of the stores

async Task CreateStore(string nome, string endereco)
{
    Loja store = new Loja();
    store.Nome = nome;
    store.Endereco = endereco;

    context.Lojas.Add(store);
    await context.SaveChangesAsync();
}

async Task UpdateStore(string nome, string endereco)
{
    var store = context.Lojas.FirstOrDefault(args => args.Id == id);

    if(store != null)
    {
        store.Nome = nome;
        await context.SaveChangesAsync();
    }
}

async Task DeleteStore(int id)
{
    var store = context.Lojas.FirstOrDefault(args => args.Id == id);

    if(store != null)
    {
        context.Lojas.Remove(store);
        await context.SaveChangesAsync();
    }
}

void GetStoreList()
{
    var query =
        from loja in context.Lojas
        select loja;

    foreach (var lojinha in query)
    {
        Console.WriteLine(lojinha.Nome);
    }

}