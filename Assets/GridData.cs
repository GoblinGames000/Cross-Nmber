using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GridData : MonoBehaviour
{
    // Define the 2D array and initialize it with data
    public int[,] Grid1 = {
        { 2, 0, 0, 2 },
        { 0, 2, 0, 0 },
        { 0, 2, 0, 0 },
        { 0, 0, 2, 0 }
    };  
    public int[,] Grid2 = {
        { 2, 0, 0 },
        { 0, 2, 0 },
        { 0, 0, 2 }
    }; 
    public int[,] Grid3 = {
        { 2, 0, 0, 2 },
        { 0, 2, 2, 0 },
        { 2, 0, 2, 0 },
        { 2, 2, 0, 2 }
    };  
    public int[,] Grid4 = {
        { 2, 0, 0, 2 },
        { 0, 2, 0, 2 },
        { 2, 0, 2, 0 },
        { 0, 2, 0, 2 }
    };  
    public int[,] Grid5 = {
        { 2, 0, 0, 2 },
        { 0, 2, 0, 0 },
        { 0, 0, 2, 0 },
        { 0, 2, 2, 2 }
    };  
    public int[,] Grid6 = {
        { 2, 0, 2, 0, 0 },
        { 2, 0, 2, 2, 2 },
        { 0, 2, 0, 2, 0 },
        { 2, 0, 2, 2, 0 },
        { 0, 0, 0, 0, 2 }
    }; 
    public int[,] Grid7 = {
        { 2, 0, 0, 0, 2 },
        { 0, 2, 2, 2, 0 },
        { 0, 0, 2, 2, 2 },
        { 2, 0, 0, 2, 2 },
        { 0, 2, 0, 2, 2 }
    };  
    public int[,] Grid8 = {
        { 2, 0, 2, 0, 2 },
        { 0, 2, 2, 0, 2 },
        { 2, 0, 2, 2, 0 },
        { 2, 2, 0, 0, 0 },
        { 0, 0, 2, 0, 0 }
    };  
    public int[,] Grid9 = {
        { 0, 0, 2, 2, 2 },
        { 2, 0, 0, 2, 0 },
        { 0, 2, 2, 0, 0 },
        { 2, 0, 0, 0, 2 },
        { 2, 2, 2, 2, 0 }
    };  
}
