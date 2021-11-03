namespace Queue
{
    interface IQueue<T>
    {
        void Add(T source);

        T Get();

        bool IsEmpty();

        bool IsFool();
    }
}
