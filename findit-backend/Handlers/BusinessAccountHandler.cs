using findit_backend.Models;
using System.Data.SqlClient;

namespace findit_backend.Handlers;

public class BusinessAccountHandler : BaseHandler
{
    public bool CreateBusinessAccount(BusinessAccountModel businessAccount)
    {
        var query = @"INSERT INTO [dbo].[Users] ([Name], [LastNames], [LegalID], [Email], [PasswordHash], 
                                                      [PhoneNumber], [BirthDate])
                        VALUES (@Name, @LastNames, @LegalID, @Email, @PasswordHash, @PhoneNumber, @BirthDate)";

        var queryCommand = new SqlCommand(query, _connection);

        queryCommand.Parameters.AddWithValue("@CompanyName", businessAccount.CompanyName);
        queryCommand.Parameters.AddWithValue("@CompanyEmail", businessAccount.CompanyEmail);
        queryCommand.Parameters.AddWithValue("@OwnerName", businessAccount.OwnerName);
        queryCommand.Parameters.AddWithValue("@OwnerLastNames", businessAccount.OwnerLastNames);
        queryCommand.Parameters.AddWithValue("@PhoneNumber", businessAccount.PhoneNumber);
        queryCommand.Parameters.AddWithValue("@ScheduleStart", businessAccount.ScheduleStart);
        queryCommand.Parameters.AddWithValue("@ScheduleEnd", businessAccount.ScheduleEnd);
        queryCommand.Parameters.AddWithValue("@IdNumber", businessAccount.IdNumber);
        queryCommand.Parameters.AddWithValue("@OfferedProducts", businessAccount.OfferedProducts);
        queryCommand.Parameters.AddWithValue("@AddressType", businessAccount.AddressType);
        queryCommand.Parameters.AddWithValue("@AddressProvince", businessAccount.AddressProvince);
        queryCommand.Parameters.AddWithValue("@AddressCanton", businessAccount.AddressCanton);
        queryCommand.Parameters.AddWithValue("@AddressDistrict", businessAccount.AddressDistrict);
        queryCommand.Parameters.AddWithValue("@AddressAdditionalDetails", businessAccount.AddressAdditionalDetails);




        return ExecuteNonQuery(queryCommand);
    }
}
