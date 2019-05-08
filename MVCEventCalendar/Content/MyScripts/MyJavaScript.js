

function ValidateRegistration() {
    var employeeNumber = document.getElementById("EmployeeNumber").value;
    var employeeName = document.getElementById("EmployeeName").value;
    var contactNumber = document.getElementById("ContactNumber").value;
    var username = document.getElementById("NewUsername").value;
    var pass = document.getElementById("Pass").value;
    var conPass = document.getElementById("ConfirmPass").value;
    var answer = document.getElementById("Answer").value;

    var mob_pattr = /^[6-9]\d{9}$/;
    var pass_pattern = /^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[#$%^&+=@])(?=\S+$).{8,}$/;



    if (employeeNumber == "") {
        document.getElementById("employeeNumber_error").innerHTML = "*Employee Number is required";
        return false;
    }
    if (employeeNumber != "") {
        document.getElementById("employeeNumber_error").innerHTML = "";

    }
    if (employeeName == "") {
        document.getElementById("employeeName_error").innerHTML = "*Employee Name is required";
        return false;
    }
    if (employeeName != "") {
        document.getElementById("employeeName_error").innerHTML = "";

    }
    if (contactNumber == "") {
        document.getElementById("contactNumber_error").innerHTML = "*Contact Number is required";
        return false;
    }
    if (contactNumber != "") {
        document.getElementById("contactNumber_error").innerHTML = "";

    }
    if (username == "") {
        document.getElementById("username_error").innerHTML = "*Username is required";
        return false;
    }
    if (username != "") {
        document.getElementById("username_error").innerHTML = "";

    }
    if (pass == "") {
        document.getElementById("password_error").innerHTML = "*Password is required";
        return false;
    }
    if (pass != "") {
        document.getElementById("password_error").innerHTML = "";

    }
    if (conPass == "") {
        document.getElementById("ConfirmPass_error").innerHTML = "*Confirm Password is required";
        return false;
    }
    if (conPass != "") {
        document.getElementById("ConfirmPass_error").innerHTML = "";

    }
    if (answer == "") {
        document.getElementById("Answer_error").innerHTML = "*Answer is required";
        return false;
    }
    if (answer != "") {
        document.getElementById("Answer_error").innerHTML = "";

    }
    if (!mob_pattr.test(contactNumber)) {
        document.getElementById("contactNumber_error").innerHTML = "*Contact Number should be proper";
        return false;
    }
    if (!pass_pattern.test(pass)) {
        document.getElementById("password_error").innerHTML = "*Password must contains 8 characters";
        return false;
    }
    if (pass != conPass) {
        document.getElementById("ConfirmPass_error").innerHTML = "*Must be same as Password";
        return false;
    }
    if (!NaN(employeeName)) {
        document.getElementById("name_error").innerHTML = "*Name should have character only";
        return false;
    }
    else {
        return true;
    }

}

//Script For Login
function ValidateLogin() {
    var uname = document.getElementById("Username").value;
    var pass = document.getElementById("Password").value;



    if (uname == "") {
        document.getElementById("username_error").innerHTML = "*This field is required";
        return false;
    }
    if (uname != "") {
        document.getElementById("username_error").innerHTML = "";

    }
    if (pass == "") {
        document.getElementById("password_error").innerHTML = "*This field is required";
        return false;
    }
    if (pass != "") {
        document.getElementById("password_error").innerHTML = "";

    }
    else {
        return true;
    }

}


//forgot Pass

function ValidateForgotPass() {
    var EmployeeId = document.getElementById("EmployeeId").value;



    if (EmployeeId == "") {
        document.getElementById("employeeId_error").innerHTML = "*This field is required";
        return false;
    }
    if (Password != "") {
        document.getElementById("employeeId_error").innerHTML = "";
    }
    else {
        return true;
    }
}
function ValidateAnswer() {
    var answer = document.getElementById("answer").value;
    if (answer == "") {
        document.getElementById("answer_error").innerHTML = "*This field is required";
        return false;
    }
    if (answer != "") {
        document.getElementById("answer_error").innerHTML = "";
    }
    else {
        return true;
    }
}



function ValidateForgotPass() {
    var pass = document.getElementById("newPass").value;
    var conPass = document.getElementById("retypedPass").value;

    var pass_pattern = /^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[#$%^&+=@])(?=\S+$).{8,}$/;

    if (pass == "") {
        document.getElementById("newPass_error").innerHTML = "*Password is required";
        return false;
    }
    if (pass != "") {
        document.getElementById("newPass_error").innerHTML = "";

    }
    if (conPass == "") {
        document.getElementById("retypedPass_error").innerHTML = "*Re-Typed is required";
        return false;
    }
    if (conPass != "") {
        document.getElementById("retypedPass_error").innerHTML = "";
    }
    if (!pass_pattern.test(pass)) {
        document.getElementById("newPass_error").innerHTML = "*Password should be proper";
        return false;
    }
    if (pass != conPass) {
        document.getElementById("retypedPass_error").innerHTML = "*Must be same as Password";
        return false;
    }
    else {
        return true;
    }
}