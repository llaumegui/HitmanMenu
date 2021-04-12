using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hitmune : MonoBehaviour
{
    Rigidbody _rb;
    public float Speed;
    public LayerMask Ennemy;

    float _xRotation = 0;
    public float MouseSensitivity = 100;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Rotation();

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);

        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    private void Shoot()
    {
        SoundManager.PlaySound(SoundManager.Sound.Gunshot, 2);

        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit, Mathf.Infinity,Ennemy))
        {
            Vector3 dir = -hit.normal;
            hit.collider.gameObject.TryGetComponent(out Rigidbody rb);
            Debug.Log(rb);

            rb.AddForce(dir * 1000, ForceMode.Impulse);
        }
    }

    private void Rotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90, 75);

        transform.Rotate(Vector3.up * mouseX);
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = base.transform.right * x + base.transform.forward * z;

        _rb.MovePosition(base.transform.position + move * Speed * Time.deltaTime);
    }
}
