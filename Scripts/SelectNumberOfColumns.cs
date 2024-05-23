// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using Godot;

public partial class SelectNumberOfColumns : SpinBox
{
	[Export]
	private CellsController cellsController;

	public override void _ValueChanged(double newValue)
	{
		base._ValueChanged(newValue);

		cellsController.SetGridWidth(Mathf.FloorToInt(newValue));
	}
}