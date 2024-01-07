using MirthApp.Models;

namespace MirthApp;

public partial class ArtistPage : ContentPage
{
	public ArtistPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var artist = (Artist)BindingContext;
        await App.Database.SaveArtistAsync(artist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var artist = (Artist)BindingContext;
        await App.Database.DeleteArtistAsync(artist);
        await Navigation.PopAsync();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var artist = (Artist)BindingContext;
        releaseListView.ItemsSource = await App.Database.GetReleasesForArtistAsync(artist.ID);
    }
}