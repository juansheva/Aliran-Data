using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : IVerticalMoveable
{
    private Rigidbody2D rigidbody2D;
    private float speed;

    public PlayerMovement(Rigidbody2D _rigidbody2D, float _speed)
    {
        rigidbody2D = _rigidbody2D;
        speed = _speed;
    }

    public void Fly()
    {
        rigidbody2D.AddForce(Vector2.up * speed);
        //rigidbody2D.velocity = Vector2.up * speed;
    }
}