// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;
// using DG.Tweening;
// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;
// using Random = UnityEngine.Random;
// using MoreMountains.NiceVibrations;
//
// public class Match2DGame : MonoBehaviour
// {
//     public Sprite[] tileSprites; // an array of the 6 different tile sprites
//     public int _Target; // the current number of moves the player has made in a level
//     public int _currentMoves; // the current number of moves the player has made in a level
//     public TextMeshProUGUI Targettxt;
//     public TextMeshProUGUI Moves;
//     public int currentlevel;
//
//    
//     public int currentMoves
//     {
//         get => _currentMoves;
//         set
//         {
//             _currentMoves = value;
//             
//             Moves.text = _currentMoves.ToString();
//             if (_currentMoves <= 0)
//             {
//                 CanvasManager.Instance.Gamestate = States.Lose;
//             }
//             
//         }
//     }
//
//     private bool Inc;
//     public int Target
//     {
//         get => _Target;
//         set
//         {
//          
//             _Target = value;
//             if (_Target <= 0)
//             {
//                 _Target = 0;
//                 LevelData.Instance.Levels[currentlevel].IsCompleted = true;
//                 if (Session.Instance.CurrentLevel != -1)
//                 {
//                     if (!Inc)
//                     {
//                         Inc = true;
//                         Session.Instance.CurrentLevel += 1;
//                     }
//                 }
//
//                 CanvasManager.Instance.Gamestate = States.Win;
//             }
//             Targettxt.text = _Target.ToString();
//            
//             
//         }
//     }
//     // the current number of moves the player has made in a level
//    // the current score for the player in a level
//     public int[,] board = new int[7, 7]; // a 7x7 array representing the game board
//     public GameObject[,] tileObjects = new GameObject[7, 7]; // a 7x7 array of tile game objects on the board
//     public GameObject tilePrefab; // the prefab for the tile game objects
//     private int adjacentX; // the x-coordinate of the adjacent tile
//     private int adjacentY; // the y-coordinate of the adjacent tile
//     public float PosX;
//     public float PosY;
//
//     private void OnEnable()
//     {
//        
//     }
//
//     void Start()
//     {
//         if (Session.Instance.CurrentLevel == -1)
//         {
//             
//         currentlevel = LevelData.Instance.Levels.IndexOf(LevelData.Instance.Levels.FirstOrDefault(x => !x.IsCompleted));
//         if (currentlevel == -1)
//         {
//             currentlevel = 0;
//         }
//         }
//         else
//         {
//             currentlevel = Session.Instance.CurrentLevel;
//             if (currentlevel >5)
//             {
//                 currentlevel = 0;
//             }
//         }
//
//         currentMoves = LevelData.Instance.Levels[currentlevel].Moves;
//         Target = LevelData.Instance.Levels[currentlevel].Colectable;
//         Gameplaysp.sprite = ItemsSP[currentlevel];
//         // initialize the game board with random tile types
//         for (int i = 0; i < 7; i++)
//         {
//             for (int j = 0; j < 7; j++)
//             {
//                 int tileType = Random.Range(0, 6);
//                 board[i, j] = tileType;
//                 GameObject tileObject = Instantiate(tilePrefab, new Vector2(i*PosX, j*PosY), Quaternion.identity);
//                 tileObject.transform.parent = transform.parent;
//                 tileObject.GetComponent<SpriteRenderer>().sprite = tileSprites[tileType];
//                 tileObject.GetComponent<Element>().X = i;
//                 tileObject.GetComponent<Element>().Y = j;
//                 tileObjects[i, j] = tileObject;
//             }
//         }
//     }
//
//     void Update()
//     {
//         if(CanvasManager.Instance.Gamestate!=States.Game) return;
//         // handle player input
//         // if (Input.GetMouseButtonDown(0))
//         // {
//         //     RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
//         //     if (hit.collider != null)
//         //     {
//         //         // get the position of the clicked tile on the board
//         //         int x = (int) hit.collider.GetComponent<Element>().X;
//         //         int y = (int)hit.collider.GetComponent<Element>().Y;
//         //         List<(int, int)> adjacentTiles = GetAdjacentTiles(x, y, board[x, y], new List<(int, int)>());
//         //         if (adjacentTiles.Count > 1)
//         //         {
//         //             for (int i = 0; i < adjacentTiles.Count; i++)
//         //             {
//         //                 Debug.Log("Remove");
//         //                 RemoveTile(adjacentTiles[i].Item1, adjacentTiles[i].Item2);
//         //             }
//         //             currentMoves--;
//         //
//         //         }
//         //         else
//         //         {
//         //             Debug.Log("Stuck here");
//         //             hit.transform.GetComponent<Element>().Shake();
//         //             if (PlayerPrefs.GetInt(Constants.Vibration, 1) == 1)
//         //             {
//         //                 MMVibrationManager.Haptic(HapticTypes.Failure);
//         //             }
//         //         }
//         //     }
//         // }
//     }
//
//
//     List<(int, int)> GetAdjacentTiles(int x, int y, int tileType, List<(int, int)> adjacentTiles)
//     {
//         if (x > 0 && board[x - 1, y] == tileType && !adjacentTiles.Contains((x - 1, y)))
//         {
//             adjacentTiles.Add((x - 1, y));
//             GetAdjacentTiles(x - 1, y, tileType, adjacentTiles);
//         }
//
//         if (x < 6 && board[x + 1, y] == tileType && !adjacentTiles.Contains((x + 1, y)))
//         {
//             adjacentTiles.Add((x + 1, y));
//             GetAdjacentTiles(x + 1, y, tileType, adjacentTiles);
//         }
//
//         if (y > 0 && board[x, y - 1] == tileType && !adjacentTiles.Contains((x, y - 1)))
//         {
//             adjacentTiles.Add((x, y - 1));
//             GetAdjacentTiles(x, y - 1, tileType, adjacentTiles);
//         }
//
//         if (y < 6 && board[x, y + 1] == tileType && !adjacentTiles.Contains((x, y + 1)))
//         {
//             adjacentTiles.Add((x, y + 1));
//             GetAdjacentTiles(x, y + 1, tileType, adjacentTiles);
//         }
//
//         return adjacentTiles;
//     }
//
//     public List<Sprite> ItemsSP;
//     public Image Gameplaysp;
//     public Transform Targetposition;
//     void RemoveTile(int x, int y)
//     {
//         // remove the tile from the board
//         board[x, y] = -1;
//         GameObject Obj = tileObjects[x, y];
//         tileObjects[x, y]   = null;
//         SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Item);
//
// Obj.GetComponentInChildren<ParticleSystem>().Play();
// Obj.GetComponentInChildren<ParticleSystem>().transform.parent = null;
// if (currentlevel.ToString() == Obj.GetComponent<SpriteRenderer>().sprite.name)
// {
//     Target--;
//     Obj.GetComponent<SpriteRenderer>().sortingOrder += 1;
//     Obj.transform.DOJump(Targetposition.position, 1,1,0.75f).OnComplete(() =>
//     {
//         Destroy(Obj);
//     }).SetEase(Ease.InOutSine);       
// }
// else
// {
//      Obj.transform.DOScale(Vector3.zero, 0.5f).OnComplete(() =>
//      {
//          Destroy(Obj);
//         }).SetEase(Ease.OutBounce).OnStart(() =>
//         {
//         });
// }
//         // remove the tile game object from the scene
//     
//
//         // move the tiles above the removed tile down to fill in the empty space
//         for (int i = y + 1; i < 7; i++)
//         {
//             if (board[x, i] != -1)
//             {
//                 board[x, i - 1] = board[x, i];
//                 board[x, i] = -1;
//                 tileObjects[x, i - 1] = tileObjects[x, i];
//                 tileObjects[x, i] = null;
//                 tileObjects[x, i - 1].transform.DOMove(new Vector2(x * PosX, (i - 1) * PosY), 0.5f).SetEase(Ease.OutBounce);
//               //  tileObjects[x, i - 1].transform.position = new Vector2(x*PosX, (i - 1)*PosY);
//                 tileObjects[x, i - 1].GetComponent<Element>().X = x;
//                 tileObjects[x, i - 1].GetComponent<Element>().Y = i-1;
//             }
//         }
//
//         // generate a new tile to replace the removed tile
//         int newTileType = Random.Range(0, 6);
//         board[x, 6] = newTileType;
//         GameObject newTileObject = Instantiate(tilePrefab, new Vector2(x*PosX, 6*PosY), Quaternion.identity);
//         newTileObject.transform.parent = transform.parent;
//         newTileObject.GetComponent<SpriteRenderer>().sprite = tileSprites[newTileType];
//         newTileObject.GetComponent<Element>().X = x;
//         newTileObject.GetComponent<Element>().Y = 6;
//         tileObjects[x, 6] = newTileObject;
//         
//     }
// }