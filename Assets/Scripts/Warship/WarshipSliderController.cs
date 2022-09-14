using System.Collections.Generic;
using UnityEngine.UI;

namespace AsteroidsGame.Warship
{
    public class WarshipSliderController
    {
        private readonly WarshipMovementModel _model;
        private readonly SlidersView _slidersView;

        public WarshipSliderController(WarshipMovementModel model, SlidersView sliders)
        {
            _model = model;
            _slidersView = sliders;

            _slidersView.LSpeed.value = model.LowerAccelerationSpeed;
            _slidersView.LSpeed.onValueChanged.AddListener(_model.SetLowerSpeed);
            
            _slidersView.USpeed.value = model.UpperAccelerationSpeed;
            _slidersView.USpeed.onValueChanged.AddListener(_model.SetUpperSpeed);
            
            _slidersView.MaxSpeed.value = model.MAXSpeed;
            _slidersView.MaxSpeed.onValueChanged.AddListener(_model.SetMAXSpeed);
            
            _slidersView.SecondToStop.value = model.SecondsToStop;
            _slidersView.SecondToStop.onValueChanged.AddListener(_model.SetSecondToStop);
            
            _slidersView.SpeedRotate.value = model.SpeedRotate;
            _slidersView.SpeedRotate.onValueChanged.AddListener(_model.SetSpeedRotate);
            
             
        }

        private void MyAction(float speed)
        {
            
        }
    }
}