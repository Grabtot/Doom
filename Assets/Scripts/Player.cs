using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CharacterController), typeof(Hitable))]
public class Player : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField] private Rigidbody _rigidbody;
    [Range(0f, 10f)]
    [SerializeField] private float _speed = 5;
    [Range(0f, 5f)]
    [SerializeField] private float _cameraRotationSpeed = 5;
    [SerializeField] private CharacterController _characterController;

    [Header("Weapon")]
    [SerializeField] private List<Weapon> _weapons;
    private Weapon _activeWeapon;

    public Hitable Hitable;
    private Vector2 _moveInput;
    private int _activeWeaponIndex = 0;

    private void Update()
    {
        Movement();
        ChangeWeapon();
    }

    private void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            _weapons[_activeWeaponIndex].gameObject.SetActive(false);
            if (_activeWeaponIndex == _weapons.Count - 1)
                _activeWeaponIndex = 0;
            else
                _activeWeaponIndex++;
            _weapons[_activeWeaponIndex].gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Weapon":
                PickUpWeapon(other.GetComponent<Weapon>());
                break;
        }
    }

    private void PickUpWeapon(Weapon weapon)
    {
        _weapons.Add(weapon);
    }

    private void Movement()
    {
        _moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 moveX = transform.right * _moveInput.x;
        Vector3 moveY = transform.forward * _moveInput.y;

        float mouseX = Input.GetAxis("Mouse X") * _cameraRotationSpeed;
        transform.Rotate(0f, mouseX, 0f);

        _characterController.SimpleMove((moveX + moveY) * _speed);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Hitable.ReceivedDamage.AddListener(OnDamageReceived);
    }

    private void OnDamageReceived(int arg0, int arg1)
    {
        print($"Received {arg0} damage. {arg1} HP left");
    }
}