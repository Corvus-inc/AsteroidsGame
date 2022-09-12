using System;
using Assets.Scripts;
using UnityEngine;

namespace AsteroidsGame.Warship
{
    public class WarshipMovement
    {
        private readonly Transform _warshipTransform;
        private readonly Inertia _inertia;
        private Vector2 _position;


        private Vector2 Forward => _warshipTransform.rotation * Vector3.up;
        
        public Vector2 ForwardV2 => Trigonometry.UnityDegreeToVector2(_warshipTransform.rotation.z);
        
        public WarshipMovement(Transform warshipTransform)
        {
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
            var nextPosition = (_position + Forward * 0.03f );

            nextPosition.x = Mathf.Repeat(nextPosition.x, 10);
            nextPosition.y = Mathf.Repeat(nextPosition.y, 10);

            _position = nextPosition;

            _warshipTransform.position = _position - new Vector2(5, 5);
        }

        public void TryRotate(float direction)
        {
            if (direction != 0)
                MoveRotate(direction, 1);
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
            Vector3 upCameraWorldPosition;
            Vector3 downCameraWorldPosition;

            var mainCamera = Camera.main;
            upCameraWorldPosition =
                Camera.main.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth, mainCamera.pixelHeight, 0));
            downCameraWorldPosition=     
                Camera.main.ScreenToWorldPoint(new Vector3( upCameraWorldPosition.x-upCameraWorldPosition.x*2, upCameraWorldPosition.y-upCameraWorldPosition.y*2, 0));

            // nextPosition.x = Mathf.Repeat(nextPosition.x, upCameraWorldPosition.x);
            // nextPosition.y = Mathf.Repeat(nextPosition.y, upCameraWorldPosition.y);
            
            if (_warshipTransform.position.x  > upCameraWorldPosition.x)
            {
                nextPosition.x = downCameraWorldPosition.x;
            }
            
            if (_warshipTransform.position.x < downCameraWorldPosition.x)
            {
                nextPosition.x = upCameraWorldPosition.x;
            }
            
            if (_warshipTransform.position.y > upCameraWorldPosition.y)
            {
                nextPosition.y = downCameraWorldPosition.y;
            }
            
            if (_warshipTransform.position.y < downCameraWorldPosition.y)
            {
                nextPosition.y = upCameraWorldPosition.y;
            }

            // var fromCamPosition = Camera.main.WorldToScreenPoint(_warshipTransform.position);
                        // if (fromCamPosition.x < 0)
                        // {
                        //     var t = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth,
                        //         fromCamPosition.y, 0));
                        //     nextPosition.x =  t.x;
                        // }
                        // if (fromCamPosition.x > Camera.main.pixelWidth)
                        // {
                        //     var t = Camera.main.ScreenToWorldPoint(new Vector3(0,
                        //         fromCamPosition.y, 0));
                        //     nextPosition.x = t.x;
                        // }
                        
                        // if (fromCamPosition.y < 0)
                        // {
                        //     var t = Camera.main.ScreenToWorldPoint(new Vector3(
                        //         fromCamPosition.x, Camera.main.pixelHeight,0));
                        //     nextPosition.y = t.y;
                        // }
                        // if (fromCamPosition.y > Camera.main.pixelHeight)
                        // {
                        //     var t = Camera.main.ScreenToWorldPoint(new Vector3(
                        //         fromCamPosition.x, 0,0));
                        //     nextPosition.y = t.y;
                        // }
                        
            return nextPosition;
        }
    }
}