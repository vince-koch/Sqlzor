function configureTextEditor(textareaId, buttonId) {
    var textarea = document.getElementById(textareaId);
    var button = document.getElementById(buttonId);

    // handle tabs
    tabOverride.set(textarea);
    tabOverride.tabSize(4);

    // ignore F5
    textarea.addEventListener("keydown", function (e) {
        if (e.key == "F5") {
            e.preventDefault();
            button.click();
        }
    });
}
