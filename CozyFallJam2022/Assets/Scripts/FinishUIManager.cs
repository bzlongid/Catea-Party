using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishUIManager : MonoBehaviour
{
    public TMP_Text message;

    // Start is called before the first frame update
    void Start()
    {
        if (!SelectedRecipe.win)
        {
            message.text = "Let's try again!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
