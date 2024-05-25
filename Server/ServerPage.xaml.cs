using DAL.Domain;
using System.IO.Pipes;

namespace Server;

public partial class ServerPage : ContentPage
{
    private readonly NamedPipeServerStream _pipeServer;
    private readonly StreamString _ss;


    public ServerPage()
    {
        InitializeComponent();

        _pipeServer = new NamedPipeServerStream("test-pipe", PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
        _ss = new StreamString(_pipeServer);

        InitPipeServer();
    }

    private void InitPipeServer()
    {
        _pipeServer.BeginWaitForConnection(ar =>
        {
            _pipeServer.EndWaitForConnection(ar);
        }, null);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        _pipeServer.Close();
        _pipeServer.Dispose();
    }

    private void SendMessage_Clicked(object sender, EventArgs e)
    {
        if (!_pipeServer.IsConnected)
        {
            return;
        }

        string message = MessageEntry.Text is null ? "Empty message" : MessageEntry.Text;
        _ss.WriteString(message);
    }
}
