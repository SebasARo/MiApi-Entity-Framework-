
async function loadProducts() {
    const tableBody = document.querySelector("#products-table tbody");
    const result = document.getElementById("result");

    tableBody.innerHTML = "";
    result.innerHTML = "";

    try {
        const response = await fetch("/api/product");

        if (!response.ok) {
            result.innerHTML = "<li class='error'>❌ Error al obtener los productos.</li>";
            return;
        }

        const products = await response.json();

        if (products.length === 0) {
            result.innerHTML = "<li class='info'>ℹ️ No hay productos registrados.</li>";
            return;
        }

        products.forEach(p => {
            const row = document.createElement("tr");

            row.innerHTML = `
                <td>${p.id}</td>
                <td>${p.nombre}</td>
                <td>${p.precio}</td>
                <td>${p.stock}</td>
                <td>${p.userId}</td>
            `;

            tableBody.appendChild(row);
        });

    } catch (error) {
        result.innerHTML = "<li class='error'>❌ Error de conexión con la API.</li>";
        console.error(error);
    }
}