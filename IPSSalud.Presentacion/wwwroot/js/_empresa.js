var datatable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    datatable = $('#tblDatos').DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json"
        },
        "ajax": {
            "url": "/Administrador/empresa/ObtenerTodos"
        },
        "columns": [
            { "data": "nitEmpresa", "width": "20%" },
            { "data": "nombreEmpresa", "width": "20%" },
            { "data": "direccion", "width": "20%" },
            { "data": "telefono", "width": "20%" },
            { "data": "municipio.nombreMunicipio", "width": "20%" },
            {
                "data": "logoUrl", "width": "20%",
                "render": function (data) {
                    return `<img src="${data}" height="50px" width="50px">`
                }, "width":"10%"
            },
            {
                "data": "estado",
                "render": function (data) {
                    if (data == true) {
                        return "Activo";
                    }
                    else {
                        return "Inactivo";
                    }
                }, "width": "20%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/Administrador/empresa/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                <i class="fas fa-edit"></i>
                            </a>    
                            <a onclick=Delete("/Administrador/empresa/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                <i class="fas fa-trash"></i>
                            </a>
                        </div>
                        `;
                }, "width": "20%"
            }
        ]
    });
}
