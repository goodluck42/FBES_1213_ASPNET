namespace SignalRWebApplication
{
    public class ChatHistory
    {
        private readonly List<string> _history;

        public ChatHistory()
        {
            _history = new List<string>();
        }

        public List<string> GetHistory()
        {
            return _history;
        }

        public void AddToHistory(string historyData)
        {
            _history.Add(historyData);
        }
    }
}
