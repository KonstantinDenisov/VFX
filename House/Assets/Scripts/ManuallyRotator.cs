using System;
using UnityEngine;

public class ManuallyRotator : MonoBehaviour
    {
        [SerializeField] private float _sensitivityRotation;
        [SerializeField] private Transform _transform;
        private float _currentSpeed;

        private void Start()
        {
            _currentSpeed = 0;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _currentSpeed = Mathf.Lerp(_currentSpeed, _sensitivityRotation, Time.deltaTime);
                _transform.Rotate(0, _currentSpeed * Time.deltaTime, 0);
            }
        
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                _currentSpeed = Mathf.Lerp(_currentSpeed, _sensitivityRotation, Time.deltaTime);
                _transform.Rotate(0, _currentSpeed * Time.deltaTime * -1, 0);
            }

            else
            {
                _currentSpeed = Mathf.Lerp(_currentSpeed, 0, Time.deltaTime);
                _transform.Rotate(0, _currentSpeed * Time.deltaTime, 0);
            }
        }
    }
