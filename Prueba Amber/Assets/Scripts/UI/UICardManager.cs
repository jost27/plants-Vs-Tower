using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICardManager : MonoBehaviour
{
    [SerializeField] STower[] towers;

    [SerializeField] Transform cardsHolder;
    [SerializeField] GameObject cardTemplate;

  
    void Start()
    {
        CreateUICards();
    }


    // create the cards in  the UI
    void CreateUICards()
    {
        if (towers.Length == 0)
            return;
        foreach( STower tower in towers)
        {
           GameObject card= Instantiate(cardTemplate,cardsHolder);
            card.GetComponent<UICard>().tower = tower;
        }
    }
}
