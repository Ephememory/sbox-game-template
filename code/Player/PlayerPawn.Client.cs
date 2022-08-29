namespace Sandbox;

partial class PlayerPawn : Player
{
	public override void ClientSpawn()
	{
		base.ClientSpawn();
	}

	[ClientRpc]
	public void ClientRespawn()
	{
	}

	public override void FrameSimulate( Client cl )
	{
		base.FrameSimulate( cl );
	}
}
