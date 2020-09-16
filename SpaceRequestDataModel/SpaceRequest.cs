using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Web.Mvc;

namespace SpaceRequestDataModel
{
    [Table("tblSpaceRequest")]
    public class SpaceRequest
    {
        [Key]
        public int SpaceRequestID { get; set; }
        public string RequestorID { get; set; }

        [Required(ErrorMessage = "Requestor Name is required")]
        public string RequestorName { get; set; }

        [Required(ErrorMessage = "Requested for is required")]
        [Display(Name = "Requested For:")]
        public string EmpName { get; set; }

        //[Required(ErrorMessage = "FTE is required:")]
        [Required]
        [Display(Name = "Person's FTE:")]
        public decimal FTE { get; set; }

        [Required]
        [Display(Name = "Person's FTE at MPE:")]
        public decimal FTE_MPE { get; set; }

        [Required]
        [Display(Name = "Person's Current Space:")]
        public string CurrentSpace { get; set; }

        [Required]
        [Display(Name = "Person's Job Title:")]
        public string JobTitle { get; set; }

        [Required]
        [Display(Name = "Person's Pay Band:")]
        public string PayBand { get; set; }

        [Required]
        [Display(Name = "Space Description:")]
        public string SpaceDescription { get; set; }

        public DateTime InsertDate { get; set; }

      

    }
}
