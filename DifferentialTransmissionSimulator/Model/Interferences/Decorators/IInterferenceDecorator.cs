using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialTransmissionSimulator.Model.Interferences.Decorators
{
    public interface IInterferenceDecorator : IInterference
    {
        object Data { get; set; }
        IInterference DecoratedInterference { get; set; }
    }
}
