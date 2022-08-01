using UnityEngine;

namespace AsteroidsGame.Warship
{
    public class Inertia : IInertia

    {
        private readonly float _unitsPerSecond = 0.04f;
        private readonly float _maxSpeed = 0.03f;
        private readonly float _secondsToStop = 1f;
        public Vector2 Acceleration { get; private set; }

        public void Accelerate(Vector2 forward, float deltaTime)
        {
            Acceleration += forward * (_unitsPerSecond * deltaTime);
            Acceleration = Vector2.ClampMagnitude(Acceleration, _maxSpeed);
        }

        public void Slowdown(float deltaTime)
        {
            Acceleration -= Acceleration * (deltaTime / _secondsToStop);
        }
        
    }
}