using System;
using System.Collections;
using System.Collections.Generic;
using InputSettings;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Assets.Scripts;
using UnityEditor;

namespace AsteroidsGame.Warship
{
    public class WarshipView : MonoBehaviour
    {
        [SerializeField] private float upperAccelerationSpeed = 0.1f;
        [SerializeField] private float lowerAccelerationSpeed = 0.1f;
        [SerializeField] private float maxSpeed = 0.1f;
        [SerializeField] private float secondsToStop = 1f;
        [SerializeField] private float speedRotate = 3f;
        public float UpperAccelerationSpeed => upperAccelerationSpeed;
        public float LowerAccelerationSpeed => lowerAccelerationSpeed;
        public float MaxSpeed => maxSpeed;
        public float SecondsToStop => secondsToStop;
        public float SpeedRotate => speedRotate;
        
    }
}