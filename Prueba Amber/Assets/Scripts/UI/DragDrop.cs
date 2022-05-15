using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DragDrop : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    Camera maincamera;// get the camera for a pointer position
    GameObject canvas;   //parents card sockets
    STower tower;// info towers
    Sprite towerimage; // image to drag
    GameObject imgObject;//gameobject dragged
    ShopTowers shop;
    RaycastHit hit;


    void Start()
    {
        maincamera = FindObjectOfType<Camera>();
        shop = FindObjectOfType<ShopTowers>();

        tower= gameObject.GetComponent<UICard>().tower;

        canvas = transform.parent.gameObject;
        canvas = canvas.transform.parent.gameObject;
        towerimage = tower.cardImage;
       

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!shop.CanBuyTower(tower.SunCoinsCost))
            return;

        imgObject = new GameObject("Card Dragged");

        RectTransform trans = imgObject.AddComponent<RectTransform>();
        trans.transform.SetParent(canvas.transform); // setting parent
        trans.localScale = Vector3.one;
        trans.anchoredPosition = new Vector2(0f, 0f); // setting position, will be on center
        trans.sizeDelta = new Vector2(70, 70); // custom size
        
        
        Image image = imgObject.AddComponent<Image>();
        image.preserveAspect = true;
        image.sprite =towerimage;//Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        imgObject.transform.SetParent(canvas.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!shop.CanBuyTower(tower.SunCoinsCost))
            return;
        // get mouse pointer in 3D
        imgObject.transform.position = Input.mousePosition;
        Ray ray = maincamera.ScreenPointToRay(Input.mousePosition);// transform mouse position in 3D
        Physics.Raycast(ray, out hit);// Get the hit raycast 
       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!shop.CanBuyTower(tower.SunCoinsCost))
            return;
        Destroy(imgObject);
       
        if (hit.transform== null)
            return;

        if (hit.transform.gameObject.GetComponent<PlaceHolder>() == null)
            return;

        hit.transform.gameObject.GetComponent<PlaceHolder>().CreateTower(tower);
        shop.BuyTower(tower.SunCoinsCost);
    }
}
