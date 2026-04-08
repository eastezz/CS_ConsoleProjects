using System;
using System.Collections.Generic;
using System.Linq;

namespace FileSystemTreeApp
{
    public class FileSystemTree<T> where T : FileMetadata
    {
        private TreeNode<T> root;

        public FileSystemTree()
        {
            root = null;
        }

        // Adds a new node in a  path 
        public bool Add(string path, T file)
        {
            var parts = path.Split('/');

            if (root == null)
            {
                root = new TreeNode<T>((T)new FileMetadata(parts[0], true));
            }

            TreeNode<T> current = root;

            for (int i = 1; i < parts.Length; i++)
            {
                string part = parts[i];

                var next = current.Children
                    .FirstOrDefault(c => c.Data.GetName() == part);

                if (next == null)
                {
                    bool isLast = (i == parts.Length - 1);
                    T data = isLast ? file : (T)new FileMetadata(part, true);

                    next = new TreeNode<T>(data);
                    next.Parent = current;
                    current.Children.Add(next);
                }

                if (!next.IsFolder() && i < parts.Length - 1)
                    return false; // cannot go through file

                current = next;
            }

            return true;
        }

        // Find an element in the tree
        public T Find(string path)
        {
            var node = FindNode(path);
            return node?.Data;
        }

        private TreeNode<T> FindNode(string path)
        {
            if (root == null) return null;

            var parts = path.Split('/');
            TreeNode<T> current = root;

            if (current.Data.GetName() != parts[0])
                return null;

            for (int i = 1; i < parts.Length; i++)
            {
                current = current.Children
                    .FirstOrDefault(c => c.Data.GetName() == parts[i]);

                if (current == null)
                    return null;
            }

            return current;
        }

        // Returns list of nodes
        public List<T> List(string path)
        {
            var node = FindNode(path);

            if (node == null || !node.IsFolder())
                return new List<T>();

            return node.Children.Select(c => c.Data).ToList();
        }

        // Removes the node from the path
        public bool Remove(string path)
        {
            var node = FindNode(path);

            if (node == null || node == root)
                return false;

            node.Parent.Children.Remove(node);
            return true;
        }

        // prints the whole tree
        public void PrintTree()
        {
            PrintRecursive(root, 0);
        }

        private void PrintRecursive(TreeNode<T> node, int depth)
        {
            if (node == null) return;

            Console.WriteLine(new string(' ', depth * 2) + node.Data);

            foreach (var child in node.Children)
            {
                PrintRecursive(child, depth + 1);
            }
        }

        // Returns the full path
        public string GetFullPath(T file)
        {
            var node = FindByMetadata(root, file);

            if (node == null) return null;

            List<string> path = new List<string>();

            while (node != null)
            {
                path.Add(node.Data.GetName());
                node = node.Parent;
            }

            path.Reverse();
            return string.Join("/", path);
        }

        private TreeNode<T> FindByMetadata(TreeNode<T> node, T file)
        {
            if (node == null) return null;

            if (node.Data.Equals(file))
                return node;

            foreach (var child in node.Children)
            {
                var result = FindByMetadata(child, file);
                if (result != null)
                    return result;
            }

            return null;
        }

        // counts files in the path
        public int CountFiles()
        {
            return CountFilesRecursive(root);
        }

        private int CountFilesRecursive(TreeNode<T> node)
        {
            if (node == null) return 0;

            int count = node.IsFolder() ? 0 : 1;

            foreach (var child in node.Children)
            {
                count += CountFilesRecursive(child);
            }

            return count;
        }
    }
}