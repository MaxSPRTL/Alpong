using Godot;
using System;

public class Player : Area2D
{
    private int _speed = 200;
    private Vector2 _screenSize;
    private float _spriteWidth;
    private float _spriteHeight;

    public override void _Ready()
    {
        _screenSize = GetViewport().Size;
        SetSpriteDimensions();
    }

    public override void _Process(float delta)
    {
        Vector2 playerMovementVector = GetPlayerMovementVector();
        MovePlayer(playerMovementVector, delta);
    }

    public void SetSpriteDimensions()
    {
        CollisionShape2D collisionShape2D = GetNode<CollisionShape2D>("CollisionShape2D");
        Shape2D shape = collisionShape2D.Shape;
        if (shape is RectangleShape2D)
        {
            RectangleShape2D rectangleShape = (RectangleShape2D)shape;
            _spriteWidth = rectangleShape.Extents.x;
            _spriteHeight = rectangleShape.Extents.y;
        }
    }

    private Vector2 GetPlayerMovementVector()
    {
        Vector2 velocity = new Vector2();

        if (Input.IsActionPressed("ui_right"))
        {
            velocity.x += 1;
        }

        if (Input.IsActionPressed("ui_left"))
        {
            velocity.x -= 1;
        }

        velocity = velocity.Normalized() * _speed;

        return velocity;
    }

    public void MovePlayer(Vector2 playerMovementVector, float delta)
    {
        Position += playerMovementVector * delta;
        Position = new Vector2(
            x: Mathf.Clamp(Position.x, _spriteWidth, _screenSize.x - _spriteWidth),
            y: Mathf.Clamp(Position.y, 0, _screenSize.y)
        );
    }
}
