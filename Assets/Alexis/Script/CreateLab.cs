using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLab : MonoBehaviour
{
    public Grid[] Section;
    

    private void Awake()
    {
        Grid MyGrid = GetComponent<Grid>();
        
        for (int i = 0; i < 50; i += 10)
        {
            for (int j = 0; j < 50; j += 10)
            {
                Grid t_RandomSection = Section[Random.Range(0,Section.Length)];
                foreach (var t_Tuile in t_RandomSection.GetComponentsInChildren<Tile>())
                {
                    Vector2Int t_TilePos = t_RandomSection.WorldToGrid(t_Tuile.transform.position);
                    MyGrid.SpawnTile(t_Tuile, new Vector2Int(i + t_TilePos.x, j + t_TilePos.y));
                }
            }
        }




        //Tile test = t_RandomSection.GetComponentInChildren<Tile>();
       // Debug.Log(t_RandomSection.WorldToGrid(test.transform.position));
    }
}
