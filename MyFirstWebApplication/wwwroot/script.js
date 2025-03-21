async function addNumbersWithAPI() {
    // Eingabewerte holen
    const number1 = parseInt(document.getElementById("number1").value);
    const number2 = parseInt(document.getElementById("number2").value);

    // Prüfen, ob Eingaben gültig sind
    if (isNaN(number1) || isNaN(number2)) {
        document.getElementById("result").innerText = "Bitte gültige Zahlen eingeben!";
        return;
    }

    // Daten für die API vorbereiten
    const data = {
        Number1: number1,
        Number2: number2
    };

    try {
        // API-Anfrage mit fetch
        const response = await fetch("https://localhost:7018/Math/add", {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(data)
        });

        if (!response.ok) {
            throw new Error("Fehler bei der API-Anfrage");
        }

        const result = await response.json();
        document.getElementById("result").innerText = result;
    } catch (error) {
        document.getElementById("result").innerText = "Fehler: " + error.message;
    }
}