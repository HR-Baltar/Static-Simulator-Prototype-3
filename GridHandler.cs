using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    [SerializeField] private int rows = 6;
    [SerializeField] private int cols = 8;
    [SerializeField] private float tileSize = 1;
    [SerializeField] private string color = "White";
    //[SerializeField] private int quad = 0;
    private static GridHandler instance;
    private float gridW;
    private float gridH;

    private List<GameObject> Tiles;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        //generate Tile list
        Tiles = new List<GameObject>();

        GenerateGrid();
        /*
        GameObject pfTool = (GameObject)Instantiate(Resources.Load("ToolSystem"));
        GameObject tb = (GameObject)Instantiate(pfTool, transform.position, Quaternion.identity);
        Destroy(pfTool);
        tb.SetActive(true); */

        /*
        GameObject pfEquation = (GameObject)Instantiate(Resources.Load("EquationBar"));
        GameObject eb = (GameObject)Instantiate(pfEquation, transform.position, Quaternion.identity);
        Destroy(pfEquation);
        eb.SetActive(true);
        // */
    }

    private void GenerateGrid()
    {
        GameObject pfTile = (GameObject)Instantiate(Resources.Load(color));
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject Tile = (GameObject)Instantiate(pfTile, transform);

                float posX = col * tileSize;
                float poxY = row * -tileSize;

                Tile.transform.position = new Vector2(posX, poxY);

                Tiles.Add(Tile);
            }

        }
        Destroy(pfTile);

        gridW = cols * tileSize;
        gridH = rows * tileSize;


        transform.position = new Vector2(-gridW / 2 + tileSize / 2, gridH / 2 - tileSize / 2);

        
    }

    void Update()
    {
        // for tile in grid

            // chech if mouse item is colliding
            // check if tile is holding an item
            // if tile is holding item -> do nothing for now ( maybe impletement swap() mechanic later)
            // otherwise if tile is not holding an item and mouse itme is not held
                //tile gets item
    }

    private float getWidth()
    {
        return gridW;
    }

    public static float getWidthStatic()
    {
        return instance.getWidth();
    }

    private float getHeight()
    {
        return gridH;
    }

    public static float getHeightStatic()
    {
        return instance.getHeight();
    }

}
