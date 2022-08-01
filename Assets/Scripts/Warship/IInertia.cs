using UnityEngine;

namespace AsteroidsGame.Warship
{
    public interface IInertia
    {
        public Vector2 Acceleration { get; }
        public void Accelerate(Vector2 forward, float deltaTime);
        public void Slowdown(float deltaTime);
    }
}