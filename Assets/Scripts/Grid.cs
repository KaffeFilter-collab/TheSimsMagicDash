using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid 
{

    private int width;
    private int height;
    private int[,] gridArray;
    [SerializeField] int CellSize;
    public Grid(int width,int height) 
    { 
        this.width = width;
        this.height = height;
        gridArray = new int[width,height];
        
        for (int x = 0;x< gridArray.GetLength(0);x++)
        {
            for (int y = 0;y< gridArray.GetLength(1);y++)
            {
                CreateWorldText(gridArray[x, y].ToString(), null ,GetWorldposition(x, y),20, Color.white, TextAnchor.MiddleCenter);
            }

        }
    }
    private Vector3 position(int x,int y)
    {
        return new Vector3(x,y)*CellSize;
    }
    private void GetWorldposition(Vector3 position,out int x, out int y) 
    {
        x=Mathf.FloorToInt(position.x/CellSize);
        y = Mathf.FloorToInt(position.y / CellSize);

    }
    public void SetValue(int x,int y,int targetvalue) 
    {
        if (x <= 0 && y <= 0 && x < width && y < height) 
        {
            gridArray[x,y] = targetvalue;
            
        }
    }
    public void SetValue(Vector3 worldPosition,int value) 
    {
        int x, y;
        GetWorldposition(worldPosition,out x,out y);
        SetValue(x, y, value);
    }


    public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }
}
