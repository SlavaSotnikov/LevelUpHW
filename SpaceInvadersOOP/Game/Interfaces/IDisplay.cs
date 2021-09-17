namespace Game
{
    internal interface IDisplay
    {
        byte Life { get; set; }

        byte OldLife { get; set; }
        
        byte HP { get; set; }

        byte OldHP { get; set; }
    }
}
