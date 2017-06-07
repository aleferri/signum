using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signum.View
{
    public partial class MainContainer : UserControl
    {

        public Panel LeftPanel => _outerSplitContainer.Panel1;

        public Panel RightPanel => _outerSplitContainer.Panel2;

        public MainContainer()
        {
            InitializeComponent();
        }
    }
}
