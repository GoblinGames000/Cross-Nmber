
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Linq;

public class LineCreator : MonoBehaviour
{
    /// <summary>
    ///  responsible for creating and drawing lines
    /// </summary>




    public static LineCreator instance;    // for sigilton


    public GameObject linePrefab;
    public MLine activeLine;  // to store the active line 




    public int levelNumberPoint;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            // DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);

        }
    }

    private void Start()
    {

        // set the gameobject acitve to show it on screen 
        //******** UiManager.instance.lineSizeLeft.gameObject.SetActive(true); 



    }

    public bool is_drawing = false;
    public bool enable_to_drawing = true;

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0) && enable_to_drawing == true)
       // if (Input.GetMouseButtonDown(0) && IsPointerOverUIObject() == false && enable_to_drawing == true)
        {
            is_drawing = true;
            GameObject lineGO = Instantiate(linePrefab);
            lineGO.transform.parent = transform.parent;
            activeLine = lineGO.GetComponent<MLine>();
            activeLine.name = "Line";


        }

        if (Input.GetMouseButtonUp(0) && is_drawing == true)
      //  if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject() && is_drawing == true)
        {
          //  enable_to_drawing = false;
           is_drawing = false;
            activeLine.SetRigidBodyType(RigidbodyType2D.Dynamic);
            UpdateLineStatus();
            activeLine = null;


        }
        if (activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.Updateline(mousePos);


        }



        /*  if (Input.GetMouseButtonDown(0) && IsPointerOverUIObject() == false)
          {
              // Check if the mouse was clicked over a UI element

              GameObject lineGO = Instantiate(linePrefab);
              activeLine = lineGO.GetComponent<MLine>();
              activeLine.name = "Line";


              //showing the line left size by increase the ui Alpha 
              //****************	UiManager.instance.sizeLeftCanvas.alpha = 1f;

          }

          if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
          {
              //showing the line left size by increase the ui Alpha 
              //******** UiManager.instance.sizeLeftCanvas.alpha = 0.5f;

              //made the line rigidbody 2d dynamic 
              activeLine.SetRigidBodyType(RigidbodyType2D.Dynamic);

              activeLine = null;

          }

          if (activeLine != null)
          {
              Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
              activeLine.Updateline(mousePos);


          }*/
    }

    //sfg



    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }





    // update the number of points left 
    public void UpdateLineStatus()
    {
        activeLine.SetRigidBodyType(RigidbodyType2D.Dynamic);
     //   this.gameObject.SetActive(false);\
     FindObjectsOfType<Ball>().ToList().ForEach(x=>
     {
         x.GetComponent<Rigidbody2D>().gravityScale = 1;
         x.GetComponent<CircleCollider2D>().enabled = true;
     });
       
    }

}
