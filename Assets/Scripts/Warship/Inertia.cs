using System;
using Unity.Mathematics;
using UnityEngine;

namespace AsteroidsGame.Warship
{
    public class Inertia : IInertia
    {
        public Vector2 Acceleration { get; private set; }
        public float CurrentSpeed => _currentSpeed;

        private readonly IInertiaModel _model;
        
        private float UpperAccelerationSpeed => _model.UpperAccelerationSpeed;
        private float LowerAccelerationSpeed =>_model.LowerAccelerationSpeed;
        private float MAXSpeed =>_model.MAXSpeed;
        private float SecondsToStop => _model.SecondsToStop;
        
        private float _currentSpeed;

        public Inertia(IInertiaModel model)
        {
            _model = model;
        }
        public void Accelerate(Vector2 forward, float deltaTime)
        {
            //Interpolated speed from zero
            var speed = Mathf.Lerp(_currentSpeed, UpperAccelerationSpeed, LowerAccelerationSpeed);
            _currentSpeed = speed;
            //Finding vector acceleration by direction and speed
            Acceleration += forward * (_currentSpeed * deltaTime);
            Acceleration = Vector2.ClampMagnitude(Acceleration, MAXSpeed);
        }

        public void Slowdown(float deltaTime)
        {
            _currentSpeed = 0;
            Acceleration -= Acceleration * (deltaTime / SecondsToStop);
        }

        // public void ChangeInertia(float upperAccelerationSpeed, float lowerAccelerationSpeed, float maxSpeed,
        //     float secondsToStop)
        // {
        //     _upperAccelerationSpeed = upperAccelerationSpeed;
        //     _lowerAccelerationSpeed = lowerAccelerationSpeed;
        //     _maxSpeed = maxSpeed;
        //     _secondsToStop = secondsToStop;
        // }
    }
}