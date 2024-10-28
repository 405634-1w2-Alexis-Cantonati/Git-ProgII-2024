let turnos = [
    { id: 1, fecha: "10/4/2020", hora: "10:00", cliente: "Michael" },
    { id: 2, fecha: "1/7/2021", hora: "13:00", cliente: "Kevin" },
    { id: 3, fecha: "11/1/2022", hora: "15:00", cliente: "Michael" },
    { id: 4, fecha: "3/3/2023", hora: "16:00", cliente: "Kevin" },
    { id: 5, fecha: "4/2/2024", hora: "19:00", cliente: "Michael" },
    { id: 6, fecha: "1/2/2024", hora: "21:00", cliente: "Juan" }
]
showSection("dashboard")
function showSection(sectionId) {
     // Oculta todas las secciones
     document.querySelectorAll("section").forEach(section => {
        section.style.display = "none";
    });

    // Muestra la sección seleccionada
    const selectedSection = document.getElementById(sectionId);
    if (selectedSection) {
        selectedSection.style.display = "block";
    }
    ;
    if (sectionId === "dashboard") {
        cargarTurnosPorCliente();
    } else if (sectionId === "consultar") {
        cargarTurnos();
    }
}

function cargarTurnosPorCliente(){
    const conteo = turnos.reduce((acc, turno) => {
        acc[turno.cliente] = (acc[turno.cliente] || 0) + 1;
        return acc;
    }, {});

    const tabla = document.getElementById("dashboard").querySelector("tbody");
    tabla.innerHTML = "";

    for(const cliente in conteo){
        const row = tabla.insertRow();
        row.innerHTML = `
            <td>${cliente}</td>
            <td>${conteo[cliente]}</td>
        `;
    }

}

function cargarTurnos(){
    const tabla = document.getElementById("consultar").querySelector("table");
    tabla.innerHTML = "";
    turnos.forEach(turno => {
        const row = tabla.insertRow();
        row.innerHTML = `
            <td>${turno.id}</td>
            <td>${turno.fecha}</td>
            <td>${turno.hora}</td>
            <td>${turno.cliente}</td>
        `;});
}

function registrarTurno(event) {
    event.preventDefault();

    const id = document.getElementById("id").value;
    const fecha = document.getElementById("fecha").value;
    const hora = document.getElementById("hora").value;
    const cliente = document.getElementById("cliente").value;

    // Validación de datos completos
    if (!id || !fecha || !hora || !cliente) {
        alert("Por favor, complete todos los campos.");
        return;
    }

    // Agregar el nuevo turno al arreglo
    turnos.push({ id, fecha, hora, cliente });

    // Limpiar formulario
    document.getElementById("formTurno").reset();
    alert("Turno registrado exitosamente.");
}