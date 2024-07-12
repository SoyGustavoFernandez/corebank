using System;
using System.Text;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;


namespace GEN.ControlesBase
{
    /// <summary>
    /// Represents a collection of clsComboTreeNode objects contained within a node or a ComboTreeBox control. 
    /// Supports change notification through INotifyCollectionChanged. Implements the non-generic IList to 
    /// provide design-time support.
    /// </summary>  
    public class clsComboTreeNodeCollection : IList<clsComboTreeNode>, IList, INotifyCollectionChanged
    {

        internal static IEnumerator<clsComboTreeNode> GetNodesRecursive(clsComboTreeNodeCollection collection, bool reverse)
        {
            if (!reverse)
            {
                for (int i = 0; i < collection.Count; i++)
                {
                    yield return collection[i];
                    IEnumerator<clsComboTreeNode> e = GetNodesRecursive(collection[i].Nodes, reverse);
                    while (e.MoveNext()) yield return e.Current;
                }
            }
            else
            {
                for (int i = (collection.Count - 1); i >= 0; i--)
                {
                    IEnumerator<clsComboTreeNode> e = GetNodesRecursive(collection[i].Nodes, reverse);
                    while (e.MoveNext()) yield return e.Current;
                    yield return collection[i];
                }
            }
        }

        private List<clsComboTreeNode> _innerList;
        private clsComboTreeNode _node;

        /// <summary>
        /// Fired when the check state of a node in the collection (or one of its children) changes.
        /// </summary>
        [Browsable(false)]
        internal event EventHandler<ComboTreeNodeEventArgs> AfterCheck;

        /// <summary>
        /// Initalises a new instance of clsComboTreeNodeCollection and associates it with the specified clsComboTreeNode.
        /// </summary>
        /// <param name="node"></param>
        internal clsComboTreeNodeCollection(clsComboTreeNode node)
        {
            _innerList = new List<clsComboTreeNode>();
            _node = node;
        }

        /// <summary>
        /// Gets the node with the specified name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public clsComboTreeNode this[string name]
        {
            get
            {
                foreach (clsComboTreeNode o in this)
                {
                    if (Object.Equals(o.Name, name)) return o;
                }

                throw new KeyNotFoundException();
            }
        }

        /// <summary>
        /// Creates a node and adds it to the collection.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public clsComboTreeNode Add(string text)
        {
            clsComboTreeNode item = new clsComboTreeNode(text);
            Add(item);
            return item;
        }

        /// <summary>
        /// Creates a node and adds it to the collection.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public clsComboTreeNode Add(string name, string text)
        {
            clsComboTreeNode item = new clsComboTreeNode(name, text);
            Add(item);
            return item;
        }

