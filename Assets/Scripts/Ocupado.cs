using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocupado : MonoBehaviour
{

    private int value, x, y;
    public Vector2 Pos => transform.position;
    public Block block;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Init(Block block, int x, int y)
    {
        Debug.Log("Figure " + " " + x + " " + y);
        this.x = x;
        this.y = y;
        this.block = block;
    }

    public void setValue(int value)
    {
        this.value = value;
    }
}
