using System;
using System.Collections;
using System.Collections.Generic;
using InputSettings;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Assets.Scripts;

namespace AsteroidsGame.Warship
{
    public class Warship
    {
        private readonly WarshipMovement _warshipMovement;
        private readonly PlayerInputController _playerInputController;
        private readonly StateMovement _stateMovement;
        
        public Warship(WarshipMovement warshipMovement, PlayerInputController playerInputController)
        {
            _warshipMovement = warshipMovement;
            _playerInputController = playerInputController;

            _stateMovement = StateMovement.ClassicMove;
        }

        public void Update()
        {
            _warshipMovement.TryRotate(_playerInputController.RotateDirection.x);

            switch (_stateMovement)
            {
                case StateMovement.ClassicMove:
                    _warshipMovement.Move(_playerInputController.IsAccelerate);
                    break;
                case StateMovement.WithoutInertiaMove:
                    if(_playerInputController.IsAccelerate)
                        _warshipMovement.WithoutInertiaMove();
                    break;
                default: Debug.LogWarning("Warship do not have state!");
                    if(_playerInputController.IsAccelerate)
                        _warshipMovement.WithoutInertiaMove();
                    break;
            }
        }
        
        private enum StateMovement
        {
            ClassicMove,
            WithoutInertiaMove
        }
       
    }
}