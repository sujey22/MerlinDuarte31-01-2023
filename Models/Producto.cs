using System;
using System.Collections.Generic;

namespace MerlinDuarte23_03_23.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripción { get; set; }

    public decimal? Precio { get; set; }

    public int? Stock { get; set; }
}
