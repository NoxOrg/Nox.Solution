using Json.Schema.Generation;

namespace Nox.Solution
{
    public class Endpoints
    {
        [Title("Details pertaining to the API server settings in a Nox solution.")]
        [Description("Defines settings pertinent to an API server here. These include name, serverUri, Port, connection credentials and provider (OData, gRPC, GraphQL and AttributeRouting.")]
        public ApiServer? ApiServer { get; internal set; }

        [Title("Details pertaining to the BFF server settings in a Nox solution.")]
        [Description("Defines settings pertinent to a BFF (Backend for Frontend) server here. These include name, serverUri, Port, connection credentials and provider (Blazor).")]
        public BffServer? BffServer { get; internal set; }
    }
}