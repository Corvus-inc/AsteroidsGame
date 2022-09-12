using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace AsteroidsGame.Warship
{
    public class Inertia : IInertia

    {
        private readonly float _unitsPerSecond = 0.05f;
        private readonly float _maxSpeed = 0.05f;
        private readonly float _secondsToStop = 1f;
        //TODO Added class Speed modifier
        private float _currentSpeed; 
        public Vector2 Acceleration { get; private set; }

        public void Accelerate(Vector2 forward, float deltaTime)
        {
            //Interpolated speed from zero
            var speed = Mathf.Lerp(_currentSpeed, _unitsPerSecond, 0.05f);
            _currentSpeed = speed;
            //Finding vector acceleration by direction and speed
            Acceleration += forward * (_currentSpeed * deltaTime);
            Acceleration = Vector2.ClampMagnitude(Acceleration, _maxSpeed);
        }

        public void Slowdown(float deltaTime)
        {
            _currentSpeed = 0;
            Acceleration -= Acceleration * (deltaTime / _secondsToStop);
        }
        
    }
}