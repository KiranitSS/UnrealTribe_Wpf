using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealTribe.Turns
{
    public interface ITurnsController
    {
        event EventHandler NextTurnStarted;

        static int Turn { get; }

        void StartNextTurn();
    }
}
