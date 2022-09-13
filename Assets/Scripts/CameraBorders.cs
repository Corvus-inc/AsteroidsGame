using System.Collections;
using UnityEngine;

namespace Assets.Tools
{
    public class CameraBorders : MonoBehaviour
    {
        public Vector3 UpperRightInWorld { get; private set; }
        public Vector3 LeftLowerInWorld { get; private set; }
        
        private const float RateOfUpdateBorders = 0.3f;
        
        private Camera _currentCamera;
        private bool _stay = true;

        private void Start()
        {
            _currentCamera = Camera.main;
            StartCoroutine(CheckForTransfer());
        }

        private IEnumerator CheckForTransfer()
        {
            UpperRightInWorld = _currentCamera.ScreenToWorldPoint(new Vector3(_currentCamera.pixelWidth, _currentCamera.pixelHeight, 0));
            LeftLowerInWorld = _currentCamera.ScreenToWorldPoint(Vector3.zero);

            while (_stay)
            {
                if (UpperRightInWorld != _currentCamera.ScreenToWorldPoint(new Vector3(_currentCamera.pixelWidth, _currentCamera.pixelHeight, 0)))
                {
                    UpperRightInWorld = _currentCamera.ScreenToWorldPoint(new Vector3(_currentCamera.pixelWidth, _currentCamera.pixelHeight, 0));
                    LeftLowerInWorld = _currentCamera.ScreenToWorldPoint(Vector3.zero);
                    Debug.Log(UpperRightInWorld);
                }

                yield return new WaitForSeconds(RateOfUpdateBorders);
            }
        }

        private void OnDestroy()
        {
            _stay = false;
        }
    }
}