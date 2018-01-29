using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace ISC.ViewModel.Base
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;

        private readonly Func<object, bool> canExecute;

        private List<WeakReference> weakHandlers;

        public RelayCommand(Action execute) : this(execute, null) { }

        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public RelayCommand(Action execute, Func<bool> canExecute)
            : this(execute != null ? p => execute() : (Action<object>)null, canExecute != null ? p => canExecute() : (Func<object, bool>)null)
        { }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            if (execute != null)
            {
                this.execute = execute;
                this.canExecute = canExecute;
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (weakHandlers == null)
                {
                    weakHandlers = new List<WeakReference>(new[] { new WeakReference(value) });
                }
                else
                {
                    weakHandlers.Add(new WeakReference(value));
                }
            }
            remove
            {
                if (weakHandlers == null) { return; }
                for (int i = weakHandlers.Count - 1; i >= 0; i--)
                {
                    WeakReference weakReference = weakHandlers[i];
                    EventHandler handler = weakReference.Target as EventHandler;
                    if (handler == null || handler == value)
                    {
                        weakHandlers.RemoveAt(i);
                    }
                }
            }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute != null ? canExecute(parameter) : true;
        }

        public void Execute(object parameter)
        {
            if (!CanExecute(parameter))
            {
                throw new InvalidOperationException("The command cannot be executed because the canExecute action returned false.");
            }
            execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged(EventArgs.Empty);
        }

        protected virtual void OnCanExecuteChanged(EventArgs e)
        {
            PurgeWeakHandlers();
            if (weakHandlers == null) { return; }
            WeakReference[] handlers = weakHandlers.ToArray();
            foreach (WeakReference reference in handlers)
            {
                (reference.Target as EventHandler)?.Invoke(this, e);
            }
        }

        private void PurgeWeakHandlers()
        {
            if (weakHandlers == null) { return; }
            for (int i = weakHandlers.Count - 1; i >= 0; i--)
            {
                if (!weakHandlers[i].IsAlive)
                {
                    weakHandlers.RemoveAt(i);
                }
            }
            if (weakHandlers.Count == 0) { weakHandlers = null; }
        }
    }
}
