using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Grid 
{
    new Vector3 parentPosition;
    private int width;
    private int height;
    private int[,] gridArray;
    [SerializeField] float CellSize=1;
    public Grid(int width,int height,float CellSize,Transform parent) 
    {
        parentPosition = parent.position;
        this.width = width;
        this.height = height;
        gridArray = new int[width,height];
        Debug.DrawLine(position(width, 0), position(width,height), Color.white, 100f);
        Debug.DrawLine(position(0, height), position(width ,height), Color.white, 100f);
        
        for (int x = 0;x< gridArray.GetLength(0);x++)
        {
            for (int y = 0;y< gridArray.GetLength(1);y++)
            {
                CreateWorldText(parent,gridArray[x, y].ToString(),position(x, y),5, Color.white, TextAnchor.MiddleCenter,TextAlignment.Center,1);
                
                Debug.DrawLine(position(x, y),position(x,y+1),Color.white, 100f);
                Debug.DrawLine(position(x, y), position(x+1, y),Color.white,100f);


            }

        }
    }
    private Vector3 position(int x,int y)
    {
        return new Vector3(x,y)*CellSize+ parentPosition;
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

    
    public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor,TextAlignment textAlignment, int sortingOrder)
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
