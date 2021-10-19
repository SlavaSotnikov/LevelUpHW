namespace SpaceInvadersDLL
{
    public class Shot : SpaceCraft
    {
        #region Constructors

        public Shot(int x, int y, sbyte step, uint speed,
                int oldX = 0, int oldY = 0, uint counter = 0)
        {
            X = x;
            Y = y;
            OldX = oldX;
            OldY = oldY;
            Speed = speed;
            Counter = counter;
            Active = true;
            _step = step;
        }

        #endregion

        #region Methods

        public override void Do(Action source)
        {
            Y -= _step;
        }

        #endregion
    }
}
