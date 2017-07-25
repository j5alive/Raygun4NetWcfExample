using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Raygun4NetWcfExample
{
  public class RaygunServiceBahavior : IServiceBehavior
  {
    private readonly string _apiKey;

    public RaygunServiceBahavior(string apiKey)
    {
      _apiKey = apiKey;
    }

    public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
    {
    }

    public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    {
      IErrorHandler errorHandler = new RaygunLogger(_apiKey);

      foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers)
      {
        channelDispatcher.ErrorHandlers.Add(errorHandler);
      }
    }

    public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    {

    }
  }
}