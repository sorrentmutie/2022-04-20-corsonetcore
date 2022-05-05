namespace ClassLibrary1
{
    public class FileHelper
    {
        private readonly IData data;

        public FileHelper(IData data)
        {
            this.data = data;
        }

        public bool FileEsiste(string fileName)
        {
            var x = data.GetSomething();
            if(x == null)
            {
                throw new ArgumentNullException("fileName");
            }    
            if(string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }
            return File.Exists(fileName);
        }
    }
}