using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreprocessImage
{
    [Serializable]
    public class Frame
    {
        private string _fileFullName;

        private string _folder;

        public string FileFullName
        {
            get
            {
                return this._fileFullName;
            }
            set
            {
                this._fileFullName = value;
            }
        }

        public string Folder
        {
            get
            {
                return this._folder;
            }
            set
            {
                this._folder = value;
            }
        }

        public Frame(string fileFullName, string folder)
        {
            this._fileFullName = fileFullName;
            this._folder = folder;
        }
    }
}
