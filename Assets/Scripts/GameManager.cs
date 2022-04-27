using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public int width = 4;
    public int height = 4;
    public Block blockPrefab;
    public Board boardPrefab;
    public Ocupado ocupadoPrefab;
    private List<Block> blocks;
    private List<Block> orderBlocksList;
    private int currentIndex;
    public int currentX, currentY;
    private Block selectedBlock;



    void Start()
    {
        blocks = new List<Block>();
        GenerateBoard();
        SpawnFigure(4);
        SpawnPlayer(1);
        orderBlocksList = blocks.OrderBy(b => b.Pos.x).ThenBy(b => b.Pos.y).ToList();
    }

    
    // Generar Tablero
    void GenerateBoard()
    {
        int index = 0;
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                var block = Instantiate(blockPrefab, new Vector2(i, j), Quaternion.identity);
                blocks.Add(block);
                block.Init(index);
                index++;
            }
        }

        var center = new Vector2((float)width / 2 - 0.5f, (float)height / 2 - 0.5f);
        var board = Instantiate(boardPrefab, center, Quaternion.identity);
        board.transform.localScale = new Vector2(width, height);
        Camera.main.transform.position = new Vector3(center.x, center.y, -20);
    }


    //Guardar la informacion del bloque
    public void setCurrentBlock(Block block)
    {
        if (block == null)
        {
            Debug.Log("Block is null");
            return;
        }
        currentX = (int)block.Pos.x;
        currentY = (int)block.Pos.y;
        currentIndex = block.index;
        selectedBlock = block;
    }

    //spawn de lugares bloqueados
    void SpawnFigure(int amount)
    {
        var orderList = blocks.OrderBy(b => Random.Range(0, blocks.Count)).ToList();
        for (int i = 0; i < amount; i++)
        {
            Block block = orderList[i];
            Ocupado ocupado = Instantiate(ocupadoPrefab, block.Pos, Quaternion.identity);
            ocupado.setValue(i);
            block.setFigure(ocupado);
            ocupado.Init(block, (int)block.Pos.x, (int)block.Pos.y);
            setCurrentBlock(block);
        }
    }

    //Spawnear Player
    void SpawnPlayer(int amount)
    {
        var orderList = blocks.OrderBy(b => Random.Range(0, blocks.Count)).ToList();
        for (int i = 0; i < amount; i++)
        {
            Block block = orderList[i];
            Player player = Instantiate(ocupadoPrefab, block.Pos, Quaternion.identity);
            player.setValue(i);
            block.setPlayer(player);
            player.Init(block, (int)block.Pos.x, (int)block.Pos.y);
            setCurrentBlock(block);

        }
    }

    void Update()
    {
        
    }
}