        /// <summary>
        /// Adds a range of clsComboTreeNode to the collection.
        /// </summary>
        /// <param name="items"></param>
        public void AddRange(IEnumerable<clsComboTreeNode> items)
        {
            foreach (clsComboTreeNode item in items)
            {
                _innerList.Add(item);
                item.Parent = _node;
                AddEventHandlers(item);
            }
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        /// <summary>
        /// Determines whether the collection contains a node with the specified name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ContainsKey(string name)
        {
            foreach (clsComboTreeNode o in this)
            {
                if (Object.Equals(o.Name, name)) return true;
            }

            return false;
        }

        /// <summary>
        /// Removes the node with the specified name from the collection.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Remove(string name)
        {
            for (int i = 0; i < _innerList.Count; i++)
            {
                if (Object.Equals(_innerList[i].Name, name))
                {
                    clsComboTreeNode item = _innerList[i];
                    RemoveEventHandlers(item);
                    _innerList.RemoveAt(i);
                    OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item));
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns the index of the node with the specified name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int IndexOf(string name)
        {
            for (int i = 0; i < _innerList.Count; i++)
            {
                if (Object.Equals(_innerList[i].Name, name)) return i;
            }

            return -1;
        }

        /// <summary>
        /// Raises the CollectionChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (CollectionChanged != null) CollectionChanged(this, e);
        }

        /// <summary>
        /// Sorts the collection and its entire sub-tree using the specified comparer.
        /// </summary>
        /// <param name="comparer"></param>
        internal void Sort(IComparer<clsComboTreeNode> comparer)
        {
            if (comparer == null) comparer = Comparer<clsComboTreeNode>.Default;
            SortInternal(comparer);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        /// <summary>
        /// Recursive helper method for Sort(IComparer&lt;clsComboTreeNode&gt;).
        /// </summary>
        /// <param name="comparer"></param>
        private void SortInternal(IComparer<clsComboTreeNode> comparer)
        {
            _innerList.Sort(comparer);
            foreach (clsComboTreeNode node in _innerList)
            {
                node.Nodes.Sort(comparer);
            }
        }

        /// <summary>
        /// Adds event handlers to the specified node.
        /// </summary>
        /// <param name="item"></param>
        private void AddEventHandlers(clsComboTreeNode item)
        {
            item.CheckStateChanged += item_CheckStateChanged;
            item.Nodes.CollectionChanged += CollectionChanged;
            item.Nodes.AfterCheck += AfterCheck;
        }

        /// <summary>
        /// Removes event handlers from the specified node.
        /// </summary>
        /// <param name="item"></param>
        private void RemoveEventHandlers(clsComboTreeNode item)
        {
            item.CheckStateChanged -= item_CheckStateChanged;
            item.Nodes.CollectionChanged -= CollectionChanged;
            item.Nodes.AfterCheck -= AfterCheck;
        }

        /// <summary>
        /// Raises the <see cref="AfterCheck"/> event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnAfterCheck(ComboTreeNodeEventArgs e)
        {
            if (AfterCheck != null) AfterCheck(this, e);
        }

        /// <summary>
        /// Returns the <see cref="clsComboTreeNode"/> that corresponds to the specified path string.
        /// </summary>
        /// <param name="path">The path string.</param>
        /// <param name="pathSeparator">The path separator.</param>
        /// <param name="useNodeNamesForPath">Whether the path is constructed from the name of the node instead of its text.</param>
        /// <returns>The node, or null if the path is empty.</returns>
        internal clsComboTreeNode ParsePath(string path, string pathSeparator, bool useNodeNamesForPath)
        {
            clsComboTreeNode select = null;

            string[] parts = path.Split(new string[] { pathSeparator }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i++)
            {
                clsComboTreeNodeCollection collection = ((select == null) ? this : select.Nodes);
                if (useNodeNamesForPath)
                {
                    try
                    {
                        select = collection[parts[i]];
                    }
                    catch (KeyNotFoundException ex)
                    {
                        throw new ArgumentException("Invalid path string.", "value", ex);
                    }
                }
                else
                {
                    bool found = false;
                    foreach (clsComboTreeNode node in collection)
                    {
                        if (node.Text.Equals(parts[i], StringComparison.InvariantCultureIgnoreCase))
                        {
                            select = node;
                            found = true;
                            break;
                        }
                    }
                    if (!found) throw new ArgumentException("Invalid path string.", "value");
                }
            }

            return select;
        }

        /// <summary>
        /// Returns the <see cref="clsComboTreeNode"/> with the specified node text.
        /// </summary>
        /// <param name="text">The text to match.</param>
        /// <param name="comparisonType">The type of string comparison performed.</param>
        /// <param name="recurse">Whether to search recursively through all child nodes.</param>
        /// <returns></returns>
        public clsComboTreeNode Find(string text, StringComparison comparisonType, bool recurse)
        {
            IEnumerator<clsComboTreeNode> nodes = recurse ? GetNodesRecursive(this, false) : GetEnumerator();

            while (nodes.MoveNext())
            {
                if (nodes.Current.Text.Equals(text, comparisonType))
                {
                    return nodes.Current;
                }
            }

            return null;
        }

        #region ICollection<clsComboTreeNode> Members

        /// <summary>
        /// Adds a node to the collection.
        /// </summary>
        /// <param name="item"></param>
        public void Add(clsComboTreeNode item)
        {
            _innerList.Add(item);
            item.Parent = _node;
            AddEventHandlers(item);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }

        /// <summary>
        /// Clears the collection.
        /// </summary>
        public void Clear()
        {
            foreach (clsComboTreeNode item in _innerList)
            {
                RemoveEventHandlers(item);
            }
            _innerList.Clear();
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        /// <summary>
        /// Determines whether the collection contains the specified node.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(clsComboTreeNode item)
        {
            return _innerList.Contains(item);
        }

        /// <summary>
        /// Gets the number of nodes in the collection.
        /// </summary>
        public int Count
        {
            get
            {
                return _innerList.Count;
            }
        }

        /// <summary>
        /// Copies all the nodes from the collection to a compatible array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(clsComboTreeNode[] array, int arrayIndex)
        {
            _innerList.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the specified node from the collection.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(clsComboTreeNode item)
        {
            if (_innerList.Remove(item))
            {
                RemoveEventHandlers(item);
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item));
                return true;
            }

            return false;
        }

        bool ICollection<clsComboTreeNode>.IsReadOnly
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region IEnumerable<clsComboTreeNode> Members

        /// <summary>
        /// Returns an enumerator which can be used to cycle through the nodes in the collection (non-recursive).
        /// </summary>
        /// <returns></returns>
        public IEnumerator<clsComboTreeNode> GetEnumerator()
        {
            return _innerList.GetEnumerator();
        }

        #endregion

        #region IList<clsComboTreeNode> Members

        /// <summary>
        /// Gets or sets the node at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public clsComboTreeNode this[int index]
        {
            get
            {
                return _innerList[index];
            }
            set
            {
                clsComboTreeNode oldItem = _innerList[index];
                _innerList[index] = value;
                value.Parent = _node;
                AddEventHandlers(value);
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, value, oldItem));
            }
        }

