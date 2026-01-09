namespace Csiger_Krisztián_backend_vizsgaGyakorlat.Models.Dto
{
    public class FailedDto
    {
        public bool Failed { get; private set; } = true;

        public string Message { get; set; }

        public FailedDto() { }

        public FailedDto(string message) 
        {
            Message = message;
        }
    }
}
