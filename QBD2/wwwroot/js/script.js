window.AlertMessage = function (message) {
    alert(message);
}
window.confirmMessage = function (message) {
    var answer = confirm(message);
    if (answer) {
        return true;
    }
    else {
        return false;
    }
}

function onlyAllowNumbers() {
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
        document.getElementById("mySidebar").style.width = "100%";
    }, 2000);
}

function closeNav() {
     document.getElementById("mySidebar").style.width = "0";      
    /*$('#mySidebar').animate({
        left: '0px'
    }, 2000, 'easeOutQuint');*/
}

function ModelBodyOverflowShown() {
    $('body').css('overflow', 'hidden');
}

function ModelBodyOverflowHidden() {
    $('body').css('overflow', 'auto');
}