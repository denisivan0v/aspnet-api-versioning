using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage( "Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Microsoft.Web.Http.Dispatcher", Justification = "Will grow over time" )]
[assembly: SuppressMessage( "Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Microsoft.Web.Http.Controllers", Justification = "Will grow over time" )]
[assembly: SuppressMessage( "Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Microsoft.Web.Http.Routing", Justification = "Will grow over time" )]
[assembly: SuppressMessage( "Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Web.Http", Justification = "Intentionally aligns with system namespace" )]