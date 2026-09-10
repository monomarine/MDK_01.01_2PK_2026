namespace CreationalPattern_Memento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextEditor editor = new TextEditor();
            while(true)
            {
                Console.Clear();
                Console.WriteLine("ввод строки - автоматическое добавление");
                Console.WriteLine("del - удаление последней строки текста");
                Console.WriteLine("пробел - просмотр содержимого");
                Console.WriteLine("undo - выйти из редактора");

                string answer = Console.ReadLine();
                switch(answer)
                {
                    case "del": editor.Clear();
                        break;
                    case " ":
                        Console.WriteLine(editor);
                        break;
                    case "undo": editor.Undo();
                        break;
                    default: editor.AddLine(answer);
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
