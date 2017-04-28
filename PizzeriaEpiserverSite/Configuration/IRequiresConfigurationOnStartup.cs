using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaEpiserverSite.Configuration
{
  public  interface IRequiresConfigurationOnStartup
  {
      void Configure();
  }
}
