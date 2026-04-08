namespace FileSystemTreeApp
{
    public class FileMetadata
    {
        private string name;
        private bool isFolder;

        public FileMetadata(string name, bool isFolder)
        {
            this.name = name;
            this.isFolder = isFolder;
        }

        public string GetName()
        {
            return name;
        }

        public bool IsFolder()
        {
            return isFolder;
        }

        public override string ToString()
        {
            return name + (isFolder ? "/" : "");
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || GetType() != obj.GetType()) return false;

            FileMetadata that = (FileMetadata)obj;
            return name.Equals(that.name) && isFolder == that.isFolder;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() ^ isFolder.GetHashCode();
        }
    }
}