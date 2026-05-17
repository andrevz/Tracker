export function addStopMarker(latitude, longitude, name) {
    L.marker([latitude, longitude])
        .addTo(window.map)
        .bindPopup(name);
}

export function initLeafletMap() {
    window.map = L.map('map').setView([-17.370791, -66.18359], 14);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; OpenStreetMap contributors'
    }).addTo(window.map);
}
