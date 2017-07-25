using System;

namespace Raygun4NetWcfExample
{
  public class TestService : ITestService
  {
    public string GetData(int value)
    {
      if (value <= 0)
      {
        throw new ArgumentOutOfRangeException(nameof(value), "value must be greater than 0");
      }
      return string.Format("You entered: {0}", value);
    }

    public CompositeType GetDataUsingDataContract(CompositeType composite)
    {
      if (composite == null)
      {
        throw new ArgumentNullException("composite");
      }
      if (composite.BoolValue)
      {
        composite.StringValue += "Suffix";
      }
      return composite;
    }
  }
}
