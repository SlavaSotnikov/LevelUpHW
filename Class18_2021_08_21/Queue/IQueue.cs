namespace Queue
{
    interface IQueue
    {
        void Add(object source);

        object Get();

        bool IsEmpty();

        bool IsFool();
    }
}
