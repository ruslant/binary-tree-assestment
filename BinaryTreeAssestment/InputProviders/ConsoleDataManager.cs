using System;

namespace BinaryTreeAssestment.InputProviders
{
    public class ConsoleDataManager : InputDataManager
    {
        public override string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
