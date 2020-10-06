$(document).ready(function ()
{
   
    if ($("#txtRequestor").val() == "")
    {
        $('#txtRequestor').attr("readonly", false);
        $('#txtRequestor').attr("disabled", false);
    }

    if ($("#txtSpaceRequestID").val() == "") {

        $('#txtSpaceRequestID').val(0)

    }

 //=============================================================================================================================================================================================================
    $("#cboSpaceRequest").change(function ()
    {
        var Name = $("#cboSpaceRequest option:selected").text();
      
        alert(Name);
        alert($(this).val());
    });
        
 //============================================================================================================================================================================================================
    $("#btnSubmitRequest").click(function ()
    {
        $("#txtStopLoop").val(0);
        var foundempty = false;

        // Validate required fields
        if ($("#txtRequestor").val() == "") {
            $("#txtRequestor").css('background', '#ffd9d9')
            $("#txtRequestor").focus();
            foundempty = true;
           
        }
        if ($("#txtRequestorFor").val() == "") {
            $("#txtRequestorFor").css('background', '#ffd9d9')
            $("#txtRequestorFor").focus();
            foundempty = true;
            
        }
        if ($("#txtFTE").val() == 0) {
            $("#txtFTE").css('background', '#ffd9d9')
            $("#txtFTE").focus();
            foundempty = true;
        }
        if ($("#txtFTEMPE").val() == 0) {
            $("#txtFTEMPE").css('background', '#ffd9d9')
            $("#txtFTEMPE").focus();
            foundempty = true;
        }
        if ($("#txtFCurrentSpace").val() == "") {
            $("#txtFCurrentSpace").css('background', '#ffd9d9')
            $("#txtFCurrentSpace").focus();
            foundempty = true;
        }
        if ($("#txtJobTitle").val() == "") {
            $("#txtJobTitle").css('background', '#ffd9d9')
            $("#txtJobTitle").focus();
            foundempty = true;
        }
        if ($("#txtPayBand").val() == "") {
            $("#txtPayBand").css('background', '#ffd9d9')
            $("#txtPayBand").focus();
            foundempty = true;
        }
        if ($("#txtDescription").val() == "") {
            $("#txtDescription").css('background', '#ffd9d9')
            $("#txtDescription").focus();
            foundempty = true;
        }

        if ($("#txtRequestor").val() == "") 
        {
            $("#txtRequestor").focus();
           
        }
        else if($("#txtRequestorFor").val() == "")
        {
            $("#txtRequestorFor").focus();
           
        }
        else if ($("#txtFTE").val() == 0)
        {
            $("#txtFTE").focus();

        }
        else if ($("#txtFTEMPE").val() == 0) {
            $("#txtFTEMPE").focus();

        }
        else if ($("#txtFCurrentSpace").val() == "") {
            $("#txtFCurrentSpace").focus();

        }
        else if ($("#txtJobTitle").val() == "") {
            $("#txtJobTitle").focus();

        }
        else if ($("#txtPayBand").val() == "") {
            $("#txtPayBand").focus();

        }
        else if ($("#txtDescription").val() == "") {
            $("#txtDescription").focus();

        }
        

        if (foundempty) {
            
            return false
        }

        //Create a object and load user .
        //You will then pass this object to the controller below.
        var SpaceRequestObject =
        {
            SpaceRequestID: $("#txtSpaceRequestID").val(),
            RequestorName: $("#txtRequestor").val(),
            EmpName: $("#txtRequestorFor").val(),
            FTE: $("#txtFTE").val(),
            FTE_MPE: $("#txtFTEMPE").val(),
            CurrentSpace: $("#txtFCurrentSpace").val(),
            JobTitle: $("#txtJobTitle").val(),
            PayBand: $("#txtPayBand").val(),
            SpaceDescription: $("#txtDescription").val(),

        }

        if ($("#txtStopLoop").val() == 0) {


            //Call the controller/post action method and pass your object above using the Jquery Ajax method
            var URL = "SpaceRequest/SaveNewRequest";
            $.ajax({
                type: 'POST',
                async: false,
                url: URL,
                dataType: 'json',
                data: { SpaceRequest: SpaceRequestObject },
                success: function (Results)
                {
                    $("#txtStopLoop").val(1);
                    $("#txtRequestor").val(Results.Requestor);

                    if ($("#txtRequestor").val() == "") {
                        $('#txtRequestor').attr("readonly", false);
                        $('#txtRequestor').attr("disabled", false);
                    }

                    //Show user a message indicating that the request was saved successfully.
                    var $dialog = $('<div>Your request was submitted successfully.</div>')

                        .dialog
                        ({
                            title: 'SUCCESS!',
                            width: 320,
                            height: 200,
                            buttons:
                                [
                                    {
                                        text: "OK", click: function () {
                                            $dialog.dialog('close');
                                            // You can do anything else here that needs to be done.

                                            //Clear/reset the input fields for user to add another request if they need to.
                                            $('#txtSpaceRequestID').val(0)
                                            $("#txtRequestorFor").val("");
                                            $("#txtFTE").val("");
                                            $("#txtFTEMPE").val("");
                                            $("#txtFCurrentSpace").val("");
                                            $("#txtJobTitle").val("");
                                            $("#txtPayBand").val("");
                                            $("#txtDescription").val("");


                                        }
                                    }]
                        });

                    //$("#divSpaceRequestDetails").css("visibility", "visible");

                    //$("#divSpaceRequestDetails").load("SpaceRequest/EditRequest",
                    //    {

                    //    }, function () {

                    //        //Clear/reset the input fields for user to add another request if they need to.
                    //        $('#txtSpaceRequestID').val(0)
                    //        $("#txtRequestorFor").val("");
                    //        $("#txtFTE").val("");
                    //        $("#txtFTEMPE").val("");
                    //        $("#txtFCurrentSpace").val("");
                    //        $("#txtJobTitle").val("");
                    //        $("#txtPayBand").val("");
                    //        $("#txtDescription").val("");

                    //    });

                    //return;

                },
                error: function (args) {
                    var $dialog = $('<div>Error occured while saving space request information</div>')
                        .dialog
                        ({
                            title: 'ERROR!',
                            width: 300,
                            height: 200,
                            buttons:
                                [
                                    {
                                        text: "Close", click: function () {
                                            $dialog.dialog('close');
                                            // You can do anything else here that needs to be done.
                                        }
                                    }]
                        });

                }
            });
        }
    });
    //============================================================================================================================================    
    //This functions checks to make sure that FTE field value is a number/interger and not a string.

    $('#txtFTE').change(function () {
        if (isNaN($("#txtFTE").val())) {
            var $dialog = $("<div>Please enter a valid integer or a decimal number with 2 decimal places.</div>")
                .dialog
                ({
                    title: 'Invalid FTE value',
                    width: 300,
                    height: 240,
                    buttons:
                        [
                            {
                                text: "close", click: function () {
                                    $dialog.dialog('close');
                                    // You can do anything else here that needs to be done.
                                    $("#txtFTE").val(0)
                                }
                            }]
                });

        }
    });
    //============================================================================================================================================    
    //This functions checks to make sure that FTEMPE field value is a number/interger and not a string.
    $('#txtFTEMPE').change(function () {
        if (isNaN($("#txtFTEMPE").val())) {
            var $dialog = $("<div>Please enter a valid integer or a decimal number with 2 decimal places.</div>")
                .dialog
                ({
                    title: 'Invalid FTE-MPE value',
                    width: 300,
                    height: 240,
                    buttons:
                        [
                            {
                                text: "close", click: function () {
                                    $dialog.dialog('close');
                                    // You can do anything else here that needs to be done.
                                    $("#txtFTEMPE").val(0)
                                }
                            }]
                });

        }
    });

    //This code resets the input field color back to white from pink.
    //============================================================================================================================================   
    $("#txtRequestor").change(function () {
        $("#txtRequestor").css('background', 'white')
    });
    //============================================================================================================================================    
    $("#txtRequestorFor").change(function () {
        $("#txtRequestorFor").css('background', 'white')
    });
    //============================================================================================================================================    
    $("#txtFTE").change(function () {
        $("#txtFTE").css('background', 'white')
    });
    //============================================================================================================================================   
    $("#txtFTEMPE").change(function () {
        $("#txtFTEMPE").css('background', 'white')
    });
    //============================================================================================================================================    
    $("#txtFCurrentSpace").change(function () {
        $("#txtFCurrentSpace").css('background', 'white')
    });
    //============================================================================================================================================   
    $("#txtJobTitle").change(function () {
        $("#txtJobTitle").css('background', 'white')
    });
    //============================================================================================================================================
    $("#txtPayBand").change(function () {
        $("#txtPayBand").css('background', 'white')
    });
    //============================================================================================================================================
    $("#txtDescription").change(function () {
        $("#txtDescription").css('background', 'white')
    });
});

