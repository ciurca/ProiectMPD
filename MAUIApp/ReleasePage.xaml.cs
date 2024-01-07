using MirthApp.Models;

namespace MirthApp;

public partial class ReleasePage : ContentPage
{
	public ReleasePage()
	{
		InitializeComponent();
        LoadArtistsAsync();
    }

    private async void LoadArtistsAsync()
    {
        List<Artist> artists = await App.Database.GetArtistsAsync();
        artistPicker.ItemsSource = artists;
    }

    private void OnArtistPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        Artist selectedArtist = (Artist)artistPicker.SelectedItem;

        if (selectedArtist != null)
        {
            ((Release)BindingContext).SelectedArtist = selectedArtist;
        }
    }


    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var release = (Release)BindingContext;
        await App.Database.SaveReleaseAsync(release);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var release = (Release)BindingContext;
        await App.Database.DeleteReleaseAsync(release);
        await Navigation.PopAsync();
    }

    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GenrePage((Release)
        this.BindingContext)
        {
            BindingContext = new Genre()
        });
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var release = (Release)BindingContext;
        listView.ItemsSource = await App.Database.GetReleaseGenresAsync(release.ID);
    }

    async void OnDeleteButtonItemClicked(object sender, EventArgs e)
    {
        var currentRelease = BindingContext as Release;
        var selectedGenre = listView.SelectedItem as Genre;

        if (selectedGenre != null && currentRelease != null)
        {
            await App.Database.DeleteGenreFromReleaseAsync(selectedGenre.ID, currentRelease.ID);

            listView.ItemsSource = await App.Database.GetReleaseGenresAsync(currentRelease.ID);

            listView.SelectedItem = null;
        }
    }

}