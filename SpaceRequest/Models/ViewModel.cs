using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SpaceRequestDataModel;


namespace SpaceRequest.Models
{
    public class ViewModel
    {
        public SpaceRequestDataModel.SpaceRequest SpaceRequest { get; set; }

        public List<SpaceRequestDataModel.SpaceRequest> SpaceRequestList { get; set; }
        public SelectList SpaceRequestSelectList;
    }
}
