namespace Game
{
    internal interface IUserShip
    {
        byte Life { get; set; }

        byte OldLife { get; set; }
        
        byte HP { get; set; }

        byte OldHP { get; set; }
    }
}
