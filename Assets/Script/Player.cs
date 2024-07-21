using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//[RequireComponent(typeof Animator))]

public class Player : MonoBehaviour
{

    public float MoveSpeed = 1.0f;

    PlayerInputAction InputKeyboard;

    Vector3 InputDirection = Vector3.zero;

    private void Awake()
    {
        InputKeyboard = new PlayerInputAction();
    }

    private void OnEnable()
    {
        InputKeyboard.PlayerInput.Enable();
        InputKeyboard.PlayerInput.Move.performed += OnWASD;
        InputKeyboard.PlayerInput.Move.canceled += OnWASD;
    }

    private void OnDisable()
    {
        InputKeyboard.PlayerInput.Move.canceled -= OnWASD;
        InputKeyboard.PlayerInput.Move.performed -= OnWASD;
        InputKeyboard.PlayerInput.Disable();
    }

    private void Update()
    {
        transform.Translate(Time.deltaTime * InputDirection * MoveSpeed);
    }

    private void OnWASD(InputAction.CallbackContext context)
    {
        Vector2 Input = context.ReadValue<Vector2>();
        InputDirection = (Vector3)Input;
    }
}
