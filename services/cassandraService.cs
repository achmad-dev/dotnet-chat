using Cassandra;
using Microsoft.Extensions.Options;

public class CassandraService
{
    private readonly Cassandra.ISession _session;

    public CassandraService(IOptions<CassandraSettings> settings)
    {
        var cluster = Cluster.Builder()
            .AddContactPoints(settings.Value.ContactPoints)
            .Build();
        _session = cluster.Connect(settings.Value.KeySpace);
    }

    public Cassandra.ISession GetSession()
    {
        return _session;
    }
}

public class CassandraSettings
{
    public required string ContactPoints { get; set; }
    public required string KeySpace { get; set; }
}