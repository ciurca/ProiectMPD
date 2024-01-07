using MirthApp.Models;

namespace MirthApp;

public partial class ArtistEntryPage : ContentPage
{
	public ArtistEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetArtistsAsync();
    }
    async void OnArtistAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ArtistPage
        {
            BindingContext = new Artist()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ArtistPage
            {
                BindingContext = e.SelectedItem as Artist
            });
        }
    }
}