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

    public Hitable Hitable;
    private Vector2 _moveInput;
    private int _activeWeaponIndex = 1;

    public List<Weapon> Weapons => _weapons;

    private void Update()
    {
        Movement();
        ChangeWeapon();
    }

    private void ChangeWeapon()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            Weapons[_activeWeaponIndex].Unequip();
            if (_activeWeaponIndex == Weapons.Count - 1)
                _activeWeaponIndex = 0;
            else
                _activeWeaponIndex++;
            Weapons[_activeWeaponIndex].Equip();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Pickable":
                IPickable item = other.GetComponent<IPickable>();
                item.PickUp(this);
                break;
        }
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
        Hitable.ReceivedDamage += OnDamageReceived;
        Hitable.Healed += (newHp, totalHp) => print($"{newHp} added. Total HP: {totalHp}");
    }

    private void OnDamageReceived(int damage, int totalHp)
    {
        print($"Received {damage} damage. {totalHp} HP left");
    }
}