using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSettings
{
    public class PlayerInputController : IDisposable
    {
        public Vector2 RotateDirection { get; private set; }

        //Why have only phase Whiting  and Started? Where performed and Closed?
        public bool IsAccelerate => _accelerateAction.phase == InputActionPhase.Started;

        private PlayerInput _playerInput;
        
        private InputAction _accelerateAction;
        private InputAction _rotateAction;

        public PlayerInputController(PlayerInput playerInput)
        {
            _playerInput = playerInput;

            _accelerateAction = _playerInput.actions["Accelerate"];
            _rotateAction = _playerInput.actions["Rotate"];
            
            _rotateAction.performed += RotateInput;
            _rotateAction.canceled += RotateInput;
        }

        public void Dispose()
        {
            _rotateAction.performed -= RotateInput;
            _rotateAction.canceled -= RotateInput;
                
            _accelerateAction?.Dispose();
            _rotateAction?.Dispose();
        }
        private void RotateInput(InputAction.CallbackContext context)
        {
            RotateDirection = context.ReadValue<Vector2>();
        }
    }
}