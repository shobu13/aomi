using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingBackground : MonoBehaviour {

    public float backgroundSize;
    public float paralaxSpeed;

    private Transform _cameraTransform;
    private Transform[] _layers;
    private float _viewZone = 10;
    private int _leftIndex;
    private int _rightIndex;
    private float _lastCameraX;

    private void Start()
    {
        _cameraTransform = Camera.main.transform;
        _lastCameraX = _cameraTransform.position.x;
        _layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            _layers[i] = transform.GetChild(i);
        }

        _leftIndex = 0;
        _rightIndex = _layers.Length - 1;
    }

    private void Update()
    {
        float deltaX = _cameraTransform.position.x - _lastCameraX;
        transform.position += new Vector3(deltaX * paralaxSpeed, 0, 0);
        _lastCameraX = _cameraTransform.position.x;

        if (_cameraTransform.position.x < (_layers[_leftIndex].transform.position.x + _viewZone))
            ScrollLeft();

        if (_cameraTransform.position.x > (_layers[_rightIndex].transform.position.x - _viewZone))
            ScrollRight();
    }

    private void ScrollLeft()
    {
        int lastRight = _rightIndex;
        _layers[lastRight].position = new Vector3((_layers[_leftIndex].position.x - backgroundSize), _layers[_leftIndex].position.y, 0);
        _leftIndex = _rightIndex;
        _rightIndex--;
        if (_rightIndex < 0)
            _rightIndex = _layers.Length - 1;
    }

    private void ScrollRight()
    {
        int lastLeft = _leftIndex;
        _layers[lastLeft].position = new Vector3((_layers[_rightIndex].position.x + backgroundSize), _layers[_rightIndex].position.y, 0);
        _rightIndex = _leftIndex;
        _leftIndex++;
        if (_leftIndex >= _layers.Length)
            _leftIndex = 0;
    }
}
