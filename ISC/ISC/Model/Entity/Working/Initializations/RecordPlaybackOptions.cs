using ISC.Model.Entity.Base;

namespace ISC.Model.Entity.Working.Initializations
{
    public class RecordPlaybackOptions : Notify
    {
        public RecordOptions RecordOptions { get; set; }

        public PlaybackOptions PlaybackOptions { get; set; }
    }
}
