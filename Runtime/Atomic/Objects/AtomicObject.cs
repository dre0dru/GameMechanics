using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

namespace Atomic.Objects
{
    public abstract class AtomicObject : AtomicObjectBase
    {
        /// <summary>
        ///     <para>Constructor for atomic object</para>
        /// </summary>
        public virtual void Compose()
        {
#if UNITY_EDITOR
            Profiler.BeginSample("AtomicObject.Compose", this);
#endif
            AtomicObjectInfo objectInfo = AtomicCompiler.CompileObject(GetType());
            
            AddTypes(objectInfo.Types);
            AddReferences(this, objectInfo.References);
            AddSections(this, objectInfo.Sections);
            
#if UNITY_EDITOR
            Profiler.EndSample();
#endif
        }

        private void AddReferences(object source, IEnumerable<ReferenceInfo> definitions)
        {
            foreach (ReferenceInfo definition in definitions)
            {
                string id = definition.Id;
                object value = definition.Value(source);
                
                if (definition.Override)
                {
                    References[id] = value;
                    continue;
                }

                References.TryAdd(id, value);
            }
        }
        
        private void AddSections(object parent, IEnumerable<SectionInfo> definitions)
        {
            foreach (var definition in definitions)
            {
                object section = definition.GetValue(parent);
                
                AddTypes(definition.Types);
                AddReferences(section, definition.References);
                AddSections(section, definition.Children);
            }
        }
        
#if UNITY_EDITOR
        [ContextMenu(nameof(Compose))]
        public void ComposeEditor()
        {
            Types.Clear();
            References.Clear();
            
            Compose();
        }
#endif
    }
}
