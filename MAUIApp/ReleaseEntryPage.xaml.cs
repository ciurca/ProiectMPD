using MirthApp.Models;

namespace MirthApp;

public partial class ReleaseEntryPage : ContentPage
{
	public ReleaseEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var releases = await App.Database.GetReleasesAsync();

        foreach (var release in releases)
        {
            // Check if ArtistId has a value before attempting to fetch the corresponding Artist data
            if (release.ArtistId.HasValue)
            {
                release.SelectedArtist = await App.Database.GetArtistAsync(release.ArtistId.Value);
            }
        }

        listView.ItemsSource = releases;
    }

    async void OnReleaseAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ReleasePage
        {
            BindingContext = new Release()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ReleasePage
            {
                BindingContext = e.SelectedItem as Release
            });
        }
    }
}