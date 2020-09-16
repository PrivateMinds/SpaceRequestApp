$(document).ready(function ()
{
   
    $('[id^="EditGrant"]').click(function (e)
    {
        var id = $(this).data("id");
        
        $("#divAddNewRequest").load("SpaceRequest/AddNewRequest",
            {
                SpaceRequestID: id
              
            }, function ()
            {
                $("#divSpaceRequestDetails").css("visibility", "visible");
                $("#divSpaceRequestDetails").load("SpaceRequest/EditRequest",
                    {

                    }, function () {

                       
                    });

            });
    });
});