        /// <summary>
        /// Returns the index of the specified node.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(clsComboTreeNode item)
        {
            return _innerList.IndexOf(item);
        }

        /// <summary>
        /// Inserts a node into the collection at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, clsComboTreeNode item)
        {
            _innerList.Insert(index, item);
            item.Parent = _node;
            AddEventHandlers(item);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }

        /// <summary>
        /// Removes the node at the specified index from the collection.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            clsComboTreeNode item = _innerList[index];
            RemoveEventHandlers(item);
            _innerList.RemoveAt(index);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item));
        }

        #endregion

        #region IEnumerable Members (implemented explicitly)

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _innerList.GetEnumerator();
        }

        #endregion

        #region IList Members (implemented explicitly)

        int IList.Add(object value)
        {
            Add((clsComboTreeNode)value);
            return Count - 1;
        }

        bool IList.Contains(object value)
        {
            return Contains((clsComboTreeNode)value);
        }

        int IList.IndexOf(object value)
        {
            return IndexOf((clsComboTreeNode)value);
        }

        void IList.Insert(int index, object value)
        {
            Insert(index, (clsComboTreeNode)value);
        }

        bool System.Collections.IList.IsFixedSize
        {
            get
            {
                return false;
            }
        }

        bool System.Collections.IList.IsReadOnly
        {
            get
            {
                return false;
            }
        }

        void IList.Remove(object value)
        {
            Remove((clsComboTreeNode)value);
        }

        object System.Collections.IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                this[index] = (clsComboTreeNode)value;
            }
        }

        #endregion

        #region ICollection Members (implemented explicitly)

        void ICollection.CopyTo(Array array, int index)
        {
            ((ICollection)_innerList).CopyTo(array, index);
        }

        bool ICollection.IsSynchronized
        {
            get
            {
                return ((ICollection)_innerList).IsSynchronized;
            }
        }

        object ICollection.SyncRoot
        {
            get
            {
                return ((ICollection)_innerList).SyncRoot;
            }
        }

        #endregion

        #region INotifyCollectionChanged Members

        /// <summary>
        /// Fired when the collection (sub-tree) changes.
        /// </summary>
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        #endregion

        void item_CheckStateChanged(object sender, EventArgs e)
        {
            OnAfterCheck(new ComboTreeNodeEventArgs(sender as clsComboTreeNode));
        }
    }
}