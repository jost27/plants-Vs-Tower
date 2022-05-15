using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGround : MonoBehaviour
{
    [SerializeField] int YHolders;
    [SerializeField] int XHolders;
    [SerializeField] float margin;
    [SerializeField] float xoffsetbar;


    [SerializeField] GameObject PlaceHolder;
    [SerializeField] GameObject BarWay;
    [SerializeField] Transform zombitransform;
    float xoffset, yoffset;
    float xoffsetscale ,yoffsetscale;
    GameObject pivot;
    // Start is called before the first frame update
    void Start()
    {//scale place holder
        xoffsetscale = PlaceHolder.transform.localScale.x;
        yoffsetscale = PlaceHolder.transform.localScale.z;
        //offset position
        xoffset = transform.position.x;
        yoffset = transform.position.z;
        CreateGrid();
    }
    //Create the tower  places 

   void CreateGrid()
   {
        
        if(PlaceHolder==null)
        {
            Debug.LogError("missing placeholder prefab");
            return;
        }
        //place holder matrix
        for(int y=0; y < YHolders; y++)
        {
            // bar way instace
            pivot= Instantiate(BarWay, Vector3.right * (xoffset-(XHolders * (xoffsetscale + margin)*0.5f)+ xoffsetscale*0.5f ) + Vector3.forward * (yoffset + y * ((yoffsetscale) + margin)+(yoffsetscale*0.5f)),Quaternion.identity,transform);
            pivot.transform.localScale = new Vector3(XHolders * (xoffsetscale + margin), 0.2f,margin);

            for(int x=0; x< XHolders; x++)
            {
                // instance place holder
                Instantiate(PlaceHolder, Vector3.right*(xoffset- x*(xoffsetscale + margin))+ Vector3.forward*(yoffset + y*(yoffsetscale +margin)), Quaternion.identity, transform);
            }
        }
        // zombie transform position
        for (int y = 0; y < YHolders; y++)
        {
            GameObject StartZombie = new GameObject();
            StartZombie.name = "ZombieWay" + y.ToString();
            pivot = Instantiate(StartZombie, Vector3.right * (xoffset - XHolders * (xoffsetscale+margin*0.5f)) + Vector3.forward * (yoffset + y * (yoffsetscale + margin)), Quaternion.Euler(0f,90f,0f));
            pivot.transform.SetParent(zombitransform);
        }
   }
}
