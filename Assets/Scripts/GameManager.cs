using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private List<Cell> cells;
    [SerializeField] private List<Figure> prefabs;
    [SerializeField] private UIManager uiManager;
    private Vector3 spawnOffset = new Vector3(0, 2, 0);
    private float tiltAngle = 10;
    private int currentTurn;
    private bool canSpawnFigure = true;
    private bool isGameOver = false;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
    }

    public Figure SpawnFigure(Cell aboveCell)
    {
        if (!canSpawnFigure || isGameOver) return null;
        canSpawnFigure = false;

        currentTurn++;

        Figure nextFigurePrefab = GetNextFigurePrefab();
        Vector3 spawnPosition = aboveCell.transform.position + spawnOffset;

        Figure currentFigure = Instantiate(nextFigurePrefab, spawnPosition, nextFigurePrefab.transform.rotation);
        TiltFigure(currentFigure);

        return currentFigure;
    }

    // ABSTRACTION
    private Figure GetNextFigurePrefab()
    {
        return prefabs[currentTurn % 2];
    }

    // ABSTRACTION
    private void TiltFigure(Figure figure)
    {
        Vector2 axis2d;

        while (true)
        {
            axis2d = Random.insideUnitCircle;
            if (axis2d.magnitude > Mathf.Epsilon) break;
        }

        Vector3 tiltAxis = new Vector3(axis2d.x, 0, axis2d.y);
        figure.transform.Rotate(tiltAxis, tiltAngle);
    }

    public void CheckWinner(Cell currentCell)
    {
        int cellIndex = cells.IndexOf(currentCell);
        List<List<int>> lines = GetLinesWithCell(cellIndex);
        string figureName = currentCell.Figure.name;

        foreach (List<int> line in lines)
        {
            if (IsWinnerLine(line, figureName))
            {
                isGameOver = true;
                DrawWinner(line);
                return;
            }
        }

        PrepareNextMove();
    }

    /* For a given cell index, return a list of rows/columns/diagonals (if applicable)
       that contain this cell;
    */
    // ABSTRACTION
    private List<List<int>> GetLinesWithCell(int cellIndex)
    {
        int rowIndex = cellIndex / 3;
        int columnIndex = cellIndex % 3;

        List<List<int>> lines = new List<List<int>>();
        List<int> row = new List<int>();
        List<int> column = new List<int>();

        for (int i = 0; i < 3; i++)
        {
            row.Add(rowIndex * 3 + i);
            column.Add(i * 3 + columnIndex);
        }

        lines.Add(row);
        lines.Add(column);

        // Append diagonals, if applicable
        if (cellIndex % 4 == 0)
        {
            lines.Add(new List<int>() { 0, 4, 8 });
        }

        if (cellIndex == 2 || cellIndex == 4 || cellIndex == 6)
        {
            lines.Add(new List<int>() { 2, 4, 6 });
        }

        return lines;
    }

    // ABSTRACTION
    private bool IsWinnerLine(List<int> line, string figureName)
    {
        foreach (int index in line)
        {
            if (cells[index].Figure == null || cells[index].Figure.name != figureName)
            {
                return false;
            }
        }

        return true;
    }

    // ABSTRACTION
    private void PrepareNextMove()
    {
        if (currentTurn == 9)
        {
            isGameOver = true;
            uiManager.ShowDraw();
        }
        else
        {
            canSpawnFigure = true;
            uiManager.SwapFigure();
        }
    }

    // ABSTRACTION
    private void DrawWinner(List<int> line)
    {
        uiManager.ShowWinner();

        foreach (int index in line)
        {
            cells[index].Figure.applyWinnerMaterial();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
