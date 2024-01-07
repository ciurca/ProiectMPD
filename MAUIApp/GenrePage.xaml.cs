using MirthApp.Models;

namespace MirthApp;

public partial class GenrePage : ContentPage
{
    Release rel;
    public GenrePage(Release release)
    {
        InitializeComponent();
        rel = release;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var genre = (Genre)BindingContext;
        await App.Database.SaveGenreAsync(genre);
        listView.ItemsSource = await App.Database.GetGenresAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var genre = (Genre)BindingContext;
        await App.Database.DeleteGenreAsync(genre);
        listView.ItemsSource = await App.Database.GetGenresAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetGenresAsync();
    }

    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Genre g;
        if (listView.SelectedItem != null)
        {
            g = listView.SelectedItem as Genre;
            var rg = new ReleaseGenre()
            {
                ReleaseID = rel.ID,
                GenreID = g.ID
            };
            await App.Database.SaveReleaseGenreAsync(rg);
            g.ReleaseGenres = new List<ReleaseGenre> { rg };
            await Navigation.PopAsync();
        }
    }
}