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
            "url": "/Administrador/usuario/ObtenerTodos"
        },
        "columns": [
            { "data": "userName", "width": "10%" },
            { "data": "nombres", "width": "10%" },
            { "data": "apellidos", "width": "10%" },
            { "data": "email", "width": "15%" },
            { "data": "phoneNumber", "width": "10%" },
            { "data": "role", "width": "15%" },
            
            {
                "data": {
                    id: "id", lockutEnd: "lockoutEnd"
                },
                "render": function (data) {
                    var hoy = new Date().getTime();
                    var bloqueo = new Date(data.lockoutEnd).getTime();
                    if (bloqueo > hoy) {
                        return `
                        <div class="text-center">
                            <a onclick=BloquearDesbloquear('${data.id}') class="btn btn-danger text-white" style="cursor:pointer; width:150px">
                                <i class="fas fa-lock-open"></i>Desbloquear
                            </a>
                        </div>
                        `;
                    }
                    else {
                        return `
                        <div class="text-center">
                            <a onclick=BloquearDesbloquear('${data.id}') class="btn btn-success text-white" style="cursor:pointer; width:150px">
                                <i class="fas fa-lock"></i>Bloquear
                            </a>
                        </div>
                        `;

                    }
                    
                }, "width": "30%"
            }
        ]
    });
}


function BloquearDesbloquear(id) {

            $.ajax({
                type: "POST",
                url: '/Administrador/Usuario/BloquearDesbloquear',
                data: JSON.stringify(id),
                contentType: "application/json",
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        datatable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
}