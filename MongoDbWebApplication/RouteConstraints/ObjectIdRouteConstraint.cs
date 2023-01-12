using MongoDB.Bson;

namespace MongoDbWebApplication.RouteConstraints;

public class ObjectIdRouteConstraint : IRouteConstraint
{
    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        if (!values.ContainsKey(routeKey))
        {
            return false;
        }

        var value = values[routeKey]!.ToString();

        if (!ObjectId.TryParse(value, out _))
        {
            return false;
        }

        return true;
    }
}
