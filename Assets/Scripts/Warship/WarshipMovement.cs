using System;
using System.Runtime.CompilerServices;
using Assets.Scripts;
using Assets.Tools;
using UnityEngine;

namespace AsteroidsGame.Warship
{
    public class WarshipMovement
    {
        private readonly Transform _warshipTransform;
        private CameraBorders _cameraBorders;
        private readonly Inertia _inertia;
        private Vector2 _position;


        private Vector2 Forward => _warshipTransform.rotation * Vector3.up;

        public Vector2 ForwardV2 => Trigonometry.UnityDegreeToVector2(_warshipTransform.rotation.z);

        public WarshipMovement(Transform warshipTransform, CameraBorders cameraBorders)
        {
            _cameraBorders = cameraBorders;
            _warshipTransform = warshipTransform;
            _inertia = new Inertia();
        }

        public void Move(bool isAccelerate)
        {
            if (isAccelerate)
            {
                _inertia.Accelerate(Forward, Time.deltaTime);
            }
            else
            {
                _inertia.Slowdown(Time.deltaTime);
            }


            var nextPosition = (_position + _inertia.Acceleration);

            nextPosition = MoveLooped(nextPosition);
            // nextPosition.x = Mathf.Repeat(nextPosition.x, 10);
            // nextPosition.y = Mathf.Repeat(nextPosition.y, 10);

            _position = nextPosition;

            _warshipTransform.position = _position;
        }

        public void WithoutInertiaMove()
        {
            var nextPosition = (_position + Forward * 0.03f);

            nextPosition.x = Mathf.Repeat(nextPosition.x, 10);
            nextPosition.y = Mathf.Repeat(nextPosition.y, 10);

            _position = nextPosition;

            _warshipTransform.position = _position - new Vector2(5, 5);
        }

        public void TryRotate(float direction)
        {
            if (direction != 0)
                MoveRotate(direction, 3);
        }

        private void MoveRotate(float direction, float speed)
        {
            if (direction == 0)
                throw new InvalidOperationException(nameof(direction));

            direction = direction > 0 ? 1 : -1;

            _warshipTransform.Rotate(new Vector3(0, 0, -direction * speed));
        }

        private Vector2 _velocity;
        private Vector2 _lastPosition;
        private float _lastDeltaTime;

        private void CalculateVelocity()
        {
            _velocity = ((Vector2) _position - _lastPosition) / _lastDeltaTime;
            _lastPosition = _position;
            _lastDeltaTime = Time.deltaTime;
        }

        private Vector2 MoveLooped(Vector2 nextPosition)
        {
            var rightBorder = _cameraBorders.UpperRightInWorld.x;
            var upperBorder = _cameraBorders.UpperRightInWorld.y;
            var leftBorder = _cameraBorders.LeftLowerInWorld.x;
            var downBorder = _cameraBorders.LeftLowerInWorld.y;
            
            if (_warshipTransform.position.x > rightBorder)
            {
                nextPosition.x = leftBorder;
            }

            if (_warshipTransform.position.x < leftBorder)
            {
                nextPosition.x = rightBorder;
            }

            if (_warshipTransform.position.y > upperBorder)
            {
                nextPosition.y = downBorder;
            }

            if (_warshipTransform.position.y < downBorder)
            {
                nextPosition.y = upperBorder;
            }

            return nextPosition;
        }
    }
}