using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MLine : MonoBehaviour
{

    /// <summary>
    /// 
    /// 
    /// the line object that we instantiate with line creator 
    /// by passing the line creator values (point positions and give theme to that script)
    /// 
    /// by giving the line rendrer those value ... the line is created 
    /// give it to polygonecolider too 
    /// 
    /// 
    /// </summary>

    private Rigidbody2D rigidbody2D; // the line regedbody
    private PolygonCollider2D polygonCollider2D;

    private int numberOfPointAdedToLine = 0;   //this value is change when a point added to the line 


    private static float halfWidth, angle;   //half with (line from line rendree)
    private List<Vector2> polygon2DPoints;   //point for polygoncolider 2d


    private float lineResistance = 100f;     //how much resistance every line is 
    private float MlevellineValue;

    private LineRenderer mlineRendrer;  //declare line rendrer 
    private EdgeCollider2D medgeCollider2D; //declare edge collider2d for the line 
    private List<Vector2> mpoints; // list to store line points on it  


    public void setlineResistance(float lineforce11)
    {
        lineResistance = lineforce11;
    }


    public void Updateline(Vector2 mousePos)
    {
       
        if(mpoints == null)  // there is no list yet 
        {
            mpoints = new List<Vector2>();
            setPoint(mousePos);
            return;
        }

        if (Vector2.Distance(mpoints.Last(), mousePos) > .1f)    // verfiy if the distance between the last mosepos and the new one is grater then 1 
            setPoint(mousePos);
        // ps : make sur to add that line " using System.Linq; " above the script to be able to use "last() methode"
        //last() gives you the last item on the list 
    }


    private void setPoint(Vector2 newPoint)     //used to add new points "mouse position" to the list point
    {
        mpoints.Add(newPoint);    //adding the point 
       // numberOfPointAdedToLine++;  //add 1 to number of points 
       // LineCreator.instance.UpdateLineStatus();

        int index = mpoints.Count - 1;

        mlineRendrer.positionCount = mpoints.Count;              // giving the line rendrer the number of points to draw 
        mlineRendrer.SetPosition(mpoints.Count - 1, newPoint);   // give the line rendrer the last position "the last point position"

       /* if (mpoints.Count > 1)   // we can't add an edgeColider to one point we need at least to two point so this line to to verify
            medgeCollider2D.points = mpoints.ToArray();  */
        // if it's more then one so give the edgecolider the points 

        Vector2 tempVector = newPoint;
        Vector2 direction;
        direction = mpoints[index] - mpoints[index + 1 < mpoints.Count ? index + 1 : (index - 1 >= 0 ? index - 1 : index)];
        angle = Mathf.Atan2(direction.x, -direction.y);

        tempVector.x = tempVector.x + halfWidth * Mathf.Cos(angle);
        tempVector.y = tempVector.y + halfWidth * Mathf.Sin(angle);
        polygon2DPoints.Insert(polygon2DPoints.Count, tempVector);

        tempVector = newPoint;
        tempVector.x = tempVector.x - halfWidth * Mathf.Cos(angle);
        tempVector.y = tempVector.y - halfWidth * Mathf.Sin(angle);
        polygon2DPoints.Insert(0, tempVector);

        polygonCollider2D.points = polygon2DPoints.ToArray();

        // polygonCollider2D.points =mpoints.ToArray
        // polygonCollider2D.enabled = true;


    }


    private void Awake()
    {
        mlineRendrer = GetComponent<LineRenderer>();
        medgeCollider2D = GetComponent<EdgeCollider2D>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();


        halfWidth = mlineRendrer.endWidth / 2.0f;
        polygon2DPoints = new List<Vector2>();

    }

    private void Start()
    {
        MlevellineValue = lineResistance;
        //****LineResistanceManager.instance.setupdAlllienResistance(lineResistance);

    }



    private void Update()
    {
       
    }



    public void SetRigidBodyType(RigidbodyType2D type)  // used to change the state of rigidbody 
    {
        rigidbody2D.bodyType = type;
    }


   /* private void OnCollisionEnter2D(Collision2D collision)     // nbedelha b car 
    {
        if (collision.gameObject.CompareTag("Metaball_liquid"))
        {
            MlevellineValue--;
            if (MlevellineValue == 0 || MlevellineValue < 0)
            {

                Destroy(this.gameObject);
            }

            LineResistanceManager.instance.updateAllLineResistance();
            //call lienForceManager;

            //HealthBarImage.instance.setHealthValue(MlevellineValue / lineForce);

        }
    }*/


    public int getNumberOfLinePoints()
    {
        return numberOfPointAdedToLine;
    }


}
