using CookMaster1.Models;
using System.Collections.Generic;
using System.Linq;

namespace CookMaster1.Services
{
    public class RecipeManager
    {
        // List of all recipes

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();

        // Add new recipe to the list

        public void AddRecipe(Recipe recipe)
        {
            Recipes.Add(recipe);
        }

        // Remove recipe from the list
        public void RemoveRecipe(Recipe recipe)
        {
            Recipes.Remove(recipe);
        }

        // Get all recipes
        public List<Recipe> GetAllRecipes()
        {
            return Recipes;
        }

        // Get all recipes by a specific user
        public List<Recipe> GetRecipesByUser(User user)
        {
            return Recipes.Where(r => r.CreatedBy == user).ToList();
        }

        // Filter recipes based on text

        public List<Recipe> Filter(string Criteria)
        {
            return Recipes.Where(r => r.Title.Contains(Criteria) ||
                                      r.Ingredients.Contains(Criteria) ||
                                      r.Instructions.Contains(Criteria) ||
                                      r.Category.Contains(Criteria)).ToList();
        }


    }
}
