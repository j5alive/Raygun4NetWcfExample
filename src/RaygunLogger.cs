using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Mindscape.Raygun4Net;

namespace Raygun4NetWcfExample
{
  public class RaygunLogger : IErrorHandler
  {
    private readonly RaygunClient _client;

    public RaygunLogger(string apiKey)
    {
      _client = new RaygunClient(apiKey);
    }

    public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
    {
    }

    public bool HandleError(Exception error)
    {
      _client.Send(error);
      return false;
    }
  }
}