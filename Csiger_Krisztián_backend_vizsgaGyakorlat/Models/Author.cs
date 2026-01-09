using System;
using System.Collections.Generic;

namespace Csiger_Krisztián_backend_vizsgaGyakorlat.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string? AuthorName { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
