namespace ShipmentManagementSystem.Domain.Errors;

public static class UserErrors
{
    public static Error EmailAlreadyExists => Error.Create("User.EmailExists",
        "User with the provided email already exists.", enErrorTypes.Conflict);
}
