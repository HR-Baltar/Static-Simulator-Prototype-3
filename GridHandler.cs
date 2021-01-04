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
    [SerializeField] private int quad = 0;
    private static GridHandler instance;
    private float gridW;
    private float gridH;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        GenerateGrid();
        // /*
        GameObject pfTool = (GameObject)Instantiate(Resources.Load("ToolSystem"));
        GameObject tb = (GameObject)Instantiate(pfTool, transform.position, Quaternion.identity);
        Destroy(pfTool);
        tb.SetActive(true);


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
            }

        }
        Destroy(pfTile);

        gridW = cols * tileSize;
        gridH = rows * tileSize;


        transform.position = new Vector2(-gridW / 2 + tileSize / 2, gridH / 2 - tileSize / 2);

        
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
