using ISC.Global.Common;
using ISC.View.Selections;
using ISC.ViewModel.Base;
using ISC.Global.Common.Enumeration;

namespace ISC.ViewModel
{
    public class DockViewmodel : Base.ViewModel
    {
        private int workingmodeSelectedIndex;
        public int WorkingmodeSelectedIndex
        {
            get { return workingmodeSelectedIndex; }
            set { workingmodeSelectedIndex = value; this.RaisePropertyChanged(nameof(this.WorkingmodeSelectedIndex)); }
        }

        public bool IsEbspActive { get; private set; } = true;

        public bool IsStspActive { get; private set; } = true;

        public EbSelectionView EbSelectionView { get; set; }

        public StSelectionView StSelectionPane { get; set; }

        public NetworkViewmodel NetworkViewmodel { get; set; }

        public FileViewmodel FileViewmodel { get; set; }

        public StepsViewmodel StepsViewmodel { get; set; }

        public PaletteViewmodel JobViewmodel { get; set; }

        public void HideSelectionPane()
        {
            //General.SwitchPane(Properties.Resources.SelectionPane, PaneState.Hide);

        }

        public DockViewmodel()
        {
            this.NetworkViewmodel = new NetworkViewmodel();
            this.FileViewmodel = new FileViewmodel();
            this.StepsViewmodel = new StepsViewmodel();
        }
    }
}
