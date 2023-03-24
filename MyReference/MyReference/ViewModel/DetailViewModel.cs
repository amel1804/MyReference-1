using MyQualityApp.Services;

namespace MyReference.ViewModel;

[QueryProperty(nameof(MonTxt), "Databc")]
public partial class DetailViewModel : BaseViewModel
{
	DeviceOrientationServices MyDeviceOrientationService;

	[ObservableProperty]
	string monTxt;
	[ObservableProperty]
	string myButton;
    [ObservableProperty]
    string activeTarget;
    public DetailViewModel()
	{
		this.MyDeviceOrientationService = new DeviceOrientationServices();

		MyDeviceOrientationService.ConfigureScanner();

		MyDeviceOrientationService.SerialBuffer.Changed += SerialBuffer_Changed;

    }
	public void SerialBuffer_Changed (object sender, EventArgs e)
	{
		DeviceOrientationServices.QueueBuffer myQueue = (DeviceOrientationServices.QueueBuffer)sender;

		ActiveTarget = myQueue.Dequeue().ToString();
	}

	[RelayCommand]
	void SelectButton(string data)
	{
		MyButton = data;
		if(SerialBuffer.Count> 0) { MonTxt=SerialBuffer.Dequeue();

		}
	}
}