using System;
using System.Collections.Generic;
using System.Linq;
using XstitchXcelLib.Config;
using XstitchXcelLib.DataClasses;

namespace XstitchXcelLib.Tools
{
	public abstract class ToolBase
	{
		protected DmcColorProcessor DmcColorProcessor { get; } = new DmcColorProcessor();

		protected Pattern Pattern { get; }

		protected ToolBase(Pattern pattern) => Pattern = pattern;
	}
}
