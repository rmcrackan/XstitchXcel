using System;
using XstitchXcelLib.DataClasses;

namespace XstitchXcelLib.Tools
{
	public abstract class ToolBase
	{
		protected DmcColorProcessor DmcColorProcessor { get; } = new();

		protected Pattern Pattern { get; }

		protected ToolBase(Pattern pattern) => Pattern = pattern;
	}
}
