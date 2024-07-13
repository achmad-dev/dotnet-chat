using Cassandra;

#pragma warning disable CA1050 // Declare types in namespaces
public class CassandraInitializer
#pragma warning restore CA1050 // Declare types in namespaces
{
    private readonly Cassandra.ISession _session;

    public CassandraInitializer(CassandraService cassandraService)
    {
        _session = cassandraService.GetSession();
    }

    public void Initialize()
    {
        CreateKeyspace();
        CreateTables();
    }

    private void CreateKeyspace()
    {
        _session.Execute("CREATE KEYSPACE IF NOT EXISTS chatapp WITH REPLICATION = { 'class' : 'SimpleStrategy', 'replication_factor' : 1 };");
    }

    private void CreateTables()
    {
        _session.Execute(@"
            CREATE TABLE IF NOT EXISTS chatapp.users (
                id uuid PRIMARY KEY,
                username text,
                password_hash text
            );
        ");

        _session.Execute(@"
            CREATE TABLE IF NOT EXISTS chatapp.messages (
                id uuid PRIMARY KEY,
                user_id uuid,
                room_name text,
                message text,
                timestamp timestamp
            );
        ");
    }
}