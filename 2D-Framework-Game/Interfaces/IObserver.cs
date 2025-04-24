using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Framework_Game.Interfaces
{
    public interface IObserver
    {
        void OnNotified(string message);
    }
}
