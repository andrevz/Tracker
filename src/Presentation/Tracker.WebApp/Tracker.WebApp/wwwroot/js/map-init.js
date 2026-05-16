export function initLeafletMap() {
    const map = L.map('map').setView([-17.370791, -66.18359], 14);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; OpenStreetMap contributors'
    }).addTo(map);
}
