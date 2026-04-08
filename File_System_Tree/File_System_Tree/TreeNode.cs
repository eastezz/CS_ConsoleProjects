using System.Collections.Generic;

namespace FileSystemTreeApp
{
    public class TreeNode<T> where T : FileMetadata
    {
        public T Data { get; set; }
        public List<TreeNode<T>> Children { get; set; }
        public TreeNode<T> Parent { get; set; }

        public TreeNode(T data)
        {
            Data = data;
            Children = new List<TreeNode<T>>();
            Parent = null;
        }

        public bool IsFolder()
        {
            return Data.IsFolder();
        }
    }
}