using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPattern_Memento
{
    internal class TextEditor
    {
        private CareTaker _caretaker;
        private StringBuilder _text = new StringBuilder();
        public TextEditor()
        {
            _caretaker = new CareTaker();
        }
        public void AddLine(string line)
        {
            _text.AppendLine(line);
            SaveState();
        }
        public void RemoveLastLine()
        {
            int ind = _text.ToString().LastIndexOf("\n");
            _text.Remove(ind, _text.Length - ind); //внимательно 
        }
        public void Clear()
        {
            _text.Clear();
        }

        public void Undo() //отмена
        {
            LoadState();
        }
        public void Redo() //восстановить отмену
        {
            
        }

        private void SaveState()
        {
                _caretaker.AddState(new TextMemento(new StringBuilder(_text.ToString())));
                Console.WriteLine("снимок сохранен");
        }
        private void LoadState()
        {
            TextMemento state = _caretaker.GetState();
            Console.WriteLine("1 загружено восстановление");
            if (state != null)
            {
                _text = state.State;
                Console.WriteLine("2 состояние восстановлено");
            }
            else
                Console.WriteLine("3 не получилось восстановить состояние");
        }

        public override string ToString()
        {
            return _text.ToString();
        }
  }
}
