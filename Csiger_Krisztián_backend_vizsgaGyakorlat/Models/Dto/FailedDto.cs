namespace Csiger_Krisztián_backend_vizsgaGyakorlat.Models.Dto
{
    public class FailedDto
    {

        public string Message { get; set; }

        public bool Isidentification { get; set; }

        public FailedDto() { }

        public FailedDto(string message) 
        {
            Message = message;
        }
    }
}
