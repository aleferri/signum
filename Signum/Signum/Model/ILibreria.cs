using System;
using System.Collections.Generic;

namespace Signum.Model
{
    public interface ILibreria
    {
        event EventHandler LibreriaChange;

        IEnumerable<PersisterMapper<ImmagineFissa>> ImmaginiFisse { get; }
        IEnumerable<PersisterMapper<Animazione>> Animazioni { get; }
        IEnumerable<PersisterMapper<Sequenza>> Sequenze { get; }
        IEnumerable<PersisterMapper<ProgrammazioneGiornaliera>> ProgrGiornaliere { get; }

        void AggiungiElemento(PersisterMapper<Elemento> elemento);
        void AggiungiSequenza(PersisterMapper<Sequenza> sequenza);
        void AggiungiProgrGiornaliera(PersisterMapper<ProgrammazioneGiornaliera> progrGiornaliera);
    }
}
