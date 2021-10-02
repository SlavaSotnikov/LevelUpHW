namespace Sorter
{
    public class TimeEventArgs
    {
        public string Text { get; private set; }
        public int Time { get; private set; }

        public TimeEventArgs(string s, int time)
        {
            Text = s;
            Time = time;
        }
    }
}
