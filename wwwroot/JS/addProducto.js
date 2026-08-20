
async function createProduct() {
    const nombre = document.getElementById("nombre").value.trim();
    const precio = document.getElementById("precio").value.trim();
    const precioDecimal = parseFloat(precio.replace(/\./g, '').replace(',', '.'));
    const stock = document.getElementById("stock").value.trim();
    const userId = document.getElementById("userId").value.trim();
    const result = document.getElementById("result");
    result.innerHTML = "";

    if (!nombre || isNaN(precioDecimal) || !stock || !userId) {
        result.innerHTML = "<li class='error'>⚠️ Todos los campos son obligatorios y el precio debe ser válido.</li>";
        return;
    }

    try {
        const response = await fetch("/api/product", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({
                nombre,
                precio: precioDecimal,
                stock: Number(stock),
                userId: Number(userId)
            })
        });

        if (!response.ok) {
            result.innerHTML = "<li class='error'>❌ Error al crear el producto.</li>";
            return;
        }

        const product = await response.json();
        result.innerHTML = `<li class='info'>✔ Producto creado con ID: ${product.id}</li>`;

    } catch (error) {
        result.innerHTML = "<li class='error'>❌ Error de conexión.</li>";
        console.error(error);
    }
}


async function updateProduct() {
    const id = Number(document.getElementById("productId").value.trim());
    const nombre = document.getElementById("nombre").value.trim();
    const precio = document.getElementById("precio").value.trim();
    const precioDecimal = parseFloat(precio.replace('.', '').replace(',', '.'));
    const stock = Number(document.getElementById("stock").value.trim());
    const userId = Number(document.getElementById("userId").value.trim());
    const result = document.getElementById("result");

    result.innerHTML = "";

    if (!id) {
        result.innerHTML = "<li class='error'>⚠️ Debes ingresar el ID del producto.</li>";
        return;
    }

    try {
        const response = await fetch(`/api/product/${id}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ nombre, precio: precioDecimal, stock: Number(stock), userId: Number(userId) })
        });

        if (!response.ok) {
            result.innerHTML = "<li class='error'>❌ No se pudo actualizar el producto.</li>";
            return;
        }

        result.innerHTML = `<li class='info'>✔ Producto actualizado correctamente.</li>`;
    } catch {
        result.innerHTML = "<li class='error'>❌ Error de conexión.</li>";
    }
}


async function deleteProduct() {
    const id = Number(document.getElementById("productId").value.trim());
    const result = document.getElementById("result");

    result.innerHTML = "";

    if (!id) {
        result.innerHTML = "<li class='error'>⚠️ Debes ingresar el ID del producto.</li>";
        return;
    }

    try {
        const response = await fetch(`/api/product/${id}`, {
            method: "DELETE"
        });

        if (!response.ok) {
            result.innerHTML = "<li class='error'>❌ No se pudo eliminar el producto.</li>";
            return;
        }

        result.innerHTML = `<li class='info'>✔ Producto eliminado correctamente.</li>`;
    } catch {
        result.innerHTML = "<li class='error'>❌ Error de conexión.</li>";
    }
}