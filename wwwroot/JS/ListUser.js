
async function loadUsers() {
    const tableBody = document.querySelector("#users-table tbody");
    const result = document.getElementById("result");

    tableBody.innerHTML = "";
    result.innerHTML = "";

    try {
        const response = await fetch("/api/user");

        if (!response.ok) {
            result.innerHTML = "<li class='error'>❌ Error al obtener los usuarios.</li>";
            return;
        }

        const users = await response.json();

        if (users.length === 0) {
            result.innerHTML = "<li class='info'>ℹ️ No hay usuarios registrados.</li>";
            return;
        }

        users.forEach(u => {
            const row = document.createElement("tr");

            row.innerHTML = `
                <td>${u.id}</td>
                <td>${u.nombre}</td>
                <td>${u.email}</td>
                <td>${u.edad}</td>
            `;

            tableBody.appendChild(row);
        });

    } catch (error) {
        result.innerHTML = "<li class='error'>❌ Error de conexión con la API.</li>";
        console.error(error);
    }
}