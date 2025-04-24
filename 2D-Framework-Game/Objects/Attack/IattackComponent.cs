using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Framework_Game.Objects.Attack
{
    public interface IAttackComponent
    {
        int GetHit();
        string Description { get; }
    }
}
