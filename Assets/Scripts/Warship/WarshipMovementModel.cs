namespace AsteroidsGame.Warship
{
    public class WarshipMovementModel : IInertiaModel
    {
        private const float UPPER_SPEED = 0.1f;
        private const float LOWER_SPEED = 0.1f;
        private const float MAX_SPEED = 0.1f;
        private const float SECOND_TO_STOP = 1f;
        
        private const float SPEED_ROTATE = 3;
        public WarshipMovementModel()
        {
            //default settings
            UpperAccelerationSpeed = UPPER_SPEED ;
            LowerAccelerationSpeed = LOWER_SPEED;
            MAXSpeed = MAX_SPEED;
            SecondsToStop = SECOND_TO_STOP;

            SpeedRotate = SPEED_ROTATE;
        }

        public float UpperAccelerationSpeed { get; private set; }
        public float LowerAccelerationSpeed { get; private set; }
        public float MAXSpeed { get; private set; }
        public float SecondsToStop { get; private set; }
        
        public float SpeedRotate { get; private set; }

        public float CurrentSpeed { get; set; }
        
        public void SetUpperSpeed(float speed)
        {
            UpperAccelerationSpeed = speed;
        }

        public void SetLowerSpeed(float speed)
        {
            LowerAccelerationSpeed = speed;
        }

        public void SetMAXSpeed(float speed)
        {
            MAXSpeed = speed;
        }

        public void SetSecondToStop(float second)
        {
            SecondsToStop = second;
        }

        public void SetSpeedRotate(float speed)
        {
            SpeedRotate = speed;
        }
    }
}