using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

[CustomEditor(typeof(Grid))]
[CanEditMultipleObjects]
public class GridEditor : Editor
{
    private void OnSceneGUI()
    {
        if (Event.current.type == EventType.MouseDown && Event.current.control)
        {

            GUIUtility.hotControl = GUIUtility.GetControlID(FocusType.Passive);

            Vector3 t_ClickPos = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition).origin;
            Vector2Int t_GridPos = ((Grid)target).WorldToGrid(t_ClickPos);
            Vector3 t_WorldPos = ((Grid)target).GridToWorld(t_GridPos);

            int t_SelectedTile = ((Grid)target).SelectedTileID;

            //Si l'ID de la tuile est invalide
            if (t_SelectedTile >= ((Grid)target).AvailableFiles.Length || t_SelectedTile < 0)
                throw new GridException("Selected Tile");

            //Supprimer ancienne tuile
            List<Tile> t_Tiles = ((Grid)target).GetComponentsInChildren<Tile>().ToList();
            Tile t_OldTile = t_Tiles.FirstOrDefault(t => t.transform.position == t_WorldPos);
            if (t_OldTile != null)
            {
                Undo.DestroyObjectImmediate(t_OldTile.gameObject);
            }

            //Trouver la tuile à instancier
            GameObject t_TilePrefab = ((Grid)target).AvailableFiles[t_SelectedTile];

            //Instancier la tuile en tant que prefab, parenté avec grid
            GameObject t_newTileGo = (GameObject)PrefabUtility.InstantiatePrefab(t_TilePrefab, ((Grid)target).transform);
            Undo.RegisterCreatedObjectUndo(t_newTileGo, "Tile created");
            t_newTileGo.transform.position = t_WorldPos;

            //ajuster la taille de l'image à la taille de la grille
            float t_CellSize = ((Grid)target).CellSize;
            Sprite t_Sprite = t_newTileGo.GetComponent<SpriteRenderer>().sprite;
            float t_Scale = t_CellSize / t_Sprite.bounds.size.x;
            t_newTileGo.transform.localScale = new Vector3(t_Scale, t_Scale, t_Scale);
        }
    }
}
