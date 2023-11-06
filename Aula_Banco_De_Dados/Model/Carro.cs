using System;
using System.Collections.Generic;

namespace Aula_Banco_De_Dados.Model;

public partial class Carro
{
    public int Id { get; set; }

    public string Modelo { get; set; } = null!;

    public string Cor { get; set; } = null!;

    public string Placa { get; set; } = null!;

    public virtual ICollection<Loja> Lojas { get; set; } = new List<Loja>();
}
