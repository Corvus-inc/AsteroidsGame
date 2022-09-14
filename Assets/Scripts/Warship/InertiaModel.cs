namespace AsteroidsGame.Warship
{
    public class InertiaModel : IInertiaModel
    {
        public float UpperAccelerationSpeed { get; private set; }
        public float LowerAccelerationSpeed { get; private set; }
        public float MAXSpeed { get; private set; }
        public float SecondsToStop { get; private set; }
    }
}