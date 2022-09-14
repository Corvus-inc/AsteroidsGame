using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace AsteroidsGame.Warship
{
    public class SlidersView : MonoBehaviour
    {
        [SerializeField] private Slider upperSpeed;
        [SerializeField] private Slider lowerSpeed;
        [SerializeField] private Slider maxSpeed;
        [SerializeField] private Slider secondToStop;
        
        [SerializeField] private Slider speedRotate;

        public Slider USpeed
        {
            get => upperSpeed;
            set => upperSpeed = value;
        }
        public Slider LSpeed 
        {
            get => lowerSpeed;
            set => lowerSpeed = value;
        }
        public Slider MaxSpeed 
        {
            get => maxSpeed;
            set => maxSpeed = value;
        }
        public Slider SecondToStop
        {
            get => secondToStop;
            set => secondToStop = value;
        }

        public Slider SpeedRotate
        {
            get => speedRotate;
            set => speedRotate = value;
        }
    }
}