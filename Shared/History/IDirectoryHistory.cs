using System;
using System.Collections.Generic;

namespace Shared.History
{
    internal interface IDirectoryHistory : IEnumerable<DirectoryNode>
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
