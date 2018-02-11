using ISC.Model.Entity.Base;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;

namespace ISC.Model.Entity.Working.Initializations
{
    public class RecordOptions : Notify
    {
        private string recordFilePath;
        public string RecordFilePath
        {
            get { return recordFilePath; }
            set
            {
                recordFilePath = value;
                this.RaisePropertyChanged(nameof(RecordFilePath));
            }
        }

        private int imageCount;
        public int ImageCount
        {
            get { return imageCount; }
            set
            {
                imageCount = value;
                this.RaisePropertyChanged(nameof(ImageCount));
            }
        }

        //private enum FileFormat { Jpg = 0, Txt = 1 }

        [ScriptIgnore]
        [IgnoreDataMember]
        public int IgnoreProperty { get; set; }
    }
}
