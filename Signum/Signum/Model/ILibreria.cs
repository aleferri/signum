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

        /// <summary>
        /// Elimina l'immagine fissa all'indice index
        /// </summary>
        /// <param name="index"></param>
        void EliminaImmagineFissa(int index);
        /// <summary>
        /// Elimina l'animazione all'indice index
        /// </summary>
        /// <param name="index"></param>
        void EliminaAnimazione(int index);
        /// <summary>
        /// Elimina la sequenza all'indice index
        /// </summary>
        /// <param name="index"></param>
        void EliminaSequenza(int index);
        /// <summary>
        /// Elimina la programmazione giornaliera all'indice index
        /// </summary>
        /// <param name="index"></param>
        void EliminaProgrGiornaliera(int index);
    }
}
