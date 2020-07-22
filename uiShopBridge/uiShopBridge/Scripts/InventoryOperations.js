$(document).ready(function () {
    getItems();
});

/* ShopBridge API URL is implementing in all the inventory operation functions. */
var apiURL = "http://localhost:2073/api/InventoryOperations/";

/* Function to insert items */
var fileValue = "";

function addItems() {
    debugger;
    var name = $("#txtName").val();
    var description = $("#txtDesc").val();
    var price = $("#txtPrice").val();
    var image = $("#fileImage").val();
    var filehash = "";
    if (fileValue.length > 0 && fileValue != "") {
        filehash = fileValue;
    }

    //var photo = document.getElementById("fileImage");
    //var file = photo.files[0];
    //filename = (file.name);
    //filesize = (file.size);..
    //var tdate = new Date();
    //var mark = tdate.getFullYear() +""+ (tdate.getMonth()+1) +""+ tdate.getDay() +""+ tdate.getHours() +""+ tdate.getMinutes() +""+ tdate.getSeconds() +""+ tdate.getMilliseconds();
    //alert(filename + mark);

    //var fr = new FileReader;
    // alert(fr.readAsDataURL(file));

    
    if (name == "" || name.length == 0) {
        alert("Required Field: Name");
        return;
    }
    if (price == "" || price.length == 0) {
        alert("Required Field: Price");
        return;
    }

    var data = {};
    data.Name = name;
    data.Description = description;
    data.Price = price;
    data.ImagePath = filehash;

    $.ajax({
        type: "POST",
        url: apiURL,
        data: JSON.stringify(data),
        contentType: "application/json;charset=utf-8",
        datatType: "json",
        success: function (data) {
            if (data == true) {
                alert("Item added successfully");
                $("#impPrev").attr('src', '');
                $('#fetch_results').find(':input').val('');
            }
            else {
                alert("Aborted: Data not saved");
            }
            getItems();
        },
        error: function (err) {
            alert("Error:" + err);
            console.log("Error:" + err + " in addItems() method");
        }
    })
}



/*
function addItems() {
    debugger;
    var name = $("#txtName").val();
    var description = $("#txtDesc").val();
    var price = $("#txtPrice").val();
    var image = $("#fileImage").prop('files')[0];

    //var photo = document.getElementById("fileImage");
    //const preview = document.getElementById('#impPrev2');
    //var file = photo.files[0];
    //filename = (file.name);
    //filesize = (file.size);
    //var tdate = new Date();
    //var mark = tdate.getFullYear() +""+ (tdate.getMonth()+1) +""+ tdate.getDay() +""+ tdate.getHours() +""+ tdate.getMinutes() +""+ tdate.getSeconds() +""+ tdate.getMilliseconds();
   // alert(filename + mark);
    // return false;

    if (name == "" || name.length == 0) {
        alert("Required Field: Name");
        return;
    }
    if (price == "" || price.length == 0) {
        alert("Required Field: Price");
        return;
    }

    //var data = {};
    //data.Name = name;
    //data.Description = description;
    //data.Price = price;
    //data.ImagePath = image;

    var data = new FormData();
    data.append('Name', name);
    data.append('Description', description);
    data.append('Price', price);
    data.append('ImagePath', image);
   
    $.ajax({
        type: "POST",
        url: "http://localhost:2073/api/InventoryOperations/",
        processData: false,
        contentType: false,
        data: (data),
        success: function (data) {
            if (data == true) {
                alert("Item added successfully");
                $('#fetch_results').find(':input').val('');
            }
            else {
                alert("Aborted");
            }
            getItems();
        },
        error: function (err) {
            alert("Error:" + err);
            console.log("Error:" + err + " in addItems() method");
        }
    })
} */


/* Function to get the list of items */
function getItems() {
    debugger;
    $.ajax({
        type: "GET",
        url: apiURL,
        contentType: "application/json;charset=utf-8",
        datatType: "json",
        success: function (data) {
            var body = $("#bdyItems");
            $("#bdyItems").empty();
            for (var i = 0; i < data.length; i++) {
                var sn = i;
                var sno = (++sn);
                var idImgThumbnail = "imgThumbnail" + sno;
                var html = "<tr>" +
                    "<td>" + (sno) + "</td>" +
                    //"<td>" + data[i].Name + "</td>" +
                    "<td>" + "<a href='#' onclick='getDetails(" + data[i].id + ")' >" + data[i].Name + " </a> " + "</td>" +
                    //"<td>" + data[i].Description + "</td>" +
                    "<td>" + data[i].Price + "</td>" +
                    "<td>" + "<img src='"+data[i].ImagePath+"' id='"+idImgThumbnail+"' alt='thumbnail'  height='100px' />" + "</td>" +
                    //"<td>" + "<a href='#' class='btn btn-warning' onclick='editItems(" + data[i].id + ")'>Edit</a> " + "<td" +
                    //"<td>" + "<a href='#' class='btn btn-danger' onclick='deleteItems(" + data[i].id + ")'>Delete</a> " + "</td>"+
                "<td>" + "<img src='/Assests/delete.png' style='width:30px;' alt='Delete' onclick='deleteItems(" + data[i].id + ")'  /> " + "</td>"
                "</tr>";
                body.append(html);
            }
        },

        error: function (err) {
            alert("Error:" + err);
            console.log("Error:" + err + " in getitems() method");
        }
    })
}

/* Function to delete Items from database */
function deleteItems(id) {
    debugger;
    if (confirm("Are you sure want to delete this record")) {
        $.ajax({
            type: "DELETE",
            url: apiURL + id,
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data == true) {
                    alert("Item deleted successfully");
                    getItems();
                }
                else {
                    alert("Item not deleted");
                }
            },
            error: function (err) {
                alert("Error" + err);
                console.log("Error:" + err + " in deleteItems method");
            }
        })
    }
}

/* Function to show image preview */
function ShowPreview(input) {
    debugger;
    if (input.files && input.files[0]) {
        var ImageDir = new FileReader();
        ImageDir.onload = function (e) {
            fileValue = e.target.result;
           // console.log(value);
            $('#impPrev').attr('src', e.target.result);   
        }
        ImageDir.readAsDataURL(input.files[0]);
    }
}
