namespace LoadingSystem
{
    /// <summary>
    /// implement this to set your class Savable to File system
    /// </summary>
    public interface IFSSavable
    {
        /// <summary>
        /// the path to save your model in file system; without format prefix
        /// implement its "get" to return your desired filename
        /// <example> public string SavingPath => "MyModelFilename"; </example>
        /// </summary>
        string SavingPath { get; }
    }
}