﻿using UnityEngine;

public class CameraAnimate : MonoBehaviour {
    [SerializeField]
    private GameObject _player;
    private PlayerControl _controller;

    private Vector3 velocity = Vector3.zero;
    private Vector3 _offset;

    private float _xAmp, _xFrq, _yAmp, _yFrq;
    private float _t;

    void Start() {
        _controller = _player.GetComponent<PlayerControl>(); //Find Controller Class
    }

    void Update() {

        _t += Time.deltaTime;

        //Switch headbob values depending on type of movement
        if (_controller.isMoving) {
            _yFrq = 12;
            _yAmp = .1f;
            if (_controller.isCrouching) {
                _yFrq = 8;
                _yAmp = .05f;
            } else if (_controller.isSprinting) {
                _yFrq = 10;
                _yAmp = .1f;
            }
        } else {
            _yFrq = 0;
        }

        //Determine camera offset (for headbob)
        _offset = new Vector3(0, Mathf.Cos(_t * _yFrq) * _yAmp,0);

        //SmoothDamp towards target position + offset
        transform.position = Vector3.SmoothDamp(transform.position, _controller.cameraTarget + _offset, ref velocity,.08f);

    }
}
