using System.IO;
using System.Threading.Tasks;

namespace EncodeUtil
{
    public class FileSearcher
    {
        private string _rootDir;
        private string[] _searchPatterns;
        private SearchOption _searchOption;

        // public delegate bool MatchFile(string fileName, string keyword);

        public delegate void AfterFindFile(FileData fileName);

        public event AfterFindFile OnAfterFindFile;

        public FileSearcher(string dir, string[] searchPatterns, SearchOption searchOption, AfterFindFile afterFindFile = null)
        {
            _rootDir = dir;
            _searchPatterns = searchPatterns;
            _searchOption = searchOption;
            OnAfterFindFile += afterFindFile;
        }

        public void Start()
        {
            Task[] tasks = new Task[_searchPatterns.Length];
            for (int i = 0; i < _searchPatterns.Length; i++)
            {
                var pattern = _searchPatterns[i];
                tasks[i] = Task.Factory.StartNew(() =>
                {
                    foreach (FileData f in FastDirectoryEnumerator.EnumerateFiles(_rootDir, pattern, _searchOption))
                    {
                        if (OnAfterFindFile != null)
                        {
                            OnAfterFindFile(f);
                        }
                    }
                });
            }
            Task.WaitAll(tasks);
        }
    }
}
