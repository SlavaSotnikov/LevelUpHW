namespace Sorter
{
    internal class TimeAnalizer
    {
        private int _start;
        private int _finish;

        public void SetStart(object sender, TimeEventArgs e)    
        {
            _start = e.Time;
        }

        public void SetFinish(object sender, TimeEventArgs e)
        {
            _finish = e.Time;
        }

        public int Total 
        { 
            get
            {
                return _finish - _start;
            }
        }
    }
}
