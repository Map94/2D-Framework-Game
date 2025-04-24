using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _2D_Framework_Game.Objects.Attack;

namespace _2D_Framework_Game.Interfaces
{
    public interface IAttackStrategy
    {
        int ExecuteAttack(List<IAttackComponent> items);
    }
}
