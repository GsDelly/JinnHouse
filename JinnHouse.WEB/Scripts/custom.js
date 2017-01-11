function Custom() {

    var render = function(headText) {
        var winWidth = window.innerWidth;
        var winHeight = window.innerHeight;
        var $dialogOverlay = $("#dialog-overlay");
        var $dialogContainer = $("#dialog-container");
        $dialogOverlay.show();
        $dialogOverlay.height(winHeight);
        var containerLeft = (winWidth / 2) - (550 * 0.5);
        $dialogContainer.offset({top: 150, left: containerLeft});
        $dialogContainer.show();
        $("#dialog-head").html(headText);
        $("#prompt_value").val("");
    };

    var cancel = function() {
        $("#dialog-container").removeAttr("style").hide();
        $("#dialog-overlay").removeAttr("style").hide();
    };

    var ok = function(execFunc) {
        if(typeof execFunc === "function") {
            execFunc();
        }
        cancel();
    }

    this.prompt = function(headText, execFunc) {
        render(headText);
        $("#ok-btn").click(function () { ok(execFunc) });
        $("#cancel-btn").click(function () { cancel() });
    };
}