using ModelManaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Presentation.EditorsHandling
{
    public class EditorFactory
    {
        private readonly Dictionary<string, Type> _editorHandlers;

        public EditorFactory()
        {
            _editorHandlers = new Dictionary<string, Type>();
            FillDictionary();
        }

        public IEditorPresenter getEditorHandler(string type, Modello modello)
        {
            return (IEditorPresenter) Activator.CreateInstance(_editorHandlers[type], new object[] { modello });
        }

        private void FillDictionary()
        {
            IEnumerable<Type> handlerTypes = from Type t
                                               in Assembly.GetExecutingAssembly().GetTypes()
                                             where t.IsClass && !t.IsAbstract && typeof(IEditorPresenter).IsAssignableFrom(t)
                                             select t;
            foreach (Type t in handlerTypes)
            {
                string name = ((NameAttribute)t.GetCustomAttribute(typeof(NameAttribute))).Name;
                _editorHandlers.Add(name, t);
            }
        }
    }
}
