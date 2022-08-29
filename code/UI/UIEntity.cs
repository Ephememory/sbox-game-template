using Sandbox.UI.Construct;

namespace Sandbox.UI;

public partial class UIEntity : HudEntity<RootPanel>
{
	public UIEntity()
	{
		Setup();
	}

	private void Setup()
	{
		if ( !Host.IsClient )
			return;

		RootPanel.DeleteChildren();

		var hudElements = TypeLibrary.GetAttributes<HudAttribute>();
		foreach ( var element in hudElements )
		{
			var instance = TypeLibrary.Create<Panel>( element.TargetType );
			if ( instance == null ) continue;
			RootPanel.AddChild( instance );
		}
	}

#if DEBUG
	[Event.Hotload]
	public void OnHotloadEvent()
	{
		Setup();
		Log.Info( "Hotloaded Hud" );
	}
#endif

}
