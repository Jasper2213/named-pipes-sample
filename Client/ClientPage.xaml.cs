using DAL.Domain;
using System.IO.Pipes;

namespace Client;

public partial class ClientPage : ContentPage
{
    private readonly NamedPipeClientStream _pipeClient;
    private readonly StreamString _ss;
    private bool _isConnected = false;

    public ClientPage()
    {
        InitializeComponent();

        _pipeClient = new NamedPipeClientStream(".", "test-pipe", PipeDirection.InOut, PipeOptions.Asynchronous);
        _ss = new StreamString(_pipeClient);

        InitPipeClient();
    }

    private void InitPipeClient()
    {
        if (_isConnected)
        {
            return;
        }

        if (!_pipeClient.IsConnected)
            _pipeClient.Connect();

        _isConnected = true;

        ListenForMessages();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        _pipeClient.Close();
        _pipeClient.Dispose();

        _isConnected = false;
    }

    private async void ListenForMessages()
    {
        if (!_pipeClient.IsConnected)
        {
            return;
        }

        string message = await Task.Run(_ss.ReadString);

        MainThread.BeginInvokeOnMainThread(() =>
        {
            MessageLabel.Text = message;
        });

        ListenForMessages();
    }
}
