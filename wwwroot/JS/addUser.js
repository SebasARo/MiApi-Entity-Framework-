
async function createUser() {
    const nombre = document.getElementById("nombre").value.trim();
    const email = document.getElementById("email").value.trim();
    const edad = document.getElementById("edad").value.trim();
    const result = document.getElementById("result");
    result.innerHTML = "";

    if (!nombre || !email || !edad) {
        result.innerHTML = "<li class='error'>⚠️ Todos los campos son obligatorios.</li>";
        return;
    }

    try {
        const response = await fetch("/api/user", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ nombre, email, edad: Number(edad) })
        });

        if (!response.ok) {
            result.innerHTML = "<li class='error'>❌ Error al crear el usuario.</li>";
            return;
        }

        const user = await response.json();
        result.innerHTML = `<li class='info'>✔ Usuario creado con ID: ${user.id}</li>`;

    } catch (error) {
        result.innerHTML = "<li class='error'>❌ Error de conexión.</li>";
        console.error(error);
    }
}

async function updateUser() {
    const id = Number(document.getElementById("userId").value.trim());
    const nombre = document.getElementById("nombre").value.trim();
    const email = document.getElementById("email").value.trim();
    const edad = Number(document.getElementById("edad").value.trim());
    const result = document.getElementById("result");

    result.innerHTML = "";

    if (!id) {
        result.innerHTML = "<li class='error'>⚠️ Debes ingresar el ID del usuario.</li>";
        return;
    }

    try {
        const response = await fetch(`/api/user/${id}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ nombre, email, edad })
        });

        if (!response.ok) {
            result.innerHTML = "<li class='error'>❌ No se pudo actualizar el usuario.</li>";
            return;
        }

        result.innerHTML = `<li class='info'>✔ Usuario actualizado correctamente.</li>`;
    } catch {
        result.innerHTML = "<li class='error'>❌ Error de conexión.</li>";
    }
}

async function deleteUser() {
    const id = Number(document.getElementById("userId").value.trim());
    const result = document.getElementById("result");

    result.innerHTML = "";

    if (!id) {
        result.innerHTML = "<li class='error'>⚠️ Debes ingresar el ID del usuario.</li>";
        return;
    }

    try {
        const response = await fetch(`/api/user/${id}`, {
            method: "DELETE"
        });

        if (!response.ok) {
            result.innerHTML = "<li class='error'>❌ No se pudo eliminar el usuario.</li>";
            return;
        }

        result.innerHTML = `<li class='info'>✔ Usuario eliminado correctamente.</li>`;
    } catch {
        result.innerHTML = "<li class='error'>❌ Error de conexión.</li>";
    }
}