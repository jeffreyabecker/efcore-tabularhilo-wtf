using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;

namespace ConsoleApp2.HiLo.ValueGeneration;

public interface ITabularSequenceAccessor
{
    long Next();
    Task<long> NextAsync(CancellationToken cancellationToken);
}
public class TabularSequenceAccessor : ITabularSequenceAccessor
{
    private readonly IModel _model;
    private IRelationalConnection _connection;
    private IRelationalCommandDiagnosticsLogger _commandLogger;

    public TabularSequenceAccessor(IModel model, IRelationalConnection connection, IRelationalCommandDiagnosticsLogger commandLogger)
    {
        _model = model;
        _connection = connection;
        _commandLogger = commandLogger;
    }


    public long Next()
    {
        throw new NotImplementedException();
        // IEntityType? sequencesTable = _model.FindEntityType(typeof(SequenceTable).FullName);


        // var cmd = _connection.RentCommand();
        //SelectExpression.
    }

    public Task<long> NextAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
