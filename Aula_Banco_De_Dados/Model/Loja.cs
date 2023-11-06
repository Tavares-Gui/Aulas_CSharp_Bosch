using System;
using System.Collections.Generic;

namespace Aula_Banco_De_Dados.Model;

public partial class Loja
{
    public int Id { get; set; }

    public int Carro { get; set; }

    public int Funcionario { get; set; }

    public string? Nome { get; set; }

    public string? Endereco { get; set; }

    public virtual Carro CarroNavigation { get; set; } = null!;

    public virtual Funcionario FuncionarioNavigation { get; set; } = null!;
}
