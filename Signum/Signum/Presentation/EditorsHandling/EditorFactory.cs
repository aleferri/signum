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
        //Tipo Elemento, Tipo Editor
        private readonly Dictionary<Type, Type> _editorHandlers;
        //Nome, Tipo Editor
        private readonly List<KeyValuePair<string, Type>> _editorMenuNames;

        public IEnumerable<string> Names => from KeyValuePair<string, Type> kvp 
                                            in _editorMenuNames
                                            select kvp.Key;
        public IEnumerable<string> ElementEditorNames
        {
            get => from KeyValuePair<string, Type> kvp
                   in _editorMenuNames
                   let tipi = from Type t
                              in _editorHandlers.Keys
                              where _editorHandlers[t].IsSubclassOf(typeof(ElementEditorPresenter))
                              select t
                   where tipi.Contains(kvp.Value)
                   select kvp.Key;

        }
        public EditorFactory()
        {
            _editorHandlers = new Dictionary<Type, Type>();
            _editorMenuNames = new List<KeyValuePair<string, Type>>();
            FillCollections();
        }

        private void FillCollections()
        {
            IEnumerable<Type> handlerTypes = from Type t
                                               in Assembly.GetExecutingAssembly().GetTypes()
                                             where t.IsClass && !t.IsAbstract && typeof(IEditorPresenter).IsAssignableFrom(t)
                                             select t;
            int unnamedNo = 1;
            foreach (Type t in handlerTypes)
            {
                NameTagAttribute att = ((NameTagAttribute)t.GetCustomAttribute(typeof(NameTagAttribute)));
                KeyValuePair<string, Type> kvp;

                kvp = null != att ? new KeyValuePair<string, Type>(att.Name, att.Tag) : new KeyValuePair<string, Type>("UnnamedElement" + unnamedNo, t);

                if (_editorMenuNames.Contains(kvp)) continue;
                _editorHandlers.Add(kvp.Value, t);
                _editorMenuNames.Add(kvp);
            }
        }

        public IEditorPresenter GetEditorHandler(Type type, Modello modello)
        {
            return (IEditorPresenter) Activator.CreateInstance(_editorHandlers[type], new object[] { modello });
        }

        public Type GetTagFromName(string name)
        {
            return null == name ? null : (from KeyValuePair<string, Type> kvp
                                         in _editorMenuNames where kvp.Key == name
                                         select kvp.Value).Single();
        }

    }
}
