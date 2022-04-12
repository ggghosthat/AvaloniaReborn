namespace Shared.History
{
    internal class DirectoryNode
    {
        public DirectoryNode PreviousNode { get; set; }
        public DirectoryNode NextNode { get; set; }


        public string DirectoryPath { get; set; }
        public string DirectoryPathName { get; set; }

        public DirectoryNode(string directoryPath, string directoryPathName)
        {
            DirectoryPath = directoryPath;
            DirectoryPathName = directoryPathName;
        }
    }
}