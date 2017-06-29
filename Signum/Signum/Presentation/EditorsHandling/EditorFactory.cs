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
        private readonly List<KeyValuePair<string, string>> _editorMenuNames;

        public IEnumerable<string> Names => from KeyValuePair<string, string> kvp 
                                            in _editorMenuNames
                                            select kvp.Key;

        public EditorFactory()
        {
            _editorHandlers = new Dictionary<string, Type>();
            _editorMenuNames = new List<KeyValuePair<string, string>>();
            FillCollections();
        }

        private void FillCollections()
        {
            IEnumerable<Type> handlerTypes = from Type t
                                               in Assembly.GetExecutingAssembly().GetTypes()
                                             where t.IsClass && !t.IsAbstract && typeof(IEditorPresenter).IsAssignableFrom(t)
                                             select t;
            foreach (Type t in handlerTypes)
            {
                NameTagAttribute att = ((NameTagAttribute)t.GetCustomAttribute(typeof(NameTagAttribute)));
                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(att.Name, att.Tag);
                if (_editorMenuNames.Contains(kvp)) continue;
                _editorHandlers.Add(kvp.Value, t);
                _editorMenuNames.Add(kvp);
            }
        }

        public IEditorPresenter GetEditorHandler(string type, Modello modello)
        {
            return (IEditorPresenter) Activator.CreateInstance(_editorHandlers[type], new object[] { modello });
        }

        public string GetTagFromName(string name)
        {
            return null == name ? null : (from KeyValuePair<string, string> kvp
                                         in _editorMenuNames where kvp.Key == name
                                         select kvp.Value).Single();
        }

    }
}
