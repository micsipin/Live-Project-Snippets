//produces disabled textbox when value of textbox is "No Template"

 function changeShiftTemplate() {
        var e = document.getElementById("dropdownshift").value;
        if (e = document.getElementById("dropdownshift").value == "No Template") {
            document.getElementById("scheduletextbox").disabled = "disabled"
        }
        else if (e = "No Template") {
            document.getElementById("scheduletextbox").disabled = ""

        }
    }