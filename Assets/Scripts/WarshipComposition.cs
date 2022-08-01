using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AsteroidsGame.Warship;
using InputSettings;
using UnityEngine.InputSystem;

public class WarshipComposition : MonoBehaviour
{
    [SerializeField] private WarshipView warshipView;
    [SerializeField] private PlayerInput playerInput;

    private Warship warship;
    private WarshipMovement _warshipMovement;
    private PlayerInputController _playerInputController;

    public void Construct()
    {
        var warshipTransform = warshipView.transform;
        
        _warshipMovement = new WarshipMovement(warshipTransform);
        _playerInputController = new PlayerInputController(playerInput);
        warship = new Warship(_warshipMovement, _playerInputController);

    }

    private void Update()
    {
        warship.Update();
    }
}
