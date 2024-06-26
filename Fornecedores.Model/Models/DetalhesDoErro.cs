﻿using System.Text.Json;

namespace Fornecedores.Model.Models;

public class DetalhesDoErro
{
    public int StatusCode { get; set; }
    public string Mensagem { get; set; }
    public object ObjetoErro { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
