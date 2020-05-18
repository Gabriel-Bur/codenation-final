namespace Domain.Core.Entity
{
    public class Error : BaseEntity
    {
        public enum ErrorLevel
        {
            Error = 0,
            Warning = 1,
            Debug = 2,
        }
         public enum ErrorStage
        {
            Production = 0,
            Homolog = 1,
            Dev = 2
        }

        public ErrorLevel Level { get; set; }
        public ErrorStage Stage { get; set; }
        public string Log { get; set; }
    }
}
