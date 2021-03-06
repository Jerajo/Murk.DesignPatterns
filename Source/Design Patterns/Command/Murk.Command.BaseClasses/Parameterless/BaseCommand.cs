﻿using Murk.Common;

namespace Murk.Command.Parameterless
{
	/// <summary>
	/// Base class for parameterless commands.
	/// </summary>
	public abstract class BaseCommand : BaseDisposable, ICommand
	{
		/// <inheritdoc/>
		public abstract void Execute();
	}
}
