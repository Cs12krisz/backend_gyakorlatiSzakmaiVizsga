using System;
using System.Collections.Generic;

namespace Csiger_Krisztián_backend_vizsgaGyakorlat.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
