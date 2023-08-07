using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ConnectingDots : MonoBehaviour
{
    public int gridSizeX;
    public int gridSizeY;
    public float dotSpacing = 1f;
    public float connectDelay = 0.5f;
    public float destroyDelay = 0.25f;
    public GameObject dotPrefab;
    public GameObject linePrefab;
    public List<Sprite> Colors;
    private int[,] dots;
    private GameObject[,] dotsObj;
    public List<GameObject> selectedDots = new List<GameObject>();
    public LineRenderer currentLineRenderer;

    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        dots = new int[gridSizeX, gridSizeY];
        dotsObj = new GameObject[gridSizeX, gridSizeY];

        for (int i = 0; i < gridSizeX; i++)
        {
            for (int j = 0; j < gridSizeY; j++)
            {
                int rnd = Random.Range(0, Colors.Count);
                Vector3 dotPosition = new Vector3(i * dotSpacing, j * dotSpacing, 0);
                GameObject dot = Instantiate(dotPrefab, dotPosition, Quaternion.identity);
                dot.GetComponent<SpriteRenderer>().sprite = Colors[rnd];
                dot.name = i + "," + j;
                dot.transform.parent = transform;
                dot.GetComponent<Element>().X = i;
                dot.GetComponent<Element>().Y = j;
                dot.GetComponent<Element>().index= rnd;
                dots[i, j] = rnd;
                dotsObj[i, j] = dot;
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject.CompareTag("Dot"))
            {
                if (!selectedDots.Contains(hit.collider.gameObject))
                {
                    SelectDot(hit.collider.gameObject);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            currentLineRenderer.positionCount = 0;
           // ConnectDots();
        }

        if (Input.GetMouseButton(0))
        {
            if (selectedDots.Count > 0)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;
                float distance = Vector3.Distance(selectedDots[selectedDots.Count - 1].transform.position, mousePosition);
        
                if (distance <= 100)
                {
                    currentLineRenderer.positionCount = selectedDots.Count + 1;
                    currentLineRenderer.SetPosition(selectedDots.Count, mousePosition);
                }
            }
        }
    }

    public List<Color> C;
    void SelectDot(GameObject dot)
    {
        if (selectedDots.Count == 0)
        {
            selectedDots.Add(dot);
            if (currentLineRenderer == null)
            {
                currentLineRenderer = Instantiate(linePrefab, transform).GetComponent<LineRenderer>();
            }

            currentLineRenderer.startWidth = 0.1f;
            currentLineRenderer.endWidth = 0.1f;
            currentLineRenderer.positionCount = 1;
            currentLineRenderer.SetPosition(0, dot.transform.position);
            currentLineRenderer.startColor = C[dot.GetComponent<Element>().index];
            currentLineRenderer.endColor = C[dot.GetComponent<Element>().index];
        }
        else
        {
            GameObject lastSelectedDot = selectedDots[selectedDots.Count - 1];

            if (IsAdjacent(dot, lastSelectedDot)&& selectedDots[selectedDots.Count-1].GetComponent<SpriteRenderer>().sprite.name==dot.GetComponent<SpriteRenderer>().sprite.name)
            {
                selectedDots.Add(dot);
                currentLineRenderer.positionCount = selectedDots.Count;
                currentLineRenderer.SetPosition(selectedDots.Count - 1, dot.transform.position);
            }
        }
    }

    bool IsAdjacent(GameObject dot1, GameObject dot2)
    {
        Vector3 dot1Pos = dot1.transform.position;
        Vector3 dot2Pos = dot2.transform.position;
        float distance = Vector3.Distance(dot1Pos, dot2Pos);

        return distance < dotSpacing + 0.1f;
    }

    // IEnumerator InstantiateDots()
    // {
    //     // Wait for a delay before instantiating new dots
    //     yield return new WaitForSeconds(connectDelay);
    //
    //     // Instantiate new dots and animate their appearance using DOTween
    //     for (int i = 0; i < gridSizeX; i++)
    //     {
    //         for (int j = 0; j < gridSizeY; j++)
    //         {
    //             Vector3 dotPosition = new Vector3(i * dotSpacing, j * dotSpacing, 0);
    //             GameObject dot = Instantiate(dotPrefab, dotPosition, Quaternion.identity);
    //             dot.name = "Dot " + i + "," + j;
    //             dot.transform.parent = transform;
    //             dot.transform.localScale = Vector3.zero;
    //             dot.transform.DOScale(Vector3.one, 0.5f);
    //         }
    //     }
    // }
    // IEnumerator DrawLine(Vector3 startPos, Vector3 endPos, float delay)
    // {
    //     GameObject line = new GameObject("Line");
    //     LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
    //     lineRenderer.startWidth = 0.1f;
    //     lineRenderer.endWidth = 0.1f;
    //     lineRenderer.SetPosition(0, startPos);
    //     lineRenderer.SetPosition(1, endPos);
    //     yield return new WaitForSeconds(delay);
    //     Destroy(line);
    // }
    void ConnectDots()
    {
        if (selectedDots.Count >= 2)
        {
            for (int i = 0; i < selectedDots.Count - 1; i++)
            {
                GameObject dot1 = selectedDots[i];
                GameObject dot2 = selectedDots[i + 1];
            
                // Instantiate a new line prefab and set its positions
                GameObject newLine = Instantiate(linePrefab, transform);
                LineRenderer lineRenderer = newLine.GetComponent<LineRenderer>();
                lineRenderer.startWidth = 0.1f;
                lineRenderer.endWidth = 0.1f;
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, dot1.transform.position);
                lineRenderer.SetPosition(1, dot2.transform.position);
            
                // Destroy the line after a delay
                Destroy(newLine, destroyDelay);
            }

          //  GameManager.Instance.Steps -= 1;
            // Animate the destruction of the selected dots using DOTween
            // foreach (GameObject dot in selectedDots)
            // {
            //     if (GameManager.Instance.ToCollect.Contains(dot.GetComponent<SpriteRenderer>().sprite.name))
            //     {
            //         int index = GameManager.Instance.ToCollect.IndexOf(dot.GetComponent<SpriteRenderer>().sprite.name);
            //         if (index == 0)
            //         {
            //             GameManager.Instance.ACount += 1;
            //         }
            //         else
            //         {
            //             GameManager.Instance.BCount += 1;
            //
            //         }
            //     }
            //     RemoveDot(dot.GetComponent<Element>().X,dot.GetComponent<Element>().Y);
            //     dot.transform.DOScale(Vector3.zero, 0.5f).OnComplete(() => Destroy(dot));
            // }

            selectedDots.Clear();

            // Instantiate new dots after a delay
          //  StartCoroutine(InstantiateDots());
        }
        else
        {
            selectedDots.Clear();

        }
    }
    
    
    void RemoveDot(int x, int y)
    {
        
        // remove the tile from the board
        dots[x, y] = -1;
        GameObject Obj = dotsObj[x, y];
        dotsObj[x, y]   = null;
        SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Item);

     //   Obj.GetComponentInChildren<ParticleSystem>().Play();
      //  Obj.GetComponentInChildren<ParticleSystem>().transform.parent = null;
