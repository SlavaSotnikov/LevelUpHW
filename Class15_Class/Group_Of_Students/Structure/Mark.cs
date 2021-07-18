using System;

namespace Group_Of_Students
{
    struct Mark
    {
        #region Private Data

        private string _subject;
        private DateTime _date;
        private byte _rate;

        #endregion

        #region Properties

        public string Subject
        {
            get
            {
                return _subject;
            }
            set
            {
                _subject = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }

        public byte Rate
        {
            get
            {
                return _rate;
            }
            set
            {
                _rate = value;
            }
        }

        #endregion

        #region Constructors

        public Mark(string subject, DateTime date, byte value)
        {
            _subject = subject;
            _date = date;
            _rate = value;
        }

        public Mark(Mark source)
            :this(source._subject, source._date, source._rate)
        {
            
        }
       
        #endregion
    }
}
