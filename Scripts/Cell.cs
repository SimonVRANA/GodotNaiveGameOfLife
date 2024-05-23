// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using Godot;

public partial class Cell : TextureButton
{
	[Export]
	private CompressedTexture2D aliveTexture;

	[Export]
	private CompressedTexture2D deadTexture;

	private bool isAlive = false;

	public bool IsAlive
	{
		get => isAlive;
		set
		{
			isAlive = value;
			UpdateImage();
		}
	}

	public override void _Pressed()
	{
		base._Pressed();

		IsAlive = !IsAlive;
	}

	private void UpdateImage()
	{
		TextureNormal = isAlive ? aliveTexture : deadTexture;
	}
}