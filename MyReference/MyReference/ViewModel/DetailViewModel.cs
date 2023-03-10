namespace MyReference.ViewModel;

[QueryProperty(nameof(MonTxt), "Databc")]
public partial class DetailViewModel : BaseViewModel
{
	[ObservableProperty]
	string monTxt;
	[ObservableProperty]
	string myButton;
	public DetailViewModel()
	{

	}
	[RelayCommand]
	void SelectButton(string data)
	{
		MyButton = data;
	}
}