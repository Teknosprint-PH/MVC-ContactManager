$(document).ready(function () {
    GetContacts();
});

function GetContacts() {
    $.ajax({
        url: '/home/GetContacts',
        type: 'get',
        datatype: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            if (response == null || response == undefined || response.length == 0) {                
                var object = '';
                object += '<tr>';
                object += '<td class="colspan="5">' + 'No contacts available in the database.' + '</td>';
                object += '</tr>';
                $('#tblBody').html(object);
            }
            else {
                var object = '';
                $.each(response, function (index, item) {
                    object += '<tr>';
                    object += '<td>' + item.contact_id + '</td>';
                    object += '<td>' + item.contact_lastname + '</td>';
                    object += '<td>' + item.contact_firstname + '</td>';
                    object += '<td>' + item.contact_middlename + '</td>'; 
                    object += '<td>' + item.location_lat + '</td>'; 
                    object += '<td>' + item.location_long + '</td>'; 
                    object += '<td> <a href="#" class="btn btn-primary btn-sm" onclick="EditContact(' + item.contact_id + ')">Edit</a> <a href="#" class="btn btn-danger btn-sm" onclick="DeleteContact(' + item.contact_id + ')">Delete</a></td>';
                });
                $('#tblBody').html(object);
            }
        },
        error: function () {
            alert('Unable to access database.');
        }
    });
}

$('#btnAdd').click(function () {
    $('#addcontactModal').modal('show');
    $('#createcontactModal').text('Create Contact'); 
});

function InsertContact() { 
    var result = Validate();
    if (result == false) {
        return false;
    }

    var currentDateTime = new Date();
    // Format the date and time as yyyy-MM-ddTHH:mm:ss
    var formattedDateTime = currentDateTime.getFullYear() + "-"
        + String(currentDateTime.getMonth() + 1).padStart(2, '0') + "-"
        + String(currentDateTime.getDate()).padStart(2, '0') + "T"
        + String(currentDateTime.getHours()).padStart(2, '0') + ":"
        + String(currentDateTime.getMinutes()).padStart(2, '0') + ":"
        + String(currentDateTime.getSeconds()).padStart(2, '0');

    var formData = new Object();   
    formData.contact_lastname = $('#contact_lastname').val();
    formData.contact_firstname = $('#contact_firstname').val();
    formData.contact_middlename = $('#contact_middlename').val();
    formData.contact_address = $('#contact_address').val();
    formData.contact_no = $('#contact_no').val();
    formData.location_lat = $('#location_lat').val();
    formData.location_long = $('#location_long').val();
    formData.contact_status = $('#contact_status').val();
    formData.created_by = $('#created_by').val();
    formData.created_dt = formattedDateTime;

    $.ajax({
        url: '/home/AddContact',
        data: formData,
        type: 'post',
        success: function (response) {
            if (response == null || response == undefined || response.length == 0) {
                alert('Cannot save the new contact.');
            }
            else {
                HideModal();
                GetContacts();
                alert(response);
            }
        },
        error: function () {
            alert('Unable to save the new contact.');
        }
    });
}

function HideModal() {
    ClearControls(); 
    $('#addcontactModal').modal('hide');    
}

function ClearControls() {
    $('#contact_lastname').val('');
    $('#contact_firstname').val('');
    $('#contact_middlename').val('');
    $('#contact_address').val('');
    $('#contact_no').val('');
    $('#location_lat').val('');
    $('#location_long').val('');
    $('#contact_status').val('');
    $('#created_by').val('');

    $('#contact_lastname').css('border-color', 'lightgrey');
    $('#contact_firstname').css('border-color', 'lightgrey');
    $('#contact_middlename').css('border-color', 'lightgrey');
    $('#contact_address').css('border-color', 'lightgrey');
    $('#contact_no').css('border-color', 'lightgrey');
    $('#location_lat').css('border-color', 'lightgrey');
    $('#location_long').css('border-color', 'lightgrey');
}

