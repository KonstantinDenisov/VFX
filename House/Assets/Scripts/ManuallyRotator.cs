using UnityEngine;

public class ManuallyRotator : MonoBehaviour
    {
        [SerializeField] private float _sensitivityRotation;
        [SerializeField] private Transform _transform;
        private float _currentSpeed;
        private bool _isLeft;
        private bool _isPressed;
        private int _direction;

        private void Start()
        {
            _currentSpeed = 0;
        }

        private void Update()
        {
            UpdateButtonsState();
            Rotate();
        }

        private void UpdateButtonsState()
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                _isPressed = true;

            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
                _isPressed = false;

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _isLeft = true;
                _direction = 1;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                _isLeft = false;
                _direction = -1;
            }
        }

        private void Rotate()
        {
            if (_isPressed)
                _currentSpeed = _sensitivityRotation;

            else
                _currentSpeed = Mathf.Lerp(_currentSpeed, 0, Time.deltaTime);

            _transform.Rotate(0, _currentSpeed * Time.deltaTime * _direction, 0);
        }
    }
