using System;
using System.Collections.Generic;

namespace Aula_Banco_De_Dados.Model;

public partial class Funcionario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public int Idade { get; set; }

    public int Edv { get; set; }

    public virtual ICollection<Loja> Lojas { get; set; } = new List<Loja>();
}
