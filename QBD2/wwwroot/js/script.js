﻿function onlyAllowNumbers() {
    setTimeout(() =>
    {
        $('.numeric').on('keypress', function (ev) {
            var keyCode = window.event ? ev.keyCode : ev.which;

            if ((keyCode < 48 || keyCode > 57) && keyCode != 46) {
                //codes for backspace, delete, enter            
                if (keyCode != 0 || keyCode != 8 && keyCode != 13) {
                    ev.preventDefault();
                }
            }
        });
    }, 2000);
}


function openNav() {
    setTimeout(() => {
        document.getElementById("mySidebar").style.width = "850px";
    }, 2000);
}

function closeNav() {
    document.getElementById("mySidebar").style.width = "0";
}