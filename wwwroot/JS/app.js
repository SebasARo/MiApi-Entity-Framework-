
async function loadProducts() {
    const userId = document.getElementById("userId").value.trim();
    const list = document.getElementById("product-list");
    list.innerHTML = "";

    // Validación básica
    if (!userId || userId <= 0) {
        list.innerHTML = "<li>⚠️ Ingresa un ID válido.</li>";
        return;
    }

    try {
        // Llamada a la API
        const response = await fetch(`/api/user/${userId}/products`);

        // Si el usuario no existe
        if (response.status === 404) {
            list.innerHTML = `<li>❌ No existe un usuario con el ID ${userId}.</li>`;
            return;
        }

        // Si la API falla
        if (!response.ok) {
            list.innerHTML = "<li>❌ Error al obtener los productos.</li>";
            return;
        }

        const products = await response.json();

        // Si el usuario no tiene productos
        if (products.length === 0) {
            list.innerHTML = "<li>ℹ️ Este usuario no tiene productos registrados.</li>";
            return;
        }

        // Mostrar productos
        products.forEach(p => {
            const item = document.createElement("li");
            item.textContent = `${p.nombre} — $${p.precio} (Stock: ${p.stock})`;
            list.appendChild(item);
        });

    } catch (error) {
        list.innerHTML = "<li>❌ Error de conexión con la API.</li>";
        console.error(error);
    }
}

