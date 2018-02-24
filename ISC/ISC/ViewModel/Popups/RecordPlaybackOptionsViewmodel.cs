using ISC.Global.Common;
using ISC.Global.Common.Enumeration;
using ISC.Model.Entity.Working.Initializations;
using ISC.ViewModel.Base;

namespace ISC.ViewModel.Popups
{
    public class RecordPlaybackOptionsViewmodel : Base.ViewModel
    {
        public RecordPlaybackOptions RecrdPlaybackOptions { get; private set; }

        public RelayCommand Close => new RelayCommand(() => General.RaiseEventHandler(this, EventName.CloseWindow, null));

        public RecordPlaybackOptionsViewmodel()
        {
            this.RecrdPlaybackOptions = General.Initialization.RecordPlaybackOptions;
            this.RecrdPlaybackOptions.RecordOptions.FilePaths.Add("AAA");
            this.RecrdPlaybackOptions.RecordOptions.FilePaths.Add("BBB");
            this.RecrdPlaybackOptions.RecordOptions.FilePaths.Add("CCC");
        }
    }
}
