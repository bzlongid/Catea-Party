using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CongratsMessage : MonoBehaviour
{
    public TMP_Text message;

    private void Update()
    {
        if (!SelectedRecipe.win)
        {
            message.text = "Oh no! Out of time!";
        }
        message.text = "Cooking complete!";
    }
}
