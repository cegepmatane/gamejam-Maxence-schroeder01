using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class CreateLab : MonoBehaviour
{
    public Grid[] Section;
    public Tile EndCase;
    public Tile StartCase;
    public Pathfinder PathFinder;

    private bool[] AlwaysUse;


    private void Start()
    {
        PathFinder = gameObject.GetComponent<Pathfinder>();
        Path t_NewPath;
        int CompteurDeGeneration = 0;
        do
        {
            DeleteGrid();
            GenerateGrid();
            t_NewPath = PathFinder.GetPath(StartCase, EndCase, false);
            CompteurDeGeneration++;
            if (CompteurDeGeneration >= 200)
            {
                Debug.LogError("Generation fail");
                return;
            }
        } while (t_NewPath == null);
        Debug.Log("Nombre de génération : " + CompteurDeGeneration);
    }

    [ContextMenu("GetPath")]
    public void GetPath()
    {
        PathFinder.GetPath(StartCase, EndCase, false);
    }
    
    private void GenerateGrid()
    {
        Grid MyGrid = GetComponent<Grid>();

        for (int i = 0; i < 40; i += 10)
        {
            for (int j = 0; j < 40; j += 10)
            {
                Grid t_RandomSection = Section[RandomRoom()];
                foreach (var t_Tuile in t_RandomSection.GetComponentsInChildren<Tile>())
                {

                    Vector2Int t_TilePos = t_RandomSection.WorldToGrid(t_Tuile.transform.position);
                    Tile t_NewTile = MyGrid.SpawnTile(t_Tuile, new Vector2Int(i + t_TilePos.x, j + t_TilePos.y));
                    t_NewTile.transform.parent = transform;
                    if (t_Tuile.gameObject.layer == LayerMask.NameToLayer("StartCase"))
                        StartCase = t_NewTile;
                    if (t_Tuile.gameObject.layer == LayerMask.NameToLayer("EndCase"))
                        EndCase = t_NewTile;
                }
            }
        }
        MyGrid.init();
        PathFinder.init();
    }

    public void DeleteGrid()
    {
        foreach (var tuile in GetComponentsInChildren<Tile>())
        {
            DestroyImmediate(tuile.gameObject);

        }
        AlwaysUse = new bool[16];
    }



    private int RandomRoom()
    {

        while (true)
        {
            int RandomRoom = Random.Range(0, 16);

            if (AlwaysUse[RandomRoom] == true) { }
            else
            {
                 AlwaysUse[RandomRoom] = true;
                 return RandomRoom;
            }
        }
    }
}
