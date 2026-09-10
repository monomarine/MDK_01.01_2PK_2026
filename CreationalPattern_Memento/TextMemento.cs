using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPattern_Memento
{
    class TextMemento
    {
        private StringBuilder _state;
        public StringBuilder State => _state;
        public TextMemento(StringBuilder text)
            => _state = text;
    }
}
