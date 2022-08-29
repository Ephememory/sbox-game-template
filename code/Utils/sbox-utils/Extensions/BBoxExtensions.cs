
namespace SboxUtils;

internal static class BBoxExtensions
{
    public static bool Contains(this BBox box, Vector3 position)
    {
        return box.AddPoint(position).Size == box.Size;
    }

    public static BBox ToWorldSpace(this BBox bbox, ModelEntity entity)
    {
        return new BBox
        {
            Mins = entity.Transform.PointToWorld(bbox.Mins),
            Maxs = entity.Transform.PointToWorld(bbox.Maxs)
        };
    }
}
