using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolHandler : MonoBehaviour
{
    [SerializeField] private int rows = 6;
    [SerializeField] private int cols = 8;
    [SerializeField] private float tileSize = 1;
    [SerializeField] private string color = "White";
    [SerializeField] private int quad = 0;
    //private GameObject MainGrid;
  
    

    // Start is called before the first frame update
    void Awake()
    {
        //MainGrid = transform.Find("GridSystem").gameObject;
        GenerateGrid();
        
       
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

        

        float gridW = cols * tileSize;
        float gridH = rows * tileSize;
        float mainH = GridHandler.getHeightStatic();
        float mainW = GridHandler.getWidthStatic();

        
        if (quad == 0)
        {
            transform.position = new Vector2(0,0);//(-gridW / 2 + tileSize / 2, gridH / 2 - tileSize / 2);
        }
        else if (quad == 1)
        {
            transform.position = new Vector2(-mainW, mainH - tileSize);
        }
        else if (quad == 2)
        {
            transform.position = new Vector2(-mainW + tileSize, -tileSize);
        } 
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
