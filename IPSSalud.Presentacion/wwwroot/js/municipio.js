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
            "url": "/Administrador/municipio/ObtenerTodos"
        },
        "columns": [
            { "data": "codigoDaneMunicipio", "width": "20%" },
            { "data": "nombreMunicipio", "width": "20%" },
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
                            <a href="/Administrador/Municipio/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                <i class="fas fa-edit"></i>
                            </a>    
                            <a onclick=Delete("/Administrador/Municipio/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                <i class="fas fa-trash"></i>
                            </a>
                        </div>
                        `;
                }, "width": "20%"
            }
        ]
    });
}
