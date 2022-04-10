using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.History
{
    internal interface IDirectoryHistory
    {
        bool CanMoveBack { get; }
        bool CanMoveForward { get; }

        DirectoryNode Current { get; }

        void MoveBack();
        void MoveForward();

        
        event EventHandler HistoryChanged;

        void Add(string filePath, string name);
    }
}
