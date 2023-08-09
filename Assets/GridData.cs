using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GridData : MonoBehaviour
{
    public static GridData Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Define the 2D array and initialize it with data
    public int[,] Grid1 = {
        { 0, 0, 0, 2 },
        { 0, 2, 2, 0 },
        { 2, 0, 0, 0 },
        { 0, 0, 0, 2 }
    };  
    public int[,] Grid2 = {
        { 0, 0, 2 },
        { 0, 2, 0 },
        { 2, 0, 2 }
    }; 
    public int[,] Grid3 = {
        { 2, 2, 0, 2 },
        { 2, 0, 2, 0 },
        { 0, 2, 2, 0 },
        { 2, 0, 0, 2 }
    };  
    public int[,] Grid4 = {
        { 0, 2, 0, 2 },
        { 2, 0, 2, 0 },
        { 0, 2, 0, 0 },
        { 2, 2, 2, 2 }
    };  
    public int[,] Grid5 = {
        { 0, 0, 0, 2 },
        { 2, 0, 2, 0 },
        { 2, 2, 0, 0 },
        { 2, 0, 0, 2 }
    };  
    public int[,] Grid6 = {
        { 0, 2, 0, 2, 2 },
        { 0, 0, 2, 0, 0 },
        { 0, 2, 0, 2, 2 },
        { 0, 2, 2, 2, 0 },
        { 2, 0, 0, 2, 0 }
    }; 
    public int[,] Grid7 = {
        { 0, 2, 0, 0, 2 },
        { 2, 0, 0, 2, 0 },
        { 0, 0, 2, 2, 0 },
        { 2, 2, 2, 2, 0 },
        { 2, 2, 2, 0, 2 }
    };  
    public int[,] Grid8 = {
        { 0, 2, 2, 0, 2 },
        { 0, 2, 0, 2, 0 },
        { 2, 0, 2, 2, 2 },
        { 0, 0, 2, 0, 0 },
        { 0, 0, 0, 2, 2 }
    };  
    public int[,] Grid9 = {
        { 2, 2, 0, 2, 0 },
        { 2, 0, 2, 0, 0 },
        { 2 ,0, 2, 0, 2 },
        { 2, 0, 0, 2, 2 },
        { 0, 2, 0, 0, 2 }
    };

    public Vector2 T;

    [ContextMenu("ZZZ")]
    public void TestNow()
    {
        Debug.Log(GetIndex(T));
    }
    public int GetIndex(Vector2 V)
    {
        switch (Session.Instance.CurrentLevel)
        {
            case 0:
                Debug.Log(Grid1[(int) V.x, (int) V.y]);
              return  Grid1[(int) V.x, (int) V.y];
                break;
            case 1:
                return Grid2[(int) V.x, (int) V.y];

                break;  
            case 2:
                return  Grid3[(int) V.x, (int) V.y];

                break;  
            case 3:
                return  Grid4[(int) V.x, (int) V.y];

                break;  
            case 4:
                return  Grid5[(int) V.x, (int) V.y];

                break;  
            case 5:
                return   Grid6[(int) V.x, (int) V.y];

                break;  
            case 6:
                return  Grid7[(int) V.x, (int) V.y];

                break;  
            case 7:
                return  Grid8[(int) V.x, (int) V.y];

                break;
            case 8:
               return Grid9[(int) V.x, (int) V.y];

                break;
            default:
                return 2;
        }
    }
    public void SetGridIndex(Vector2 V)
    { 
        switch (Session.Instance.CurrentLevel)
        {
            case 0:
                Grid1[(int) V.x, (int) V.y] = 1;
                break;
            case 1: 
                Grid2[(int) V.x, (int) V.y] = 1;

                break;  
            case 2: 
                Grid3[(int) V.x, (int) V.y] = 1;

                break;  
            case 3: 
                Grid4[(int) V.x, (int) V.y] = 1;

                break;  
            case 4: 
                Grid5[(int) V.x, (int) V.y] = 1;

                break;  
            case 5: 
                Grid6[(int) V.x, (int) V.y] = 1;

                break;  
            case 6: 
                Grid7[(int) V.x, (int) V.y] = 1;

                break;  
            case 7: 
                Grid8[(int) V.x, (int) V.y] = 1;

                break;
            case 8: 
                Grid9[(int) V.x, (int) V.y] = 1;

                break;
        }
    }
}
