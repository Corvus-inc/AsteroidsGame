using UnityEngine;

namespace AsteroidsGame.Warship
{
    public class InertiaLerp:IInertia
    {
        private Vector2 _velocity;
        private float _lastTime;
        private Vector2 _lastPos;
        private Vector2 _lastDir;
        private Transform _warshipTransform;
        private float speed = 5;
        
        public Vector2 Acceleration { get; private set; }

        public void Init(Transform pos)
        {
            _warshipTransform = pos;
        }
        public void Accelerate(Vector2 forward, float deltaTime)
        {
            var position = _warshipTransform.position;
            float _speed;
            
            _velocity = ((Vector2)position - _lastPos) / _lastTime;
            _lastPos = position;
            _lastTime = Time.deltaTime;
            
            
            var currentHorizontalSpeed = new Vector2(_velocity.x, _velocity.y).magnitude;
            var speedOffset = 0.1f;
            
            var targetSpeed = speed;
            
            
            if (currentHorizontalSpeed < targetSpeed - speedOffset ||
                currentHorizontalSpeed > targetSpeed + speedOffset)
            {
                _speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * 1 /* * _playerInputController.RotateDirection.y*/,
                    Time.deltaTime * 1);


                _speed = Mathf.Round(_speed * 1000f) / 1000f;

                Acceleration = forward * _speed * deltaTime;
            }
            else
            {
                _speed = targetSpeed;
                Acceleration = forward * _speed * deltaTime;
            }
        }

        public void Slowdown(float deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }
}