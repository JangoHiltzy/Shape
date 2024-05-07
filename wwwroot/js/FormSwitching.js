// EVENT LISTENERS FOR UNIT SELECTION AND GENDER
document.getElementById('unitSelection').addEventListener('change', toggleUnitFields);
document.getElementById('gender').addEventListener('change', toggleUnitFields);

// FUNCTION TO TOGGLE BETWEEN METRIC AND IMPERIAL FIELDS
function toggleUnitFields() {
    var unit = document.getElementById('unitSelection').value;
    var gender = document.getElementById('gender').value;

    // TOGGLE METRIC OR IMPERIAL FIELDS BASED ON UNIT SELECTION
    if (unit === 'Metric') {
        document.getElementById('metricFields').style.display = 'block';
        document.getElementById('imperialFields').style.display = 'none';
    } else {
        document.getElementById('metricFields').style.display = 'none';
        document.getElementById('imperialFields').style.display = 'block';
    }

    // TOGGLE FEMALE HIP FIELDS BASED ON GENDER AND UNIT SELECTION
    if (gender === 'Female') {
        if (unit === 'Metric') {
            document.getElementById('hipFieldsFemaleMetric').style.display = 'block';
            document.getElementById('hipFieldsFemaleImperial').style.display = 'none';
        } else {
            document.getElementById('hipFieldsFemaleMetric').style.display = 'none';
            document.getElementById('hipFieldsFemaleImperial').style.display = 'block';
        }
    } else {
        document.getElementById('hipFieldsFemaleMetric').style.display = 'none';
        document.getElementById('hipFieldsFemaleImperial').style.display = 'none';
    }
}
