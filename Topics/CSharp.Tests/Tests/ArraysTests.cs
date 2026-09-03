namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates Arrays with isolated, repeatable examples.</summary>
public class ArraysTests
{
    /// <summary>Shows end-relative indexing and a copied slice.</summary>
    [Fact]
    public void IndexRangeAndCopy()
    {
        int[] values = [10, 20, 30];
        Assert.Equal(30, values[^1]);
        int[] slice = values[1..];
        slice[0] = 99;
        Assert.Equal(20, values[1]);
        Assert.Throws<IndexOutOfRangeException>(() => values[3]);
    }

    /// <summary>Contrasts a rectangular grid with rows of different lengths.</summary>
    [Fact]
    public void RectangularAndJaggedShapes()
    {
        int[,] grid = { { 1, 2 }, { 3, 4 } };
        int[][] rows = [ [1], [2, 3] ];
        Assert.Equal(4, grid[1, 1]);
        Assert.Equal(2, grid.GetLength(0));
        Assert.Single(rows[0]);
        Assert.Equal(2, rows[1].Length);
    }
}
