namespace CORE_PintPoint.Entities
{
    public class MailData
    {
        public string ToId { get; set; }
        public string ToName { get; set; }
        public string Subject { get; set; }
        public string HTMLBody { get; set; } = "";
        public string TextBody { get; set; } = "";
    }
}
