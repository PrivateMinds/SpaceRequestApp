using SpaceRequestDataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceRequestDataFactory
{
   public interface ISpaceRequestRepository
    {
        viewuserid GetSingleUserId(string UserID, string DomainName); //This method will return  single user data from viewuserid using a stored procedure
        IEnumerable<viewuserid> GetAllUseid(); //This method will return all data from viewuserid.
        SpaceRequest Add(SpaceRequest NewSpaceRequest);//This method will save data directly into the database table without the use of a stored procedure.
        SpaceRequest AddNewRequest(SpaceRequest NewSpaceRequest);//This method will save data using a stored procedure.
        SpaceRequest UpdateRequest(SpaceRequest NewSpaceRequest);//This method will update an existing request
        List<SpaceRequest> GetSpaceRequestDetails();

    }
}
