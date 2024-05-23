// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using Godot;

public partial class QuitApp : Node
{
	public override void _Process(double delta)
	{
		base._Process(delta);

		if (Input.IsKeyPressed(Key.Escape))
		{
			GetTree().Quit();
		}
	}
}
