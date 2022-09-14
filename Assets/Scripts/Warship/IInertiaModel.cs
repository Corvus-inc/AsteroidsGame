namespace AsteroidsGame.Warship
{
    public interface IInertiaModel
    {
        public float UpperAccelerationSpeed { get; }
        public float LowerAccelerationSpeed { get; }
        public float MAXSpeed { get; }
        public float SecondsToStop { get; }
    }
}