document.addEventListener('DOMContentLoaded', () => {
  const form = document.querySelector('form');
  const dniInput = document.getElementById('dniCliente');
  const tbody = document.querySelector('tbody');

  form.addEventListener('submit', async e => {
    e.preventDefault();

    const dni = dniInput.value.trim();
    if (!dni) return;

    try {
      const res = await fetch(`http://localhost:5115/api/envios/dni/${dni}`);
      const data = await res.json();

      tbody.innerHTML = data.map((e, i) => `
        <tr>
          <td>${i + 1}</td>
          <td>${new Date(e.fecha).toLocaleDateString()}</td>
          <td>${e.dniCliente}</td>
          <td>${e.direccion}</td>
          <td>${e.estado}</td>
        </tr>
      `).join('');

    } catch {
      tbody.innerHTML = '<tr><td colspan="5">Error, el DNI ingresado es invalido o no existe.</td></tr>';
    }
  });
});
