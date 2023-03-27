$('#subAddAssetDiv').hide();
$(document).ready(function () {
    $('#addAssetContainerBtn').click(function () {
        if ($('#subAddAssetDiv').is(':hidden')) {
            $('#subAddAssetDiv').show('fast');
        } else {
            $('#subAddAssetDiv').hide('fast');
        }
        $(this).text($(this).text() == 'Show Add New Asset Tool' ? 'Hide Add New Asset Tool' : 'Show Add New Asset Tool');
    });
    SetDataTable();
});

function SetDataTable() {
    $('#currAssets').DataTable({
        ajax: {
            url: '/Assets/GetAllAssets',
            type: 'GET',
            datatype: 'json',
            dataSrc: ''
        },
        columns: [
            { title: "Category", data: "category" },
            { title: "Brand", data: "brand" },
            { title: "Model", data: "model" },
            { title: "Serial No.", data: "serialNumber" },
            {
                title: "Currently Serviced?", data: "beingServiced", render: function (data, type, row) {
                    return (!data) ? `<a href='#' class='text-primary fw-bolder'>No</a>` : 'Yes';

                }
            },
            { title: "Notes", data: "notes" },
            {
                title: "Image", data: "imgPath", render: function (data, type, row) {
                    if (!data) {
                        return `<button type="button">Upload image</button>`;
                    }
                }
            },
            { title: "Date Added", data: "dateAddedToInventory" },
            {
                title: "Edit/Del Asset", data: null, render: function (data, type, row) {
                    ActivateModal();
                    return `<a type="button" class="btn btn-warning editAssetRow"><i class="bi bi-pencil-square"></i></a>
                    <a type="button" class="btn btn-danger delAssetRow"><i class="bi bi-trash3"></i></a>`;
                }
            }
        ]
    });
}

function ActivateModal() {
    $('.editAssetRow').on("click", function () {
        $('#editAssetModal').modal('show');
    })
}