using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaceRequestDataFactory;
using SpaceRequestDataModel;
using SpaceRequest.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace SpaceRequest.Controllers
{
    public class SpaceRequestController : Controller
    {
        //Create a reference variable of ISpaceRequestRepository
        private readonly ISpaceRequestRepository _spaceRequestRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;


        // Inject an instance of ISpaceRequestRepository through the constructor of SpaceRequestFormController class.
        //Initialize the variable through the constructor
        public SpaceRequestController(ISpaceRequestRepository SpaceRequestRepository, IHttpContextAccessor httpContextAccessor)
        {
            _spaceRequestRepository = SpaceRequestRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
        public IActionResult Index()
        {
            //SpaceRequestDataModel.SpaceRequest Model = new SpaceRequestDataModel.SpaceRequest();
            //initialize  view model
            var Model = new ViewModel { };

            viewuserid UserData = GetUserId();

            // Use viewbag to pass the username to the create view  Requestor field.
            ViewBag.RequestorName = "";

            if (UserData != null)
            {
                ViewBag.RequestorName = UserData.username;
            }

            //FILL DROPDOWN
            Model.SpaceRequestList = _spaceRequestRepository.GetSpaceRequestDetails();
            Model.SpaceRequestList.Insert(0, new SpaceRequestDataModel.SpaceRequest { RequestorName = "...Select User ID", RequestorID = "" });

           

            return View(Model);
        }

        /// <summary>
        /// //======= THIS METHOD IS NOT IN USE, IT WAS FOR THE TRAINING CLASS DEMO ONLY========
        /// </summary>
        /// <param name="SpaceRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(SpaceRequestDataModel.SpaceRequest SpaceRequest)
        {
            //Get current user "UserID"
           // string UserID = System.Environment.UserName; use in development
            string UserID = _httpContextAccessor.HttpContext.User.Identity.Name; //use in prod

            //Invoke GetUserId() method which returns current user information.
            viewuserid UserData = GetUserId();

            //Get username from the information returned
            // Use a viewbag to pass and default Requestor field value with username returned by GetUserId() method on page load.
            ViewBag.RequestorName = "";
            if (UserData != null)
            {
                ViewBag.RequestorName = UserData.username;
            }


            //Validate incoming field values to make sure all requred fields are not null
            if (ModelState.IsValid)
            {
                SpaceRequest.RequestorID = UserID.ToUpper();
                SpaceRequest.InsertDate = DateTime.Now;

                //Use the _spaceRequestRepository variable  to call the  AddNewRequest method.
                SpaceRequestDataModel.SpaceRequest NewRequest = _spaceRequestRepository.Add(SpaceRequest);

                //Clear input fields.
                ModelState.Clear();
            }

            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SpaceRequestID"></param>
        /// <returns></returns>
        public IActionResult AddNewRequest(int SpaceRequestID)
        {
            var Model = new ViewModel {
                SpaceRequest = new SpaceRequestDataModel.SpaceRequest()
        };
            SpaceRequestDataModel.SpaceRequest SpaceRequest = new SpaceRequestDataModel.SpaceRequest();

            Model.SpaceRequestList = _spaceRequestRepository.GetSpaceRequestDetails().Where(s => s.SpaceRequestID == SpaceRequestID).ToList();
            viewuserid UserData = GetUserId();

            // Use viewbag to pass the username to the create view  Requestor field.
            ViewBag.RequestorName = "";

            if (UserData != null)
            {
                ViewBag.RequestorName = UserData.username;
            }


            foreach (var item in Model.SpaceRequestList)
            {
                Model.SpaceRequest.SpaceRequestID = item.SpaceRequestID;
                Model.SpaceRequest.RequestorName = ViewBag.RequestorName;
                Model.SpaceRequest.RequestorID = item.RequestorID;
                Model.SpaceRequest.EmpName = item.EmpName;
                Model.SpaceRequest.FTE = item.FTE;
                Model.SpaceRequest.FTE_MPE = item.FTE_MPE;
                Model.SpaceRequest.CurrentSpace = item.CurrentSpace;
                Model.SpaceRequest.JobTitle = item.JobTitle;
                Model.SpaceRequest.PayBand = item.PayBand;
                Model.SpaceRequest.SpaceDescription = item.SpaceDescription;
                
            }

            return View(Model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult EditRequest()
        {
            var Model = new ViewModel { };

            SpaceRequestDataModel.SpaceRequest SpaceRequest = new SpaceRequestDataModel.SpaceRequest();

            Model.SpaceRequestList = _spaceRequestRepository.GetSpaceRequestDetails();

            return View(Model);
        }
        /// <summary>
        /// The SaveNewRequest method is called from jQuery when user submits a new request
        /// All input validation happens  in jquery before this method is called.
        /// </summary>
        /// <returns>Jason object</returns>
        public JsonResult SaveNewRequest(SpaceRequestDataModel.SpaceRequest SpaceRequest)
        {
            var NewInsertedID = 0;
            var Requestor = "";
            //Get current user "UserID"
            // string UserID = System.Environment.UserName; //use in development
            //============================================================================================================
            //use in prod ONLY
            string UserID = _httpContextAccessor.HttpContext.User.Identity.Name;
            if (UserID.Substring(0, 2) == "CS")
            {

                UserID = UserID.Substring(3);

            }
            else
            {

                UserID = UserID.Substring(10);

            }
            //=================================================================================================================
            viewuserid UserData = GetUserId();


            SpaceRequest.RequestorID = UserID.ToUpper();
            SpaceRequest.InsertDate = DateTime.Now;

            if(SpaceRequest.SpaceRequestID == 0)
            {
                var newRequest = _spaceRequestRepository.Add(SpaceRequest);
                NewInsertedID = newRequest.SpaceRequestID;
            }
            else
            {
                var newRequest = _spaceRequestRepository.UpdateRequest(SpaceRequest);
                NewInsertedID = newRequest.SpaceRequestID;
            }
           

            if (UserData != null)
            {
                Requestor = UserData.username;
            }

            var Results = new { NewInsertedID, Requestor };

            return Json(Results, new Newtonsoft.Json.JsonSerializerSettings());
        }
        /// <summary>
        /// With this method , we want to get the current logged in user information.
        /// From the information returned, we will extract the user name and default it in the requestor's field.
        /// </summary>
        /// <returns></returns>
        public viewuserid GetUserId()
        {
            //Get current  "UserID"

//==================================================================================================================================
/// use in development ONLY
            string UserID = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string DomainName = UserID.Substring(0, 9);
            if (DomainName.Substring(0, 2) == "CS")
            {
                DomainName = DomainName.Substring(0, 2);
                UserID = UserID.Substring(3);
            }
            else
            {
                UserID = UserID.Substring(10);

            }
            //END OF :use in development ONLY
            //===============================================================================================================================================

            //////use in production ONLY
            //string UserID = _httpContextAccessor.HttpContext.User.Identity.Name;
            //UserID = "GHCMASTER\\calijr1"; //GHCMASTER USER TEST VALUE.
            //ViewBag.UserID = UserID;

            //string DomainName = "";//UserID.Substring(0, 9);
            //if (UserID.Substring(0, 2) == "CS")
            //{
            //    DomainName = UserID.Substring(0, 2);
            //    UserID = UserID.Substring(3);

            //    //ViewBag.UserID = UserID;
            //}
            //else
            //{
            //    DomainName = UserID.Substring(0, 9);
            //    UserID = UserID.Substring(10);
            //    ViewBag.UserID = DomainName;
            //}
            //END OF : use in production ONLY

            //===========================================================================================================================================
            //Call the GetSingleUserId method from your repository and pass the expected parameters
            viewuserid VIewUserID = _spaceRequestRepository.GetSingleUserId(UserID, DomainName);
            //ViewBag.UserID = VIewUserID.FirstName;

            return VIewUserID;
        }



    }
}