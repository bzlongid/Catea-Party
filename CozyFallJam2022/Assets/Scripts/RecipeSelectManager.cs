using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RecipeSelectManager : MonoBehaviour
{
    public TMP_Text nameText;
    public Image previewPic;
    public List<Recipe> RecipeBook;
    int i = 0;

    private void Start()
    {
        SelectRecipe(RecipeBook[i]);
    }

    public void SelectRecipe(Recipe recipe)
    {
        // Update the UI
        nameText.text = recipe.dishName;
        previewPic.sprite = recipe.picture;
        previewPic.SetNativeSize();
        previewPic.enabled = true;

        // Set the recipe
        SelectedRecipe.dishName = recipe.dishName;
        SelectedRecipe.ingredients = recipe.ingredients;
        SelectedRecipe.picture = recipe.picture;
        Debug.Log("Selected recipe is: " + SelectedRecipe.dishName + ". Num of Ingredients: " + SelectedRecipe.ingredients.Length);
    }

    public void ScrollLeft()
    {
        if (i == 0)
        {
            i = RecipeBook.Count - 1;
        }
        else
        {
            i--;
        }

        SelectRecipe(RecipeBook[i]);
    }

    public void ScrollRight()
    {
        if (i == (RecipeBook.Count - 1))
        {
            i = 0;
        }
        else
        {
            i++;
        }

        SelectRecipe(RecipeBook[i]);
    }
}
