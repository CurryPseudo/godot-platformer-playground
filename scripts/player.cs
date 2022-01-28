using Godot;
using System;

public class player : KinematicBody2D
{
	public float inputHorizontal = 0.0f;
	[Export]
	public Vector2 velocity = new Vector2();

	[Export]
	public float gravity = 64.0f;
	[Export]
	public float horizontalAcc = 20.0f;
	[Export]
	public float horizontalFric = 20.0f;
	[Export]
	public float horizontalMaxSpeed = 20.0f;
	private bool inputJump = false;
	[Export]
	public float jumpSpeed = 20.0f;
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SetPhysicsProcess(true);
	}
	public override void _Process(float delta)
	{
		base._Process(delta);
		inputHorizontal = Input.GetAxis("ui_left", "ui_right");
		inputJump = Input.IsActionJustPressed("jump");
	}

	public override void _PhysicsProcess(float delta)
	{
		base._PhysicsProcess(delta);
		velocity.y += gravity * delta;
		velocity.x += horizontalAcc * inputHorizontal * delta;
		if (inputJump)
		{
			velocity.y = -jumpSpeed;
			inputJump = false;
		}
		velocity.x -= Math.Min(horizontalFric * delta, Math.Abs(velocity.x)) * Math.Sign(velocity.x);
		velocity.x = Math.Min(horizontalMaxSpeed, Math.Abs(velocity.x)) * Math.Sign(velocity.x);
		velocity = MoveAndSlide(velocity, new Vector2(0, 1));
	}
}
