using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int RowCount, ColumCount;
    public float CellSize = 1f;
    public Color GridColor;
    public bool ShowGrid = true;

    private Tile[,] m_Tiles;

    [Space]
    [Header("Grid Editor")]

#if UNITY_EDITOR
    public GameObject[] AvailableFiles;
    public int SelectedTileID;
#endif

    public Tile SpawnTile(Tile a_Tile, Vector2Int a_Pos)
    {
        return Instantiate(a_Tile, GridToWorld(a_Pos), Quaternion.identity);
        
    }

    public void init()
    {
        m_Tiles = new Tile[ColumCount, RowCount];

        var t_AllTimes = GetComponentsInChildren<Tile>();

        foreach (var t_Tile in t_AllTimes)
        {
            Vector2Int t_TilePos = WorldToGrid(t_Tile.transform.position);
            t_Tile.TilePos = t_TilePos;
            m_Tiles[t_TilePos.x, t_TilePos.y] = t_Tile;
        }
    }

    public Tile GetTile(Vector2Int a_GridPos)
    {
        if (a_GridPos.x < 0 || a_GridPos.y < 0 || a_GridPos.x >= ColumCount || a_GridPos.y >= RowCount)
            throw new GridException("Out of grid !");

        return m_Tiles[a_GridPos.x, a_GridPos.y];
    }

    private void OnDrawGizmosSelected()
    {
        if (!ShowGrid)
        {
            return;
        }

        Gizmos.color = GridColor;

        //Ligne horizontal
        float t_StartX = transform.position.x;
        float t_EndX = ColumCount * CellSize + transform.position.x;
        for (int i = 0; i < RowCount + 1; i++)
        {
            float t_lineY = i * CellSize + transform.position.y;
            Gizmos.DrawLine(new Vector3(t_StartX, t_lineY, 0), new Vector3(t_EndX, t_lineY, 0));
        }

        //Ligne vertical
        float t_StartrY = transform.position.y;
        float t_EndY = RowCount * CellSize + transform.position.y;
        for (int j = 0; j < ColumCount + 1; j++)
        {
            float t_lineX = j * CellSize + transform.position.x;
            Gizmos.DrawLine(new Vector3(t_lineX, t_StartrY, 0), new Vector3(t_lineX, t_EndY, 0));
        }
    }

    public Vector2Int WorldToGrid(Vector3 a_wordPos)
    {
        int t_PosX = Mathf.FloorToInt(a_wordPos.x - transform.position.x / CellSize);
        int t_PosY = Mathf.FloorToInt(a_wordPos.y - transform.position.y / CellSize);

        //Exception
        if (t_PosX < 0 || t_PosY < 0 || t_PosX >= ColumCount || t_PosY >= RowCount)
        {
            throw new GridException("Out of grid !");
        }

        return new Vector2Int(t_PosX, t_PosY);
    }

    public Vector3 GridToWorld(Vector2Int a_GridPos)
    {
        //Exception
        if (a_GridPos.x < 0 || a_GridPos.y < 0 || a_GridPos.x >= ColumCount || a_GridPos.y >= RowCount)
            throw new GridException("Out of grid !");

        float t_PosX = a_GridPos.x * CellSize + (CellSize / 2) + transform.position.x;
        float t_PosY = a_GridPos.y * CellSize + (CellSize / 2) + transform.position.y;

        return new Vector3(t_PosX, t_PosY, 0);
    }
}
