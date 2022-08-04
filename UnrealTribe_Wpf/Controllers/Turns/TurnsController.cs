using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealTribe.Controllers.Turns
{
    public class TurnsController : ITurnsController
    {
        protected static TurnsController controller = new TurnsController();

        protected TurnsController()
        {
            this.NextTurnStarted += OnNextTurn;
        }

        public static TurnsController CreateNew()
        {
            return controller;
        }

        public static int Turn { get; private set; }

        public event EventHandler? NextTurnStarted;

        private void OnNextTurn(object? sender, EventArgs e)
        {
            Turn++;
        }

        public void StartNextTurn()
        {
            if (NextTurnStarted != null)
            {
                this.NextTurnStarted.Invoke(this, new EventArgs());
            }
        }
    }
}
