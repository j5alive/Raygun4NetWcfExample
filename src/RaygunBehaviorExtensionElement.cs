using System;
using System.Configuration;
using System.ServiceModel.Configuration;

namespace Raygun4NetWcfExample
{
  public class RaygunBehaviorExtensionElement : BehaviorExtensionElement
  {
    const string ApiKeyPropertyName = "apiKey";

    public override Type BehaviorType
    {
      get { return typeof(RaygunServiceBahavior); }
    }

    protected override object CreateBehavior()
    {
      return new RaygunServiceBahavior(ApiKey);
    }

    [ConfigurationProperty(ApiKeyPropertyName)]
    public string ApiKey
    {
      get
      {
        return (string)base[ApiKeyPropertyName];
      }
      set
      {
        base[ApiKeyPropertyName] = value;
      }
    }
  }
}