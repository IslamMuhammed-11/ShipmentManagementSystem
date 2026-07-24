using System;
using System.Collections.Generic;
using System.Text;

namespace ShipmentManagementSystem.Application.Interfaces.Validator;

public interface IPasswordHasher
{

    string HashPassword(string password);

    bool VerifyPassword(string password , string hashedPassword);

}
