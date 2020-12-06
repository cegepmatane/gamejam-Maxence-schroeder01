using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;


public class CreateLab : MonoBehaviour
{
    public Grid[] Section;
    public Tile EndCase;
    public Tile StartCase;
    public Pathfinder PathFinder;
    public GameObject Player;
    public Tile Mur;
    public GameObject Jar;
    private List<GameObject> JarList;
    public GameObject Coffre;
    public GameObject Minautaure;
    public GameObject CoffreInstant;
    
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
            if (CompteurDeGeneration >= 10)
            {
                Debug.LogError("Generation fail");
                return;
            }
        } while (t_NewPath == null);
        
        Debug.Log("Nombre de génération : " + CompteurDeGeneration);
    }

    [ContextMenu("GetPath")]
    private void GenerateGrid()
    {
        Grid MyGrid = GetComponent<Grid>();
        JarList = new List<GameObject>();

        for (int i = 0; i < 40; i += 10)
        {
            for (int j = 0; j < 40; j += 10)
            {
                Grid t_RandomSection = Section[RandomRoom()];
                foreach (var t_Tuile in t_RandomSection.GetComponentsInChildren<Tile>())
                {
                    Vector2Int t_TilePos = t_RandomSection.WorldToGrid(t_Tuile.transform.position);
                    Tile t_NewTile;
                    if (FermetureMur(i + t_TilePos.x, j + t_TilePos.y))
                    {
                        t_NewTile = MyGrid.SpawnTile(Mur, new Vector2Int(i + t_TilePos.x, j + t_TilePos.y));

                        float t_CellSize = MyGrid.CellSize;
                        Sprite t_Sprite = t_NewTile.GetComponent<SpriteRenderer>().sprite;
                        float t_Scale = t_CellSize / t_Sprite.bounds.size.x;
                        t_NewTile.transform.localScale = new Vector3(t_Scale, t_Scale, t_Scale);
                        t_NewTile.BaseCost = 0;
                    } 
                    else
                        t_NewTile = MyGrid.SpawnTile(t_Tuile, new Vector2Int(i + t_TilePos.x, j + t_TilePos.y));

                   
                    t_NewTile.transform.parent = transform;
                    if (t_NewTile.BaseCost == 1)
                    {
                        int JarChance = Random.Range(0, 100);
                        if (JarChance == 27)
                            JarList.Add(Instantiate(Jar, t_NewTile.transform.position, Quaternion.identity));
                    }
                    if (t_NewTile.gameObject.layer == LayerMask.NameToLayer("StartCase"))
                    {
                        StartCase = t_NewTile;
                        Player.transform.position = StartCase.transform.position;
                    }
                    if (t_NewTile.gameObject.layer == LayerMask.NameToLayer("EndCase"))
                    {
                        EndCase = t_NewTile;
                       CoffreInstant = Instantiate(Coffre, t_NewTile.transform.position, Quaternion.identity);
                        Minautaure.transform.position = EndCase.transform.position;
                    }
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
        if (JarList != null)
        {
            foreach (var jar in JarList)
            {
                DestroyImmediate(jar.gameObject);
            }
        }
        if (CoffreInstant != null)
            Destroy(CoffreInstant.gameObject);
        
        AlwaysUse = new bool[16];
    }

    private bool FermetureMur(int x, int y)
    {
        Grid t_GridCount = GetComponent<Grid>();

        if (x <= 0) return true;
        if (y <= 0) return true;
        if (x >= t_GridCount.ColumCount - 1) return true;
        if (y >= t_GridCount.RowCount - 1) return true;

        return false;
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
