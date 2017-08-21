using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManaging
{
    /// <summary>
    /// Contiene indicazioni su nome e Type di uno specifico modello
    /// </summary>
    internal class ModelDescriptor
    {
        private readonly string _nome;
        private readonly Type _modelType;

        public string Nome => _nome;
        public Type Tipo => _modelType;

        public ModelDescriptor(string nome, Type tipo)
        {
            _nome = nome;
            _modelType = tipo;
        }

    }
}
