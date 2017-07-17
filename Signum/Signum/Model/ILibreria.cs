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

        IEnumerable<MementoWrapper<ImmagineFissa>> ImmaginiFisse { get; }
        IEnumerable<MementoWrapper<Animazione>> Animazioni { get; }
        IEnumerable<MementoWrapper<Sequenza>> Sequenze { get; }
        IEnumerable<MementoWrapper<ProgrammazioneGiornaliera>> ProgrGiornaliere { get; }

        void AggiungiElemento(MementoWrapper<Elemento> elemento);
        void AggiungiSequenza(MementoWrapper<Sequenza> sequenza);
        void AggiungiProgrGiornaliera(MementoWrapper<ProgrammazioneGiornaliera> progrGiornaliera);
    }
}
