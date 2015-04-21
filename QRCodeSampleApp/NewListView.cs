using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace QRCodeSample
{
    public class DoubleBufferListView : ListView
    {
        public DoubleBufferListView()
        {
            SetStyle(ControlStyles.DoubleBuffer 
                | ControlStyles.OptimizedDoubleBuffer 
                | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }
    }
}
