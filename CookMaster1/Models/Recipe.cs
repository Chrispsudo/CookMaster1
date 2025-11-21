using System;

namespace CookMaster1.Models
{
    public class Recipe
    {
        // Title of the recipe

        public string Title { get; set; }

        // Ingredients in textformat

        public string Ingredients { get; set; }

        // Instructions in textformat

        public string Instructions { get; set; }

        // Category of the recipe (e.g., Dessert, Main Course)

        public string Category { get; set; }

        // Date when the recipe was created

        public DateTime Date { get; set; }

        // Reference to the user who created the recipe

        public User CreatedBy { get; set; }

        // Updates the recipe details

        public void EditRecipe(string title, string ingredients, string instructions, string category)
        {
            Title = title;
            Ingredients = ingredients;
            Instructions = instructions;
            Category = category;
        }

        // Create a copy of the recipe

        public Recipe CopyRecipe()
        {
            return (Recipe)this.MemberwiseClone();
        }


    }
}
