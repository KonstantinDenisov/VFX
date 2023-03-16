using System;
using UnityEngine;

public class Rotator : MonoBehaviour
    {
        [SerializeField] private float _sensitivityRotation;
        [SerializeField] private Transform _transform;

        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _transform.Rotate(0, _sensitivityRotation * Time.deltaTime, 0);
            }
        
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                _transform.Rotate(0, _sensitivityRotation * Time.deltaTime * -1, 0);
            }
        }
    }
