using CookMaster1.Models;
using CookMaster1.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace CookMaster1.ViewModels
{
    /// <summary>
    /// ViewModel for the recipe list view.
    /// Exposes an ObservableCollection of Recipe and commands to manipulate them.
    /// </summary>
    public class RecipeListVM : BaseViewModel
    {
        private readonly RecipeManager _recipeManager;

        private ObservableCollection<Recipe> _recipes = new ObservableCollection<Recipe>();
        public ObservableCollection<Recipe> Recipes
        {
            get => _recipes;
            set
            {
                _recipes = value;
                OnPropertyChanged(nameof(Recipes));
            }
        }

        private Recipe _selectedRecipe;
        public Recipe SelectedRecipe
        {
            get => _selectedRecipe;
            set
            {
                _selectedRecipe = value;
                OnPropertyChanged(nameof(SelectedRecipe));
            }
        }

        private string _filterText;
        public string FilterText
        {
            get => _filterText;
            set
            {
                _filterText = value;
                OnPropertyChanged(nameof(FilterText));
                ApplyFilter();
            }
        }

        // Commands
        public ICommand RefreshCommand { get; }
        public ICommand AddRecipeCommand { get; }
        public ICommand RemoveRecipeCommand { get; }
        public ICommand OpenDetailsCommand { get; }
        public ICommand EditRecipeCommand { get; }

        // Parameterless ctor required for XAML instantiation
        public RecipeListVM()
        {
            _recipeManager = new RecipeManager();

            RefreshCommand = new RelayCommand(Refresh);
            AddRecipeCommand = new RelayCommand(AddRecipe);
            RemoveRecipeCommand = new RelayCommand(RemoveRecipe, CanRemove);
            OpenDetailsCommand = new RelayCommand(OpenDetails, CanOpenDetails);
            EditRecipeCommand = new RelayCommand(EditRecipe, CanOpenDetails);

            // Load initial data
            LoadRecipes();
        }

        private void LoadRecipes()
        {
            // Load from manager and convert to ObservableCollection
            var list = _recipeManager.GetAllRecipes();
            Recipes = new ObservableCollection<Recipe>(list);
            if (Recipes.Any())
                SelectedRecipe = Recipes.First();
        }

        private void Refresh()
        {
            LoadRecipes();
        }

        private void ApplyFilter()
        {
            if (string.IsNullOrWhiteSpace(FilterText))
            {
                LoadRecipes();
                return;
            }

            var filtered = _recipeManager.Filter(FilterText);
            Recipes = new ObservableCollection<Recipe>(filtered);
            if (Recipes.Any())
                SelectedRecipe = Recipes.First();
            else
                SelectedRecipe = null;
        }

        private void AddRecipe()
        {
            // Quick placeholder: in the future open AddRecipeWindow.
            // For now, create a simple dummy recipe so you can test the list.
            var r = new Recipe
            {
                Title = "New Recipe " + DateTime.Now.ToString("HHmmss"),
                Category = "Uncategorized",
                Ingredients = "Add ingredients",
                Instructions = "Add instructions",
                Date = DateTime.Now
            };
            _recipeManager.AddRecipe(r);
            Recipes.Add(r);
            SelectedRecipe = r;
        }

        private bool CanRemove()
        {
            return SelectedRecipe != null;
        }

        private void RemoveRecipe()
        {
            if (SelectedRecipe == null)
            {
                MessageBox.Show("Select a recipe to remove.");
                return;
            }

            if (MessageBox.Show($"Remove '{SelectedRecipe.Title}'?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _recipeManager.RemoveRecipe(SelectedRecipe);
                Recipes.Remove(SelectedRecipe);
                SelectedRecipe = Recipes.FirstOrDefault();
            }
        }

        private bool CanOpenDetails()
        {
            return SelectedRecipe != null;
        }

        private void OpenDetails()
        {
            if (SelectedRecipe == null)
            {
                MessageBox.Show("Select a recipe to view details.");
                return;
            }

            // Placeholder: open details window (not implemented yet)
            MessageBox.Show($"Open details for: {SelectedRecipe.Title}");
        }

        private void EditRecipe()
        {
            if (SelectedRecipe == null)
            {
                MessageBox.Show("Select a recipe to edit.");
                return;
            }

            // Placeholder: edit recipe (not implemented yet)
            MessageBox.Show($"Edit recipe: {SelectedRecipe.Title}");
        }
    }
}
