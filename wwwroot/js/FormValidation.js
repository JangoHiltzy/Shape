// EVENT LISTENER FOR FORM SUBMISSION
document.getElementById('fitnessForm').addEventListener('submit', function (event) {
    // VALIDATE THE FORM BEFORE SUBMISSION
    if (!validateForm()) {
        // PREVENT THE DEFAULT FORM SUBMISSION IF VALIDATION FAILS
        event.preventDefault();
    }
});

// FUNCTION TO VALIDATE THE FORM BEFORE SUBMISSION
function validateForm() {
    // GET THE SELECTED UNIT SYSTEM AND GENDER
    var unitSelection = document.getElementById("unitSelection").value;
    var gender = document.getElementById("gender").value;

    // CALL THE RESPECTIVE VALIDATION FUNCTION BASED ON THE SELECTED UNIT SYSTEM AND GENDER
    if (unitSelection === "Metric") {
        return validateMetric(gender);
    } else {
        return validateImperial(gender);
    }
}

// FUNCTION TO VALIDATE METRIC FIELDS
function validateMetric(gender) {
    // GET VALUES OF METRIC INPUT FIELDS
    var heightCm = document.getElementById("heightCm").value;
    var weightKg = document.getElementById("weightKg").value;
    var waistCm = document.getElementById("waistCm").value;
    var neckCm = document.getElementById("neckCm").value;
    var hipCm = document.getElementById("hipCm").value;

    // CHECK IF ANY REQUIRED METRIC FIELD IS EMPTY
    if (heightCm === "" || weightKg === "" || waistCm === "" || neckCm === "") {
        showNotification("Please fill in all required fields.");
        return false; // PREVENT FORM SUBMISSION
    }

    // IF FEMALE, CHECK IF HIP MEASUREMENT IS EMPTY
    if (gender === "Female" && hipCm === "") {
        showNotification("Please fill in all required fields.");
        return false; // PREVENT FORM SUBMISSION
    }

    // IF ALL METRIC FIELDS ARE FILLED, ALLOW FORM SUBMISSION
    return true;
}

// FUNCTION TO VALIDATE IMPERIAL FIELDS
function validateImperial(gender) {
    // GET VALUES OF IMPERIAL INPUT FIELDS
    var heightFt = document.querySelector('input[name="HeightFt"]').value;
    var heightIn = document.querySelector('input[name="HeightIn"]').value;
    var weightLb = document.querySelector('input[name="WeightLb"]').value;
    var neckFt = document.querySelector('input[name="NeckFt"]').value;
    var neckIn = document.querySelector('input[name="NeckIn"]').value;
    var waistFt = document.querySelector('input[name="WaistFt"]').value;
    var waistIn = document.querySelector('input[name="WaistIn"]').value;
    var hipFt = document.querySelector('input[name="HipFt"]').value;
    var hipIn = document.querySelector('input[name="HipIn"]').value;

    // CHECK IF ANY REQUIRED IMPERIAL FIELD IS EMPTY
    if (heightFt === "" || heightIn === "" || weightLb === "" || neckFt === "" || neckIn === "" || waistFt === "" || waistIn === "" || (gender === "Female" && (hipFt === "" || hipIn === ""))) {
        showNotification("Please fill in all required fields.");
        return false; // PREVENT FORM SUBMISSION
    }

    // IF ALL IMPERIAL FIELDS ARE FILLED, ALLOW FORM SUBMISSION
    return true;
}
