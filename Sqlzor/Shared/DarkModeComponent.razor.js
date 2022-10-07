window.darkMode_addMetaTag = function () {
    // <meta name="color-scheme" content="dark light">

    var elements = Array.from(document.getElementsByTagName("meta"));

    for (var i = 0; i < elements.length; i++) {
        if (elements[i].hasAttribute("name") && elements[i].name == "color-scheme") {
            if (elements[i].content != "dark light") {
                elements[i].content = "dark light";
                console.info("dark mode meta tag adjusted");
            }
            else {
                console.info("dark mode meta tag already existed");
            }

            return;
        }
    }

    var meta = document.createElement('meta');
    meta.name = "color-scheme";
    meta.content = "dark light";
    document.getElementsByTagName('head')[0].appendChild(meta);

    console.info("dark mode meta tag created");
}

window.darkMode_isDarkMode = function () {
    // check classes on html tags for a current setting
    const elements = Array.from(document.getElementsByTagName("html"));
    if (elements.some(e => e.classList.contains("dark"))) {
        return true;
    }
    else if (elements.some(e => e.classList.contains("light"))) {
        return false;
    }
    
    // check local storage for a prior setting
    const colorMode = localStorage.getItem("ColorMode");
    if (colorMode == "dark") {
        return true;
    }
    else if (colorMode == "light") {
        return false;
    }

    // fallback to OS preference
    const preferDarkMode = window.matchMedia('(prefers-color-scheme: dark)').matches;
    return preferDarkMode;
}

window.darkMode_setDarkMode = function (isDarkMode) {
    const className = isDarkMode ? "dark" : "light";

    localStorage.setItem("ColorMode", className);

    var elements = document.getElementsByTagName("html");
    for (var i = 0; i < elements.length; i++) {
        elements[i].className = className;
    }
}