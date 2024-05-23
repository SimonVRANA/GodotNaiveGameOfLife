// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using Godot;
using System;

public partial class CellsController : Node
{
	[Export]
	private GridContainer cellsParentNode;

	[Export]
	private PackedScene cellTemplate;

	[Export]
	private CheckButton playButton;

	[Export]
	private SpinBox speedSpinBox;

	private int gridWidth = 100;
	private float gridRatio = 192.0f / 97.0f;

	private int GridHeight => Mathf.FloorToInt(gridWidth / gridRatio);

	private readonly Random random = new();

	private int ticksBeforeApplyingGameLogic = 0;

	public override void _Ready()
	{
		base._Ready();

		RecreateGrid();
	}

	public override void _Process(double delta)
	{
		base._Process(delta);

		if (!playButton.ButtonPressed)
		{
			return;
		}

		if (ticksBeforeApplyingGameLogic > 0)
		{
			ticksBeforeApplyingGameLogic--;
			return;
		}

		ticksBeforeApplyingGameLogic = Mathf.FloorToInt(speedSpinBox.Value);

		bool[,] stateAtBegining = GetCurrentGridState();

		for (int columnIndex = 0; columnIndex < gridWidth; columnIndex++)
		{
			for (int rowIndex = 0; rowIndex < GridHeight; rowIndex++)
			{
				int numberOfNeighbours = 0;

				for (int i = -1; i <= 1; i++)
				{
					for (int j = -1; j <= 1; j++)
					{
						if (i == 0
						   && j == 0)
						{
							continue;
						}

						int column = (columnIndex + i + gridWidth) % gridWidth;
						int row = (rowIndex + j + GridHeight) % GridHeight;
						if (stateAtBegining[column, row])
						{
							numberOfNeighbours++;
						}
					}
				}

				Cell cell = GetCellAtPosition(columnIndex, rowIndex);
				if (cell != null)
				{
					if (cell.IsAlive)
					{
						int truc = 0;
						truc++;
					}

					cell.IsAlive = (cell.IsAlive && (numberOfNeighbours == 2 || numberOfNeighbours == 3))
								   || (!cell.IsAlive && numberOfNeighbours == 3);
				}
			}
		}
	}

	private bool[,] GetCurrentGridState()
	{
		bool[,] gridState = new bool[gridWidth, GridHeight];

		for (int columnIndex = 0; columnIndex < gridWidth; columnIndex++)
		{
			for (int rowIndex = 0; rowIndex < GridHeight; rowIndex++)
			{
				Cell cell = GetCellAtPosition(columnIndex, rowIndex);
				gridState[columnIndex, rowIndex] = cell != null && cell.IsAlive;
			}
		}

		return gridState;
	}

	public void SetGridWidth(int newWidth)
	{
		if (newWidth <= 0
		   || newWidth > 1000)
		{
			return;
		}
		gridWidth = newWidth;
		RecreateGrid();
	}

	private void RecreateGrid()
	{
		DeleteAllCells();
		cellsParentNode.Columns = gridWidth;
		for (int i = 0; i < GridHeight * gridWidth; i++)
		{
			Cell cell = cellTemplate.Instantiate<Cell>();
			cellsParentNode.AddChild(cell);

			cell.Position = new Vector2(0, 108);
		}
	}

	private void DeleteAllCells()
	{
		foreach (Node child in cellsParentNode.GetChildren())
		{
			cellsParentNode.RemoveChild(child);
		}
	}

	public void RandomizeCells()
	{
		foreach (Node child in cellsParentNode.GetChildren())
		{
			try
			{
				Cell childAsCell = (Cell)child;
				int next = random.Next();
				int midValur = (int.MaxValue / 2);
				bool result = next > midValur;
				childAsCell.IsAlive = result;
			}
			catch { }
		}
	}

	private Cell GetCellAtPosition(int column, int row)
	{
		int safeColumn = (column + gridWidth) % gridWidth;
		int safeRow = (row + GridHeight) % GridHeight;

		Node child = cellsParentNode.GetChild(safeRow * gridWidth + safeColumn);

		try
		{
			return child as Cell;
		}
		catch
		{
			return null;
		}
	}

	public void KillAllCells()
	{
		foreach (Node child in cellsParentNode.GetChildren())
		{
			try
			{
				Cell childAsCell = (Cell)child;
				childAsCell.IsAlive = false;
			}
			catch { }
		}
	}
}