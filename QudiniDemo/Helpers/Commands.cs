using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QudiniDemo.Helpers
{
	public interface IAsyncCommand : ICommand
	{
		Task Execute(object parameter);
	}

	public class ActionCommand : ICommand
	{
		private readonly Func<bool> _canExecute;
		private readonly Action _execute;
		private readonly Action<object> _executeWithParam;
		private bool _isExecuting;

		public ActionCommand(Action execute)
			: this(execute, () => true)
		{
		}

		public ActionCommand(Action execute, Func<bool> canExecute)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

		public ActionCommand(Action<object> execute) : this(execute, () => true)
		{
		}

		public ActionCommand(Action<object> execute, Func<bool> canExecute)
		{
			_executeWithParam = execute;
			_canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			// if the command is not executing, execute the users' can execute logic
			return !_isExecuting && _canExecute();
		}

		public event EventHandler CanExecuteChanged;

		public void Execute(object parameter)
		{
			// tell the button that we're now executing...
			_isExecuting = true;
			OnCanExecuteChanged();

			try
			{
				if (_execute != null && parameter == null)
				{
					_execute.Invoke();
				}

				if (_executeWithParam != null && parameter != null)
				{
					_executeWithParam.Invoke(parameter);
				}
			}
			finally
			{
				// tell the button we're done
				_isExecuting = false;
				OnCanExecuteChanged();
			}
		}

		protected virtual void OnCanExecuteChanged()
		{
			if (CanExecuteChanged != null)
			{
				CanExecuteChanged(this, new EventArgs());
			}
		}
	}

	public class AsyncCommand : IAsyncCommand
	{
		readonly Func<object, bool> _canExecute;
		bool _isExecuting;
		readonly Func<object, Task> _action;

		public event EventHandler CanExecuteChanged;

		public AsyncCommand(Func<object, Task> action)
		{
			_action = action;
		}

		public AsyncCommand(Func<object, Task> action, Func<object, bool> canExecute)
			: this(action)
		{
			_canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			var canExecutResult = _canExecute == null || _canExecute(parameter);
			return !_isExecuting && canExecutResult;
		}

		async void ICommand.Execute(object parameter)
		{
			await Execute(parameter);
		}

		public async Task Execute(object parameter)
		{
			_ChangeIsExecuting(true);
			try
			{
				await _action(parameter);
			}
			finally
			{
				_ChangeIsExecuting(false);
			}
		}

		private void _ChangeIsExecuting(bool newValue)
		{
			if (newValue == _isExecuting)
			{
				return;
			}
			_isExecuting = newValue;
			_OnCanExecuteChanged();
		}

		void _OnCanExecuteChanged()
		{
			var handler = CanExecuteChanged;
			if (handler != null)
			{
				handler(this, EventArgs.Empty);
			}
		}
	}
}
