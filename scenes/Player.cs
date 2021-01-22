using Godot;

public class Player : KinematicBody2D
{
    private int _speed = 150;
    private Vector2 _screenSize;
    private float _spriteWidth;
    private float _spriteHeight;

    public override void _Ready()
    {
        _screenSize = GetViewport().Size;
        SetSpriteDimensions();
    }

    public override void _PhysicsProcess(float delta)
    {
        Vector2 playerMovementVector = GetPlayerMovementVector();
        KinematicCollision2D collisionInfo = MoveAndCollide(playerMovementVector * delta);
        if (collisionInfo != null)
        {
            var collisionPoint = collisionInfo.Position;
        }
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

    public void OnAreaEntered(Area2D area)
    {
        GD.Print("Hello from Player.cs");
    }
}