function Validate() {
    var isValid = true;

    if ($('#contact_lastname').val().trim() == "") {
        $('#contact_lastname').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#contact_lastname').css('border-color', 'lightgrey');
    }

    if ($('#contact_firstname').val().trim() == "") {
        $('#contact_firstname').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#contact_firstname').css('border-color', 'lightgrey');
    }

    if ($('#contact_middlename').val().trim() == "") {
        $('#contact_middlename').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#contact_middlename').css('border-color', 'lightgrey');
    }

    if ($('#contact_address').val().trim() == "") {
        $('#contact_address').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#contact_address').css('border-color', 'lightgrey');
    }

    if ($('#contact_no').val().trim() == "") {
        $('#contact_no').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#contact_no').css('border-color', 'lightgrey');
    }
    return isValid;

    if ($('#location_lat').val().trim() == "") {
        $('#location_lat').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#location_lat').css('border-color', 'lightgrey');
    }
    return isValid;

    if ($('#location_long').val().trim() == "") {
        $('#location_long').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#location_long').css('border-color', 'lightgrey');
    }
    return isValid;
}

$('#contact_lastname').change(function () {
    Validate();
})

$('#contact_firstname').change(function () {
    Validate();
})

$('#contact_middlename').change(function () {
    Validate();
})

$('#contact_address').change(function () {
    Validate();
})

$('#contact_no').change(function () {
    Validate();
})

$('#location_lat').change(function () {
    Validate();
})

$('#location_long').change(function () {
    Validate();
})

function EditContact(id) {
    $.ajax({
        url: '/home/ModifyContact?id=' + id,        
        type: 'get',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',        
        success: function (response) {
            if (response == null || response == undefined) {
                alert('Cannot update the contact record.');
            }
            else if (response.length == 0) {
                alert('Contact record not found.');
            }
            else {
                $('#addcontactModal').modal('show');
                $('#createcontactModal').text('Update Contact');
                $('#Save').css('display', 'none');
                $('#Update').css('display', 'block');
                $('#contact_id').val(response.contact_id);
                $('#contact_lastname').val(response.contact_lastname);
                $('#contact_firstname').val(response.contact_firstname);
                $('#contact_middlename').val(response.contact_middlename);
                $('#contact_address').val(response.contact_address);
                $('#contact_no').val(response.contact_no);
                $('#location_lat').val(response.location_lat);
                $('#location_long').val(response.location_long);
                $('#contact_status').val(response.contact_status);
                $('#created_by').val(response.created_by);
                $('#created_dt').val(response.created_dt);
            }
        },
        error: function () {
            alert('Unable to read contact record.');
        }
    });
}

function UpdateContact() {    
    var result = Validate();
    if (result == false) {
        return false;
    }

    var currentDateTime = new Date();
    var formattedDateTime = currentDateTime.getFullYear() + "-"
        + String(currentDateTime.getMonth() + 1).padStart(2, '0') + "-"
        + String(currentDateTime.getDate()).padStart(2, '0') + "T"
        + String(currentDateTime.getHours()).padStart(2, '0') + ":"
        + String(currentDateTime.getMinutes()).padStart(2, '0') + ":"
        + String(currentDateTime.getSeconds()).padStart(2, '0');

    var formData = new Object();
    formData.contact_id = $('#contact_id').val();
    formData.contact_lastname = $('#contact_lastname').val();
    formData.contact_firstname = $('#contact_firstname').val();
    formData.contact_middlename = $('#contact_middlename').val();
    formData.contact_address = $('#contact_address').val();
    formData.contact_no = $('#contact_no').val(); 
    formData.location_lat = $('#location_lat').val(); 
    formData.location_long = $('#location_long').val(); 
    formData.contact_status = $('#contact_status').val();    
    formData.created_by = $('#created_by').val();  
    formData.created_dt = $('#created_dt').val();    
    formData.updated_by = "user";
    formData.updated_dt = formattedDateTime;

    $.ajax({
        url: '/home/UpdateContact',
        data: formData,
        type: 'post',
        success: function (response) {
            if (response == null || response == undefined || response.length == 0) {
                alert('Cannot update the contact record.');
            }
            else {
                HideModal();
                GetContacts();
                alert(response);
            }
        },
        error: function () {
            alert('Unable to update the contact record.');
        }
    });
}
function DeleteContact(id) {
    $.ajax({
        url: '/home/DeleteContact?id=' + id,       
        type: 'post',
        success: function (response) {
            if (response == null || response == undefined) {
                alert('Cannot delete the contact record.');
            }
            else if (response.length == 0) {
                alert('Contact record not found.');
            }
            else {
                //HideModal();
                GetContacts();
                alert(response);
            }
        },
        error: function () {
            alert('Unable to delete the contact record.');
        }
    });
}