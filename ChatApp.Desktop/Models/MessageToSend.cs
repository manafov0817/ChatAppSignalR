namespace ChatApp.Desktop.Models
{
    public class MessageToSend
    {
        public string? MessageText { get; set; }
        public string? SendTo { get; set; }
        public bool IsOut { get; set; }
    }
}
