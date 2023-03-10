using MyQualityApp.Services;

namespace MyReference.ViewModel;

public partial class MainViewModel : BaseViewModel
{
    DeviceOrientationServices MyDeviceOrientationService;

    [ObservableProperty]
    string monTexte = "blabla";
    public ObservableCollection<Monkey> MyShownList { get; } = new();
    public MainViewModel()
	{
        this.MyDeviceOrientationService = new DeviceOrientationServices();
        MyDeviceOrientationService.ConfigureScanner();
    }

    [RelayCommand]
    public async Task GoToDetailPage(string data)
    {
        await Shell.Current.GoToAsync(nameof(DetailPage), true, new Dictionary<string, object>
        {
            {"Databc", data }
        });
    }
    [RelayCommand]
    async Task MonkeysFromJSON()
    {
        if (IsBusy) return;

        MonkeyService MyService = new();

        try
        {
            IsBusy = true;
            Globals.MyStaticList = await MyService.GetMonkeys();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get Students: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally { IsBusy = false; }

        MyShownList.Clear();

        foreach (Monkey stu in Globals.MyStaticList)
        {
            MyShownList.Add(stu);
        }
    }
}