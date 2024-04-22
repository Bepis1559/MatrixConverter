int[,] matrix =
    { { 0, 1, 1, 0, 0, 1, 0, 0, 0 },
      { 1, 0, 0, 1, 1, 0, 0, 0, 0 },
      { 1, 0, 0, 0, 0, 1, 1, 0, 1 },
      { 0, 1, 0, 0, 0, 0, 0, 1, 0 },
      { 0, 1, 0, 0, 0, 1, 0, 1, 1 },
      { 1, 0, 1, 0, 1, 0, 1, 0, 0 },
      { 0, 0, 1, 0, 0, 1, 0, 1, 1 },
      { 0, 0, 0, 1, 1, 0, 1, 0, 0 },
      { 0, 0, 1, 0, 1, 0, 1, 0, 0 } };

int rowsCount = matrix.GetLength(0);
int columnsCount = matrix.GetLength(1);


void AdjacencyToIncidenceMatrix()
{
    List<List<int>> allEdges = [];
    for (int i = 0; i < rowsCount; i++)
    {
        var numbersOfRow = GetNumbersOfNthRow(i);
        var edges = CreateIncidenceMatrixEdgesForARow(i, numbersOfRow);
        allEdges.AddRange(edges);
    }
    var allEdgesTransposed = TransposeMatrix(allEdges);
    LogMatrix(allEdgesTransposed);

}



List<int> GetNumbersOfNthRow(int rowNum)
{
    List<int> row = [];
    for (int i = 0; i < columnsCount; i++)
    {
        row.Add(matrix[rowNum, i]);
    }
    return row;
}

List<List<int>> CreateIncidenceMatrixEdgesForARow(int currentRow, List<int> numbersOfRow)
{
    List<List<int>> edges = [];
    int rowLength = numbersOfRow.Count;
    for (int i = currentRow; i < rowLength; i++)
    {
        if (numbersOfRow[i] == 1)
        {

            List<int> edge = Enumerable.Repeat(0, rowLength).ToList();
            edge[currentRow] = 1;
            edge[i] = 1;
            edges.Add(edge);
        }
    }

    return edges;
}

List<List<int>> TransposeMatrix(List<List<int>> matrix)
{
    List<List<int>> transposedMatrix = [];
    for (int i = 0; i < matrix[0].Count; i++)
    {
        List<int> newRow = [];
        for (int j = 0; j < matrix.Count; j++)
        {
            newRow.Add(matrix[j][i]);
        }
        transposedMatrix.Add(newRow);
    }

    return transposedMatrix;
}

void LogMatrix(List<List<int>> matrix)
{
    foreach (List<int> row in matrix)
    {
        foreach (int number in row)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}
AdjacencyToIncidenceMatrix();