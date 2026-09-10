using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPattern_Memento
{
#pragma warning disable
    internal class CareTaker
    {
        private Stack<TextMemento> _states = new Stack<TextMemento>();

        public void AddState(TextMemento state)=>
            _states.Push(state);

        public TextMemento GetState() => _states.TryPop(
            out TextMemento result) ? result : null;
    }
}
