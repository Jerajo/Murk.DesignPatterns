﻿namespace Murk.Command
{
	/// <summary>
	/// Base class for reversible and disposable commands.
	/// Implements <see cref="System.Windows.Input.ICommand"/>.
	/// </summary>
	public abstract class BaseCommandReversibleAndDisableAble :
		BaseCommandDisableAble,
		ICommandReversibleAndDisableAble
	{
		/// <inheritdoc/>
		public abstract void Reverse(object parameter);
	}

	/// <summary>
	/// Base class for reversible and disposable commands.
	/// Implements <see cref="System.Windows.Input.ICommand"/>.
	/// </summary>
	/// <typeparam name="T">Parameter type.</typeparam>
	public abstract class BaseCommandReversibleAndDisableAble<T> :
		BaseCommandDisableAble<T>,
		ICommandReversibleAndDisableAble<T>
	{
		/// <inheritdoc/>
		public abstract void Reverse(T parameter);
	}
}
