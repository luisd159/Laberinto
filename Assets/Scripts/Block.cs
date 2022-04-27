using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Ocupado occupidedFigure;
    public Player occupidedPlayer;
    public int index;
    public bool isOccupied => occupidedFigure != null;

    public void Init(int index)
    {
        this.index = index;
    }
    public Vector2 Pos => transform.position;

    public void setFigure(Ocupado ocupado)
    {
        occupidedFigure = ocupado;
    }

    public void setPlayer(Player player)
    {
        occupidedPlayer = player;
    }


}
