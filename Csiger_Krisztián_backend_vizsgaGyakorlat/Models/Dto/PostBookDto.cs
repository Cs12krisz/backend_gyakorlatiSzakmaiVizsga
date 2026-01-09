namespace Csiger_Krisztián_backend_vizsgaGyakorlat.Models.Dto
{
    public class PostBookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
