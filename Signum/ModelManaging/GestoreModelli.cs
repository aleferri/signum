using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModelManaging
{
    class GestoreModelli
    {
        private IEnumerable<ModelDescriptor> _modelli;

        public IEnumerable<ModelDescriptor> Descrittori => _modelli;

        public GestoreModelli()
        {
            _modelli = TrovaModelli(Assembly.GetExecutingAssembly());
        }

        private IEnumerable<ModelDescriptor> TrovaModelli(Assembly targetAssembly)
        {
            List<ModelDescriptor> modelli = new List<ModelDescriptor>();
            IEnumerable<Type> types = from Type t 
                                      in targetAssembly.GetTypes()
                                      where t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(Modello))
                                      select t;
            foreach (Type t in types)
            {
                modelli.Add(new ModelDescriptor(t.GetCustomAttribute<NameAttribute>().Name, t));
            }

            return modelli;
        }

        public ModelDescriptor GetFromModello(Modello modello)
        {
            Type t = modello.GetType();
            return (from ModelDescriptor md in _modelli where md.Tipo == t select md).Single();
        }

    }
}
