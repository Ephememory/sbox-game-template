namespace Sandbox;

partial class PlayerPawn : Player
{
	public ClothingContainer Clothing { get; } = new();

	public PlayerPawn() { }
	public PlayerPawn( Client client )
	{
		Clothing.LoadFromClient( client );
	}

	public override void Spawn()
	{
		base.Spawn();
		SetModel( "models/citizen/citizen.vmdl" );
	}

	public override void CreateHull()
	{
		SetupPhysicsFromAABB( PhysicsMotionType.Keyframed, new Vector3( -16, -16, 0 ), new Vector3( 16, 16, 72 ) );
		EnableHitboxes = true; // Enables the .vmdl hitboxes.
	}

	public override void Respawn()
	{
		base.Respawn();

		CameraMode = new FirstPersonCamera();
		Controller = new WalkController();
		Animator = new StandardPlayerAnimator();

		Clothing?.DressEntity( this );

		EnableAllCollisions = true;
		EnableDrawing = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;

		ClientRespawn( To.Single( Client ) );
	}

	public override void Simulate( Client cl )
	{
		if ( LifeState == LifeState.Dead )
		{
			if ( IsServer )
				Respawn();

			return;
		}

		var controller = GetActiveController();
		controller?.Simulate( cl, this, GetActiveAnimator() );
	}
}
