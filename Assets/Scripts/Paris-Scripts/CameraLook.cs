﻿using UnityEngine;

/*
 * THIS SCRIPT IS ORIGINALLY FROM Jian-Kai Wang:
 * https://github.com/jiankaiwang/FirstPersonController
 */


public class CameraLook : MonoBehaviour
{
    [SerializeField]
    float sensitivity = 5.0f;
    [SerializeField]
    float smoothing = 2.0f;

    [SerializeField]
    private GameObject controller;

    private Vector2 mouseLook;
    private Vector2 smoothV;

    public bool UIViewMode;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {

        controller.GetComponent<PlayerControl>().disabled = UIViewMode;

        if (!UIViewMode) {
            var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

            smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
            smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
            mouseLook += smoothV * Time.deltaTime;

            mouseLook.y = Mathf.Clamp(mouseLook.y, -85, 90);

            transform.localEulerAngles = new Vector3(-mouseLook.y, mouseLook.x, 0);
            controller.transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }
        if (Input.GetKeyDown("tab")) {
            if (!UIViewMode) Cursor.lockState = CursorLockMode.None;
            else Cursor.lockState = CursorLockMode.Locked;
            UIViewMode = !UIViewMode;
        }

    }

}
