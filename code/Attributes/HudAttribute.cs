using System;

namespace Sandbox.UI;

[AttributeUsage( AttributeTargets.Class )]
internal class HudAttribute : LibraryAttribute, ITypeAttribute
{
	public Type TargetType { get; set; }
}