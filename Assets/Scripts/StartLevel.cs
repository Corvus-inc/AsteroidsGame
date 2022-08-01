using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    [SerializeField] private WarshipComposition _warshipComposition;
    private void Awake()
    {
        _warshipComposition.Construct();
    }
}
