using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SpaceRequestDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceRequestDataFactory
{
    public class SQLSpaceRequestRepository : ISpaceRequestRepository
    {
        //create a variable of type AppDBContext. Make it private so that it is only available to the members of this class.
        private readonly AppDbContext context;

        //Through constructor dependency injection we inject the AppDBContext object and store it within the variable above.
        public SQLSpaceRequestRepository(AppDbContext Context)
        {
            this.context = Context;
        }

        //This method will retun single user data from viewuserid using a stored procedure
        public SpaceRequestDataModel.viewuserid GetSingleUserId(string UserID, string DomainName)
        {
            //initialize your class.
            var viewuserid = new viewuserid();

            //Define your Stored procedure parameters.
            var Userid = new SqlParameter("@Userid", UserID);
            var Domainname = new SqlParameter("@Domainname", DomainName);

            //Always embed your entity framework method calls in a try catch block ,to catch any exceptions.
            try
            {
                //Once you create your stored procedure in the database,
                //Use the context variable defined above to call the FromSQLRaw entity framework method and pass your stored procedure and its respective parameters defined above.
                viewuserid = context.viewuserid
                     .FromSqlRaw<viewuserid>("uspvwuseridGetData @Userid ,@Domainname", Userid, Domainname)
                      .ToList().FirstOrDefault();

            }
            catch (Exception e)
            {
                string msg = e.Message;
                viewuserid.FirstName = msg;
            }

            return viewuserid;

        }

        //This method will return all data from viewuserid.
        public IEnumerable<viewuserid> GetAllUseid()
        {
            viewuserid viewuserid = new viewuserid();

            return context.viewuserid;
        }


        //This method will save data directly into the database table without the use of a stored procedure.
        public SpaceRequest Add(SpaceRequest NewSpaceRequest)
        {
            //Always embend your entity framework method calls in a try catch block ,to catch any exceptions.
            try
            {
                //Use the entityframework 'Add' method to pass your object that contains user data
                context.SpaceRequest.Add(NewSpaceRequest);
                //call entityframework 'SaveChanges() method to save your data.
                context.SaveChanges();

                // Custom Success message to show user
                NewSpaceRequest.RequestorName = "Success";

            }
            catch (Exception e)
            {
                // system error message to show user
                NewSpaceRequest.RequestorName = e.Message;
            }

            return NewSpaceRequest;
        }

        //This method uses a stored procedure to add a new request to the database.
        public SpaceRequest AddNewRequest(SpaceRequest NewRequest)
        {
            //initialize your class.
            var SpaceRequest = new SpaceRequest();

            //Define your Stored procedure parameters.
            var Userid = new SqlParameter("@txtUserid", NewRequest.RequestorID);
            var Requestor = new SqlParameter("@txtRequestor", NewRequest.RequestorName);
            var RequestedFor = new SqlParameter("@txtRequestedFor", NewRequest.EmpName);
            var txtFte = new SqlParameter("@txtFte", Convert.ToDecimal(NewRequest.FTE));
            var FteMpe = new SqlParameter("@txtFteMpe", Convert.ToDecimal(NewRequest.FTE_MPE));
            var CurrentSpace = new SqlParameter("@txtCurrentSpace", NewRequest.CurrentSpace);
            var JobTitle = new SqlParameter("@txtJobTitle", NewRequest.JobTitle);
            var PayBand = new SqlParameter("@txtPayBand", NewRequest.PayBand);
            var SpaceDescription = new SqlParameter("@txtRequest", NewRequest.SpaceDescription);

            //Always embed your entity framework method calls in a try catch block ,to catch any exceptions.
            try
            {
                //Once you create your stored procedure in the database,
                //Use the context variable defined above to call the FromSQLRaw entityframework method and pass your stored procedure and its respective parameters defined above.
                SpaceRequest = context.SpaceRequest.FromSqlRaw<SpaceRequest>("uspSpaceRequestSaveData @txtUserid, @txtRequestor, @txtRequestedFor,@txtFte,@txtFteMpe," +
                                                      "@txtCurrentSpace,@txtJobTitle,@txtPayBand,@txtRequest",
                                                         Userid, Requestor, RequestedFor, txtFte, FteMpe, CurrentSpace, JobTitle, PayBand, SpaceDescription).ToList().FirstOrDefault();


            }
            catch (Exception e)
            {
                SpaceRequest.RequestorName = e.Message;

                // If any columns are missing, or are returned with names not mapped to properties, an   InvalidOperationException will be raised with the message:
                //'The required column '[name of first missing column]' was not present in the results of a 'FromSqlRaw' operation.'


            }

            return NewRequest;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UpdateRequest"></param>
        /// <returns></returns>
        public SpaceRequest UpdateRequest(SpaceRequest UpdateRequest)
        {
            try
            {
                var SpaceRequest = context.SpaceRequest.Attach(UpdateRequest);
                SpaceRequest.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();

                // Custom Success message to show user
                UpdateRequest.SpaceDescription = "Success";
            }
            catch (Exception e)
            {
                // system  error message to show user
                
                    UpdateRequest.SpaceDescription = "Record exists";
               
            }


            return UpdateRequest;
        }
        public List<SpaceRequest> GetSpaceRequestDetails()
        {

            return context.SpaceRequest.ToList();

        }

    }
}

