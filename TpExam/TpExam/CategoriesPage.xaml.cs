using System;
using System.Collections.Generic;
using Xamarin.Forms;
using TpExam.Models;

namespace TpExam
{
    public partial class CategoriesPage : ContentPage
    {
        public CategoriesPage()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void LoadCategories()
        {
            List<Categorie> categories = App.Database.ObtenirCategories();
            CategoriesListView.ItemsSource = categories;
        }

        private async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Categorie categorie)
            {
                // Navigate to the UpdateCategoryPage, passing the selected category
                await Navigation.PushAsync(new UpdateCategoryPage(categorie));
            }
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Categorie categorie)
            {
                // For demonstration purposes, show a confirmation alert. You can perform the delete operation.
                bool isConfirmed = await DisplayAlert("Confirmation", $"Delete category: {categorie.Nom}?", "Yes", "No");

                if (isConfirmed)
                {
                    // Delete operation (modify as needed)
                    App.Database.SupprimerCategorie(categorie.Id);

                    // Refresh the list after deletion
                    LoadCategories();
                }
            }
        }
        private async void AddCategoryButton_Clicked(object sender, EventArgs e)
        {
            // Navigate to AjouteCategorie.xaml
            await Navigation.PushAsync(new AjouteCategorie());
        }


    }
}
