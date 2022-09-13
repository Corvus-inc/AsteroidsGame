// Draw a yellow sphere at top-right corner of the near plane
// for the selected camera in the Scene view.

using System;
using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    private void OnRectTransformDimensionsChange()
    {
        Debug.Log("Change");
    }
}