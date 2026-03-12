let currentController = null;

const converterForm = document.getElementById('converterForm');

converterForm.addEventListener('submit', function (event) {
    event.preventDefault();
    sendData();
});

converterForm.addEventListener('reset', function () {
    if (currentController) currentController.abort();
    document.getElementById('resultLabel').innerText = 'Result: -';
});

async function sendData() {
    if (currentController) currentController.abort();
    currentController = new AbortController();

    const inputElement = document.getElementById('inputValue');
    const numericValue = parseFloat(inputElement.value);

    if (isNaN(numericValue)) {
        alert("Please enter a valid number");
        return;
    }

    const requestData = {
        value: numericValue,
        fromUnit: document.getElementById('unitFrom').value,
        toUnit: document.getElementById('unitTo').value,
        type: document.getElementById('conversionType').value
    };

    const resultLabel = document.getElementById('resultLabel');

    try {
        resultLabel.innerText = 'Calculating...';

        const response = await axios.post('/api/converter/convert', requestData, {
            signal: currentController.signal
        });

        const { result, unit } = response.data;
        const formattedResult = Number(result).toLocaleString('ru-RU', {
            maximumFractionDigits: 6
        });

        resultLabel.innerText = `Result: ${formattedResult} ${unit}`;

    } catch (err) {
        if (axios.isCancel(err)) {
            console.log('Request canceled');
        } else {
            console.error('Connection error:', err);
            resultLabel.innerText = 'Result: Error';

            const errorMsg = err.response?.data?.error || err.message;
            alert(`Error: ${errorMsg}`);
        }
    } finally {
        currentController = null;
    }
}