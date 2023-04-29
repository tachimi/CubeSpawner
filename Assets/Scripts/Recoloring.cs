using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class Recoloring : MonoBehaviour
{
    [SerializeField] private float _recoloringDuration = 2f;
    [SerializeField] private float _colorChangeTime = 2f;

    private Color _startColor;
    private Color _nextColor;
    private Renderer _renderer;

    private float _currentTime;
    private float _timer;

    private bool _isUpdating = true;

    private void Awake()
    {
        _timer = _colorChangeTime;
        _renderer = GetComponent<Renderer>();
        GenerateNextColor();
    }


    private void GenerateNextColor()
    {
        _startColor = _renderer.material.color;
        _nextColor = Random.ColorHSV(0f, 1f, 0.8f, 1f, 1f, 1f);
    }

    private void Update()
    {
        if (_isUpdating)
        {
            _currentTime += Time.deltaTime;
            var progress = _currentTime / _recoloringDuration;
            var currentColor = Color.Lerp(_startColor, _nextColor, progress);
            _renderer.material.color = currentColor;
            if (_currentTime >= _recoloringDuration)
            {
                _currentTime = 0f;
                StopUpdating();
            }
        }
        else
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                _isUpdating = true;
                _timer = _colorChangeTime;
                GenerateNextColor();
            }
        }
    }

    private void StopUpdating()
    {
        _isUpdating = false;
    }
}