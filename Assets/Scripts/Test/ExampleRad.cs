using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleRad : MonoBehaviour
{
   public float deg = 30.0F;

    void Start()
    {
        float rad = deg * Mathf.Deg2Rad;
        Debug.Log(deg + " degrees are equal to " + rad + " radians.");
        Debug.Log(deg + " degrees are equal to " + rad + " radians.");
    }
}
