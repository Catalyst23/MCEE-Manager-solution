using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Shapes;
using System.Windows.Markup;
using System.Xml;
using System.Windows.Controls.Primitives;

namespace UndoRedo_Memento
{

    #region Memento
    public class Memento
    {
        private List<UIElement> _ContainerState;

        public List<UIElement> ContainerState
        {
            get { return _ContainerState; }

        }
        public Memento(List<UIElement> containerState)
        {
            this._ContainerState = containerState;
        }

    }

    #endregion

    #region MementoOriginator
    public class MementoOriginator
    {

        private Canvas _Container;

        public MementoOriginator(Canvas container)
        {
            _Container = container;
        }

        public Memento getMemento()
        {
            List<UIElement> _ContainerState = new List<UIElement>();

            foreach (UIElement item in _Container.Children)
            {
                if (!(item is Thumb))
                {
                    UIElement newItem = DeepClone(item);
                    _ContainerState.Add(newItem);
                }
            }

            return new Memento(_ContainerState);

        }

        public void setMemento(Memento memento)
        {
            _Container.Children.Clear();
            Memento memento1 = MementoClone(memento);
            foreach (UIElement item in memento1.ContainerState)
            {
                ((Shape)item).Stroke = System.Windows.Media.Brushes.Black;
                _Container.Children.Add(item);
            }
        }

        public Memento MementoClone(Memento memento)
        {
            List<UIElement> _ContainerState = new List<UIElement>();

            foreach (UIElement item in memento.ContainerState)
            {
                if (!(item is Thumb))
                {
                    UIElement newItem = DeepClone(item);
                    _ContainerState.Add(newItem);
                }
            }

            return new Memento(_ContainerState);

        }
        private UIElement DeepClone(UIElement element)
        {
            string shapestring = XamlWriter.Save(element);
            StringReader stringReader = new StringReader(shapestring);
            XmlTextReader xmlTextReader = new XmlTextReader(stringReader);
            UIElement DeepCopyobject = (UIElement)XamlReader.Load(xmlTextReader);
            return DeepCopyobject;
        }

    }
    #endregion

    #region Caretaker

    class Caretaker
    {
        private Stack<Memento> UndoStack = new Stack<Memento>();
        private Stack<Memento> RedoStack = new Stack<Memento>();

        public Memento getUndoMemento()
        {
            if (UndoStack.Count >= 2)
            {
                RedoStack.Push(UndoStack.Pop());
                return UndoStack.Peek();
            }
            else
                return null;
        }
        public Memento getRedoMemento()
        {
            if (RedoStack.Count != 0)
            {
                Memento m = RedoStack.Pop();
                UndoStack.Push(m);
                return m;
            }
            else
                return null;
        }
        public void InsertMementoForUndoRedo(Memento memento)
        {
            if (memento != null)
            {
                UndoStack.Push(memento);
                RedoStack.Clear();
            }
        }
        public bool IsUndoPossible()
        {
            if (UndoStack.Count >= 2)
            {
                return true;
            }
            else
                return false;

        }
        public bool IsRedoPossible()
        {
            if (RedoStack.Count != 0)
            {
                return true;
            }
            else
                return false;
        }

    }

    #endregion

    #region UndoRedo
    public class UndoRedo : IUndoRedo
    {


        Caretaker _Caretaker = new Caretaker();
        MementoOriginator _MementoOriginator = null;
        public event EventHandler EnableDisableUndoRedoFeature;

        public UndoRedo(Canvas container)
        {
            _MementoOriginator = new MementoOriginator(container);

        }
        public void Undo(int level)
        {
            Memento memento = null;
            for (int i = 1; i <= level; i++)
            {
                memento = _Caretaker.getUndoMemento();
            }
            if (memento != null)
            {
                _MementoOriginator.setMemento(memento);

            }
            if (EnableDisableUndoRedoFeature != null)
            {
                EnableDisableUndoRedoFeature(null, null);
            }

        }

        public void Redo(int level)
        {
            Memento memento = null;
            for (int i = 1; i <= level; i++)
            {
                memento = _Caretaker.getRedoMemento();
            }
            if (memento != null)
            {
                _MementoOriginator.setMemento(memento);

            }
            if (EnableDisableUndoRedoFeature != null)
            {
                EnableDisableUndoRedoFeature(null, null);
            }
        }

        public void SetStateForUndoRedo()
        {
            Memento memento = _MementoOriginator.getMemento();
            _Caretaker.InsertMementoForUndoRedo(memento);
            if (EnableDisableUndoRedoFeature != null)
            {
                EnableDisableUndoRedoFeature(null, null);
            }
        }

        public bool IsUndoPossible()
        {
            return _Caretaker.IsUndoPossible();

        }
        public bool IsRedoPossible()
        {
            return _Caretaker.IsRedoPossible();
        }


    }



    #endregion

    #region Interface
    interface IUndoRedo
    {
        void Undo(int level);
        void Redo(int level);
        void SetStateForUndoRedo();

    }
    #endregion

}
