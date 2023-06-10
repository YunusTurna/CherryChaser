using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class RunTimeMovement : MonoBehaviour
{
    private Movement _input;
    private CharacterController _controller;
    private void Start() {
        _controller = GetComponent<CharacterController>();
        _input = GetComponent<Movement>();
    }
    private void Update() {
        Movement();
    }
    private void Movement()
    {
        _controller.Move(new Vector3(_input.moveVal.x * _input.moveSpeed , 0f , _input.moveVal.y * _input.moveSpeed) * Time.deltaTime);

    }
}
