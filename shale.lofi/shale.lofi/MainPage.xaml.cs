using CommunityToolkit.Maui;

namespace shale.lofi;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		Shell.SetTabBarBackgroundColor(this, Color.FromArgb("666666"));
		Shell.SetNavBarIsVisible(this, false);
        InitializeComponent();
	}

}

