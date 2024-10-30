let turnos = [];
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

function cargarTurnosPorCliente() {
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


async function cargarTurnos() {
    try {
        // Hacer la solicitud a la API para obtener los datos de turnos
        const response = await fetch('https://localhost:7025/api/Turnos');
        const data = await response.json();

        // Seleccionar la tabla donde se mostrarán los turnos
        const tabla = document.getElementById("consultar").querySelector("table");

        // Limpiar el contenido de la tabla antes de agregar los nuevos datos
        tabla.innerHTML = "";

        // Recorrer cada turno en los datos obtenidos
        data.forEach(turno => {
            const row = tabla.insertRow();
            row.innerHTML = ` 
                    <td>${turno.fecha}</td>
                    <td>${turno.hora}</td>
                    <td>${turno.cliente}</td>
                `;
        });

        turnos = data;

        console.log("Turnos cargados correctamente:", data);
    } catch (error) {
        console.error('Error obteniendo datos:', error);
    }
}


async function registrarTurno(event) { 
    event.preventDefault();

    const id = 0;
    const fecha = document.getElementById("fecha").value;
    const hora = document.getElementById("hora").value;
    const cliente = document.getElementById("cliente").value;

    // Validación de datos completos
    if (!fecha || !hora || !cliente) {
        alert("Por favor, complete todos los campos.");
        return;
    }

    // Crear objeto con los datos del turno
    const nuevoTurno = { id, fecha, hora, cliente };

    try {
        // Enviar el nuevo turno a la API
        const response = await fetch('https://localhost:7025/api/Turnos', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(nuevoTurno)
        });

        if (response.ok) {
            // Limpiar formulario y notificar al usuario
            document.getElementById("formTurno").reset();
            alert("Turno registrado exitosamente en la API.");
        } else {
            alert("Error al registrar el turno.");
        }
    } catch (error) {
        console.error('Error al conectar con la API:', error);
        alert("No se pudo registrar el turno.");
    } 
}