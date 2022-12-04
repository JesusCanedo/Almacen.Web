function eliminar(id) {
    if (confirm("¿Está seguro que desea elminar el registro?")) {
 var url = "Producto/Eliminar/" + id;
        window.location.href = url;

    }
}
