using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animation _animation;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _moveSpeed = 4f;

    private void FixedUpdate()
    {
        var x = _joystick.Horizontal;
        var z = _joystick.Vertical;

        _rigidbody.velocity = new Vector3(x * _moveSpeed, 0, z * _moveSpeed);

        if (x !=0 || z!=0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            _animation.Play("Walk");
        }
        else
        {
            _animation.Play("Idle");
        }
    }
}
