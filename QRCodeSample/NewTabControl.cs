using System;
using System.Windows.Forms;

namespace QRCodeSample
{
    public class NewTabControl : TabControl
    {
        public bool AllowSelect;

        public NewTabControl()
        {
            AllowSelect = true;
        }

        protected override void OnSelecting(TabControlCancelEventArgs e)
        {
            e.Cancel = !AllowSelect;
        }
    }
}
