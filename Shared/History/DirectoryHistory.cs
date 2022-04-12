using System;
using System.Collections;
using System.Collections.Generic;

namespace Shared.History
{
    internal class DirectoryHistory : IDirectoryHistory
    {
        #region Private Fields

        private DirectoryNode _head;
        #endregion

        #region Properties
        public DirectoryNode Current { get; private set; }

        public bool CanMoveBack => !(Current.PreviousNode is null);
        public bool CanMoveForward => !(Current.NextNode is null);
        #endregion

        #region Events

        public event EventHandler HistoryChanged;

        #endregion


        #region Constructor
        public DirectoryHistory(string directoryPath, string directoryPathName)
        {
            _head = new DirectoryNode(directoryPath, directoryPathName);
            Current = _head;
        }
        #endregion


        #region Methods
        public void Add(string filePath, string name)
        {
            var node = new DirectoryNode(filePath, name);

            Current.NextNode = node;
            node.PreviousNode = Current;

            Current = node;

            RiaseHostoryChanged();
        }
        public void MoveBack()
        {
            var prev = Current.PreviousNode;
            Current = prev;

            RiaseHostoryChanged();
        }

        public void MoveForward()
        {
            var next = Current.NextNode;
            Current = next;

            RiaseHostoryChanged();
        }
        #endregion


        #region Private methods
        private void RiaseHostoryChanged() => HistoryChanged?.Invoke(this, EventArgs.Empty);
        #endregion


        #region Enumerables 
        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return Current;
        }

        public IEnumerator<DirectoryNode> GetEnumerator() => GetEnumerator();

        #endregion
    }
}
