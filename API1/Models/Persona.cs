using System;
using System.Collections.Generic;

namespace API1.Models;

public partial class Persona
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Edad { get; set; }
}
