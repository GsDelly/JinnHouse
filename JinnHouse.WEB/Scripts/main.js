(function () {

    function isDeviceExists() {
        return $.ajax({
            type: "POST",
            data: { "deviceName": $("#deviceName").val() },
            url: "/" + $("#controllerName").val() + "/IsExists",
            async: false
        }).responseText;
    }

    function submitDevice(name) {
        $.ajax({
            type: "POST",
            data: {
                "deviceName": name,
                "actionName": $("#actionName").val(),
                "controllerName": $("#controllerName").val()
            },
            url: "/" + $("#controllerName").val()+"/AddDevice",
            async : false
        });
        location.reload();
    }

    $(".addButton").click(function () {
        var custom = new Custom();
        custom.prompt("Please input device name", function () {
            var name = $("#prompt_value").val();
            if (name) {
                $("#deviceName").val(name);
                var result = isDeviceExists();
                if (result === "True") {
                    $(".error-message").removeClass("hidden");
                } else {
                    submitDevice(name);
                }
            }
        });
    });
})();