﻿using Murk.Common;
using System;

namespace Murk.Command
{
	/// <summary>
	/// Lightweight command that can be disable and reverse.
	/// Implements <see cref="System.Windows.Input.ICommand"/>
	/// </summary>
	public class CommandReversibleAndDisableAble : BaseCommandReversibleAndDisableAble
	{
		#region Attributes
		private Func<object, bool> _canExecuteAction;
		private Action<object> _actionToExecute;
		private Action<object> _undoAction;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <param name="canExecuteAction">Function that indicates
		/// whether or not the command can be executed.
		/// </param>
		/// <param name="actionToExecute">The command to be executed.
		/// </param>
		/// <param name="undoAction">The undo command operation.
		/// </param>
		/// <exception cref="ArgumentNullException" />
		public CommandReversibleAndDisableAble(
			Func<object, bool> canExecuteAction,
			Action<object> actionToExecute,
			Action<object> undoAction)
		{
			Guard.Against.Null(canExecuteAction, nameof(canExecuteAction));
			Guard.Against.Null(actionToExecute, nameof(actionToExecute));
			Guard.Against.Null(undoAction, nameof(undoAction));

			_canExecuteAction = canExecuteAction;
			_actionToExecute = actionToExecute;
			_undoAction = undoAction;
		}

		#region Interface Methods
		/// <inheritdoc/>
		/// <exception cref="ArgumentNullException" />
		public override bool CanExecute(object parameter)
		{
			Guard.Against.Null(parameter, nameof(parameter));

			if (IsDisposing)
				return false;

			return _canExecuteAction.Invoke(parameter);
		}

		/// <inheritdoc />
		/// <exception cref="ArgumentNullException" />
		public override void Execute(object parameter)
		{
			Guard.Against.Null(parameter, nameof(parameter));

			if (IsDisposing || !CanExecute(parameter))
				return;

			_actionToExecute.Invoke(parameter);
		}

		/// <inheritdoc />
		/// <exception cref="ArgumentNullException" />
		public override void Reverse(object parameter)
		{
			Guard.Against.Null(parameter, nameof(parameter));

			if (IsDisposing || !CanExecute(parameter))
				return;

			_undoAction.Invoke(parameter);
		}
		#endregion

		#region Dispose
		/// <inheritdoc/>
		protected override void Dispose(bool isDisposing)
		{
			base.Dispose(isDisposing);
			_canExecuteAction = null;
			_actionToExecute = null;
			_undoAction = null;
		}
		#endregion
	}

	/// <summary>
	/// Lightweight generic command that can be disable and reverse.
	/// Implements <see cref="System.Windows.Input.ICommand"/>
	/// </summary>
	/// <typeparam name="T"><inheritdoc/></typeparam>
	public class CommandReversibleAndDisableAble<T> : BaseCommandReversibleAndDisableAble<T>
	{
		#region Attributes
		private Func<T, bool> _canExecuteAction;
		private Action<T> _actionToExecute;
		private Action<T> _undoAction;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <param name="canExecuteAction">Function that indicates
		/// whether or not the command can be executed.
		/// </param>
		/// <param name="actionToExecute">The command to be executed.
		/// </param>
		/// <param name="undoAction">The undo command operation.
		/// </param>
		/// <exception cref="ArgumentNullException" />
		public CommandReversibleAndDisableAble(
			Func<T, bool> canExecuteAction,
			Action<T> actionToExecute,
			Action<T> undoAction)
		{
			Guard.Against.Null(canExecuteAction, nameof(canExecuteAction));
			Guard.Against.Null(actionToExecute, nameof(actionToExecute));
			Guard.Against.Null(undoAction, nameof(undoAction));

			_canExecuteAction = canExecuteAction;
			_actionToExecute = actionToExecute;
			_undoAction = undoAction;
		}

		#region Interface Methods
		/// <inheritdoc/>
		/// <exception cref="ArgumentNullException" />
		public override bool CanExecute(T parameter)
		{
			Guard.Against.Null(parameter, nameof(parameter));

			if (IsDisposing)
				return false;

			return _canExecuteAction.Invoke(parameter);
		}

		/// <inheritdoc />
		/// <exception cref="ArgumentNullException" />
		public override void Execute(T parameter)
		{
			Guard.Against.Null(parameter, nameof(parameter));

			if (IsDisposing || !CanExecute(parameter))
				return;

			_actionToExecute.Invoke(parameter);
		}

		/// <inheritdoc />
		/// <exception cref="ArgumentNullException" />
		public override void Reverse(T parameter)
		{
			Guard.Against.Null(parameter, nameof(parameter));

			if (IsDisposing || !CanExecute(parameter))
				return;

			_undoAction.Invoke(parameter);
		}
		#endregion

		#region Dispose
		/// <inheritdoc/>
		protected override void Dispose(bool isDisposing)
		{
			base.Dispose(isDisposing);
			_canExecuteAction = null;
			_actionToExecute = null;
			_undoAction = null;
		}
		#endregion
	}
}
