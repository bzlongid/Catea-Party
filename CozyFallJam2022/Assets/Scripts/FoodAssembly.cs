using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodAssembly : MonoBehaviour
{
    public GameObject congratsPanel;
    public TMP_Text congratsMsg;
    public GameObject directionsPanel;

    // Ingredient previews
    public Image[] UIimages;
    public Sprite[] AllIngredientSprites;

    // Timer
    public float TimeLeft;
    public bool TimerOn = false;
    public TMP_Text TimerTxt;

    void Start()
    {
        SetUpUI();
        //Pause time for directions
    }

    public void Update()
    {
        if (TimerOn)
        {
            if(TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                UpdateTimer(TimeLeft);
            }
            else
            {
                TimeLeft = 0;
                TimerOn = false;
                SelectedRecipe.win = false;
                congratsMsg.text = "Oh no! Out of time!";
                congratsPanel.SetActive(true);
            }
        }
    }

    public void SetUpUI()
    {
        int i = 0;
        foreach (Image previewImg in UIimages) //iterate through UI
        {
            if (i < SelectedRecipe.ingredients.Length)
            {
                previewImg.sprite = SelectedRecipe.ingredients[i];
                i++;
            }
            else
            {
                previewImg.enabled = false;
            }
        }
    }

    public void StartTimer()
    {
        TimerOn = true;
    }

    public void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void CloseDirections()
    {
        directionsPanel.SetActive(false);
        StartTimer();
    }
}
