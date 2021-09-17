function handleKeyDown(event) {
    switch (event.keyCode) {
        case 116: // F5
            event.preventDefault();
            event.keyCode = 0;
            window.status = "F5 disabled";
            return false;

        case 82: //R
            if (event.ctrlKey) {
                event.returnValue = false;
                event.keyCode = 0;
                window.status = "CTRL-R disabled";
                return false;
            }
            break;

        default:
            break;
    }

    return true;
}

document.addEventListener("keydown", handleKeyDown);