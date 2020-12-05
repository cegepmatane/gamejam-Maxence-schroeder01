using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path
{
    public List<Tile> Checkpoints;

    public Tile getNextTile(Tile a_CurrentTile)
    {
        if (Checkpoints.Count == 0)
            return null;

        if (a_CurrentTile == null)
        {
            return Checkpoints[0];
        }

        int t_CurrentTileIndex = Checkpoints.IndexOf(a_CurrentTile);
        if (t_CurrentTileIndex == Checkpoints.Count - 1)
            return null;

        return Checkpoints[t_CurrentTileIndex + 1];
    }
}
