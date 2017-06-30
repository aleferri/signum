using Signum.Presentation.EditorsHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signum.Presentation
{
    [NameTagAttribute("Animazione", "animazione")]
    class AnimazioneEditorPresenter : IEditorPresenter
    {
        public EventHandler OnSave => throw new NotImplementedException();

        public Control Editor => throw new NotImplementedException();
    }
}
