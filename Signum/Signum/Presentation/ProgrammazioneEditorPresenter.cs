using Signum.Model;
using Signum.Presentation.EditorsHandling;
using Signum.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signum.Presentation
{
    class ProgrammazioneEditorPresenter : IEditorPresenter
    {

        private readonly ProgrammazioneEditor _editor;

        private PersisterMapper<ProgrammazioneSettimanale> _wrapper;

        public ProgrammazioneEditorPresenter()
        {
            _editor = new ProgrammazioneEditor();
            var model = new ProgrammazioneSettimanale();
            _wrapper = new PersisterMapper<ProgrammazioneSettimanale>(model);
        }

        public Control Editor => throw new NotImplementedException();

        public void CaricaModello(PersisterMapper oggettoModello)
        {
            throw new NotImplementedException();
        }

        public void OnSave(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
