using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Tools;
using UnityEngine;
using AsteroidsGame.Warship;
using InputSettings;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class WarshipComposition : MonoBehaviour
{
    [SerializeField] private WarshipView warshipView;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private CameraBorders cameraBorders;

    private Warship warship;
    private WarshipMovement _warshipMovement;
    private PlayerInputController _playerInputController;

    public void Construct()
    {
        var warshipTransform = warshipView.transform;
        
        _warshipMovement = new WarshipMovement(warshipTransform, cameraBorders);
        _playerInputController = new PlayerInputController(playerInput);
        warship = new Warship(_warshipMovement, _playerInputController);

    }

    private void Update()
    {
        warship.Update();
    }
}
