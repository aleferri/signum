using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Model
{
    public interface ILibreria
    {
        event EventHandler LibreriaChange;

        IEnumerable<ModelToPersistenceWrapper<ImmagineFissa>> ImmaginiFisse { get; }
        IEnumerable<ModelToPersistenceWrapper<Animazione>> Animazioni { get; }
        IEnumerable<ModelToPersistenceWrapper<Sequenza>> Sequenze { get; }
        IEnumerable<ModelToPersistenceWrapper<ProgrammazioneGiornaliera>> ProgrGiornaliere { get; }

        void AggiungiElemento(ModelToPersistenceWrapper<Elemento> elemento);
        void AggiungiSequenza(ModelToPersistenceWrapper<Sequenza> sequenza);
        void AggiungiProgrGiornaliera(ModelToPersistenceWrapper<ProgrammazioneGiornaliera> progrGiornaliera);
    }
}
