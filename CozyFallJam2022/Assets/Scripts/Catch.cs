using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch : MonoBehaviour
{
    public GameObject congratsPanel;
    public AudioSource rightSound;
    public AudioSource wrongSound;

    private int caught;

    // Start is called before the first frame update
    void Start()
    {
        caught = 0;
        congratsPanel.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string objCaught = collision.gameObject.name;
        string target = SelectedRecipe.ingredients[caught].name + "(Clone)";

        // check if the item entered the top of the bowl
        Vector2 contactPoint = collision.contacts[0].point;
        Vector2 foodCenter = collision.collider.bounds.center;

        if (contactPoint.y < foodCenter.y)
        {
            // check if 
            if (objCaught == target)
            {
                rightSound.Play();
                caught++;
                if (caught == SelectedRecipe.ingredients.Length)
                {
                    SelectedRecipe.win = true;
                    congratsPanel.SetActive(true);
                }
            }
            else
            {
                wrongSound.Play();
                //play audio, deduct points
            }
            Destroy(collision.gameObject);
        }
        
    }
}
