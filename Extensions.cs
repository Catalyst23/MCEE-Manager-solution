using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Shapes;


namespace MetroStyleBaseApp
{
    public static class Extensions
    {
        public enum PolygonHitTypes
        {
            None,
            Vertex,
            Edge,
        };

        public static bool IsAt(this Polygon polygon,
            Point point, out PolygonHitTypes hit_type,
            out int item_index)
        {
            const double hit_radius = 2;
            int num_points = polygon.Points.Count;

            // See if the point is at a vertex.
            for (int i = 0; i < num_points; i++)
            {
                if (point.DistanceToPoint(polygon.Points[i]) < hit_radius)
                {
                    hit_type = PolygonHitTypes.Vertex;
                    item_index = i;
                    return true;
                }
            }

            // See if the point is on an edge.
            Point closest;
            for (int i = 0; i < num_points; i++)
            {
                int j = (i + 1) % num_points;
                if (point.DistanceToSegment(
                    polygon.Points[i],
                    polygon.Points[j],
                    out closest) < hit_radius)
                {
                    hit_type = PolygonHitTypes.Edge;
                    item_index = i;
                    return true;
                }
            }
            hit_type = PolygonHitTypes.None;
            item_index = -1;
            return false;
        }

        public static double DistanceToPoint(this Point from_point, Point to_point)
        {
            double dx = to_point.X - from_point.X;
            double dy = to_point.Y - from_point.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        // Calculate the distance between
        // point pt and the segment p1 --> p2.
        public static double DistanceToSegment(this Point from_point,
            Point p1, Point p2, out Point closest)
        {
            double dx = p2.X - p1.X;
            double dy = p2.Y - p1.Y;
            if ((dx == 0) && (dy == 0))
            {
                // It's a point not a line segment.
                closest = p1;
                dx = from_point.X - p1.X;
                dy = from_point.Y - p1.Y;
                return Math.Sqrt(dx * dx + dy * dy);
            }

            // Calculate the t that minimizes the distance.
            double t = ((from_point.X - p1.X) * dx + (from_point.Y - p1.Y) * dy) /
                (dx * dx + dy * dy);

            // See if this represents one of the segment's
            // end points or a point in the middle.
            if (t < 0)
            {
                closest = new Point(p1.X, p1.Y);
                dx = from_point.X - p1.X;
                dy = from_point.Y - p1.Y;
            }
            else if (t > 1)
            {
                closest = new Point(p2.X, p2.Y);
                dx = from_point.X - p2.X;
                dy = from_point.Y - p2.Y;
            }
            else
            {
                closest = new Point(p1.X + t * dx, p1.Y + t * dy);
                dx = from_point.X - closest.X;
                dy = from_point.Y - closest.Y;
            }

            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
