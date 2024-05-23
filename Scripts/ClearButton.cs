// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using Godot;

public partial class ClearButton : TextureButton
{
	[Export]
	private CellsController cellsController;

	public override void _Pressed()
	{
		base._Pressed();

		cellsController.KillAllCells();
	}
}