//         if (currentlevel.ToString() == Obj.GetComponent<SpriteRenderer>().sprite.name)
//         {
//             Target--;
//             Obj.GetComponent<SpriteRenderer>().sortingOrder += 1;
//             Obj.transform.DOJump(Targetposition.position, 1,1,0.75f).OnComplete(() =>
//             {
//                 Destroy(Obj);
//             }).SetEase(Ease.InOutSine);       
//         }
//         else
//         {
//             Obj.transform.DOScale(Vector3.zero, 0.5f).OnComplete(() =>
//             {
//                  Destroy(Obj);
//             }).SetEase(Ease.OutBounce).OnStart(() =>
//                 {
//                 });
// }
        // remove the tile game object from the scene
    

        // move the tiles above the removed tile down to fill in the empty space
        for (int i = y + 1; i < gridSizeY; i++)
        {
            if (dots[x, i] != -1)
            {
                dots[x, i - 1] = dots[x, i];
                dots[x, i] = -1;
                dotsObj[x, i - 1] = dotsObj[x, i];
                dotsObj[x, i] = null;
                dotsObj[x, i - 1].transform.DOMove(new Vector2(x * dotSpacing, (i - 1) * dotSpacing), 0.5f).SetEase(Ease.OutBounce);
              //  tileObjects[x, i - 1].transform.position = new Vector2(x*PosX, (i - 1)*PosY);
              dotsObj[x, i - 1].GetComponent<Element>().X = x;
              dotsObj[x, i - 1].GetComponent<Element>().Y = i-1;
            }
        }

        // generate a new tile to replace the removed tile
        int newTileType = Random.Range(0, Colors.Count);
        dots[x, gridSizeY-1] = newTileType;
        GameObject newTileObject = Instantiate(dotPrefab, new Vector2(x*dotSpacing, (gridSizeY-1)*dotSpacing), Quaternion.identity);
        newTileObject.transform.parent = transform;
        newTileObject.GetComponent<SpriteRenderer>().sprite = Colors[newTileType];
        newTileObject.GetComponent<Element>().X = x;
        newTileObject.GetComponent<Element>().Y = gridSizeY-1;
        newTileObject.GetComponent<Element>().index= newTileType;

        dotsObj[x, gridSizeY-1] = newTileObject;
        
        
      
        
    }
  
}