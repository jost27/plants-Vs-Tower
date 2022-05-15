using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICard : MonoBehaviour
{

    public STower tower;
    [SerializeField]
    Image towerPhoto;
    [SerializeField]
    TMP_Text cost;
    // Start is called before the first frame update
    void Start()
    {
        towerPhoto.sprite = tower.cardImage;
        cost.text = tower.SunCoinsCost.ToString();
    }

    
}
