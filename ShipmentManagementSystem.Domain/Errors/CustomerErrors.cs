namespace ShipmentManagementSystem.Domain.Errors;

public static class CustomerErrors
{
    public static Error NotFound(int id) => Error.Create("Customer.NotFound", $"Customer With Id: {id} Was Not Found", enErrorTypes.NotFound);

    public static Error AlreadyExists(int id) => Error.Create("Customer.AlreadyExists", $"Customer With Id: {id} Already Exists", enErrorTypes.Conflict);

}
