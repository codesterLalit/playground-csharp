using Microsoft.Extensions.DependencyInjection;

namespace Play.cleanarch;

public class SingletonTracker {public Guid InstanceId {get;} = Guid.NewGuid();}
public class ScopeTracker {public Guid InstanceI{get; } = Guid.NewGuid();}
public class TransientTracker {public Guid InstanceId{get;} = Guid.NewGuid();}

public static class Ex04_ServiceLifetimes
{
    public static void Run()
    {

    }
}