using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Tools;
using UnityEngine;
using AsteroidsGame.Warship;
using InputSettings;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class WarshipComposition : MonoBehaviour
{
    [SerializeField] private WarshipView warshipView;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private CameraBorders cameraBorders;
    [SerializeField] private SlidersView sliders;
    [SerializeField] private StatsView _statsView;

    private Warship _warship;
    private WarshipMovement _warshipMovement;
    private WarshipMovementModel _warshipMovementModel;
    private PlayerInputController _playerInputController;
    private WarshipSliderController _warshipSliderController;
    private WarshipStatsController _statsController;

    public void Construct()
    {
        var warshipTransform = warshipView.transform;
        _warshipMovementModel = new WarshipMovementModel();
        
        _warshipMovement = new WarshipMovement(warshipTransform, cameraBorders, _warshipMovementModel);
        _playerInputController = new PlayerInputController(playerInput);
        _warship = new Warship(_warshipMovement, _playerInputController);

        _warshipSliderController = new WarshipSliderController(_warshipMovementModel, sliders);
        _statsController = new WarshipStatsController(_warshipMovementModel,_statsView);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            Debug.Log(_warshipMovementModel.MAXSpeed);
        }
        _warship.Update();
    }
}
